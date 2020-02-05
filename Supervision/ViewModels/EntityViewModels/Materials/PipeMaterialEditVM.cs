﻿using DataLayer;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class PipeMaterialEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> firstSizes;
        private IEnumerable<string> secondSizes;
        private IEnumerable<string> thirdSizes;
        private IEnumerable<MetalMaterialTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<PipeMaterialJournal> journal;
        private readonly BaseTable parentEntity;
        private MetalMaterialTCP selectedTCPPoint;

        private PipeMaterial selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public PipeMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<PipeMaterialJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<MetalMaterialTCP> Points
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
                            db.PipeMaterials.Update(SelectedItem);
                            db.SaveChanges();
                            db.PipeMaterialJournals.UpdateRange(Journal);
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
                        if (!(parentEntity is PipeMaterial)) w?.Close();
                        else
                        {
                            var wn = new PipeMaterialView();
                            var vm = new PipeMaterialVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
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
                            var item = new PipeMaterialJournal()
                            {
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.PipeMaterialJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.PipeMaterialJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
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
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> FirstSizes
        {
            get => firstSizes;
            set
            {
                firstSizes = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> SecondSizes
        {
            get => secondSizes;
            set
            {
                secondSizes = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> ThirdSizes
        {
            get => thirdSizes;
            set
            {
                thirdSizes = value;
                RaisePropertyChanged();
            }
        }

        public MetalMaterialTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public PipeMaterialEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.PipeMaterials.Find(id);
            Journal = db.Set<PipeMaterialJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Materials = db.PipeMaterials.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            FirstSizes = db.PipeMaterials.Select(t => t.FirstSize).Distinct().OrderBy(x => x).ToList();
            SecondSizes = db.PipeMaterials.Select(t => t.SecondSize).Distinct().OrderBy(x => x).ToList();
            ThirdSizes = db.PipeMaterials.Select(d => d.ThirdSize).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.MetalMaterialTCPs.ToList();
        }
    }
}
