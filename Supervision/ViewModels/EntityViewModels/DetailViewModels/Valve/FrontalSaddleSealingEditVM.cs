﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews.Valve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class FrontalSaddleSealingEditVM: BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<FrontalSaddleSealingTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<FrontalSaddleSealingJournal> journal;
        private readonly BaseTable parentEntity;
        private FrontalSaddleSealing selectedItem;
        private FrontalSaddleSealingTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        public FrontalSaddleSealing SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<FrontalSaddleSealingJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<FrontalSaddleSealingTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveItem
        {
            get
            {
                return saveItem ?? (
                    saveItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            if (SelectedItem.AmountRemaining == null && SelectedItem.Amount > 0) 
                                SelectedItem.AmountRemaining = SelectedItem.Amount;
                            else 
                                SelectedItem.AmountRemaining = SelectedItem.Amount - SelectedItem.SaddleWithSealings?.Count();
                            db.FrontalSaddleSeals.Update(SelectedItem);
                            db.SaveChanges();
                            db.FrontalSaddleSealingJournals.UpdateRange(Journal);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не найден!", "Ошибка");
                    }));
            }
        }
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        if (parentEntity is FrontalSaddleSealing)
                        {
                            var wn = new FrontalSaddleSealingView();
                            var vm = new FrontalSaddleSealingVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else w?.Close();
                    }));
            }
        }
        public ICommand AddOperation
        {
            get
            {
                return addOperation ?? (
                    addOperation = new DelegateCommand(() =>
                    {
                        if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                        else
                        {
                            var item = new FrontalSaddleSealingJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.FrontalSaddleSealingJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.FrontalSaddleSealingJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }
     
        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public FrontalSaddleSealingTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public FrontalSaddleSealingEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.FrontalSaddleSeals.Include(i => i.SaddleWithSealings).ThenInclude(i => i.Saddle).SingleOrDefault(i => i.Id == id);
            Journal = db.FrontalSaddleSealingJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.FrontalSaddleSeals.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.FrontalSaddleSeals.Select(s => s.Material).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<FrontalSaddleSealingTCP>().Include(i => i.ProductType).ToList();
        }
    }
}
