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
    public class AssemblyUnitSealingEditVM: BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<string> names;
        private IEnumerable<AssemblyUnitSealingTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<AssemblyUnitSealingJournal> castJournal;
        private IEnumerable<AssemblyUnitSealingJournal> sheetJournal;
        private IEnumerable<AssemblyUnitSealingJournal> compactJournal;
        private readonly BaseTable parentEntity;
        private AssemblyUnitSealing selectedItem;
        private AssemblyUnitSealingTCP selectedTCPPoint;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        public AssemblyUnitSealing SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AssemblyUnitSealingJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AssemblyUnitSealingJournal> SheetJournal
        {
            get => sheetJournal;
            set
            {
                sheetJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AssemblyUnitSealingJournal> CompactJournal
        {
            get => compactJournal;
            set
            {
                compactJournal = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<AssemblyUnitSealingTCP> Points
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
                                SelectedItem.AmountRemaining = SelectedItem.Amount - SelectedItem.BaseValveWithSeals?.Count();
                            db.AssemblyUnitSeals.Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in CastJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.AssemblyUnitSealingJournals.UpdateRange(CastJournal);
                            db.SaveChanges();
                            foreach (var i in SheetJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.AssemblyUnitSealingJournals.UpdateRange(SheetJournal);
                            db.SaveChanges();
                            foreach (var i in CompactJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.AssemblyUnitSealingJournals.UpdateRange(CompactJournal);
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
                        if (parentEntity is AssemblyUnitSealing)
                        {
                            var wn = new AssemblyUnitSealingView();
                            var vm = new AssemblyUnitSealingVM();
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
                            var item = new AssemblyUnitSealingJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.AssemblyUnitSealingJournals.Add(item);
                            db.SaveChanges();
                            CastJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            SheetJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            CompactJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                        }
                    }));
            }
        }

        public IEnumerable<string> Names
        {
            get => names;
            set
            {
                names = value;
                RaisePropertyChanged();
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

        public AssemblyUnitSealingTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public AssemblyUnitSealingEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.AssemblyUnitSeals.Include(i => i.BaseValveWithSeals).SingleOrDefault(i => i.Id == id);
            CastJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            SheetJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            CompactJournal = db.AssemblyUnitSealingJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.AssemblyUnitSeals.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.AssemblyUnitSeals.Select(s => s.Material).Distinct().OrderBy(x => x).ToList();
            Names = db.AssemblyUnitSeals.Select(s => s.Name).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<AssemblyUnitSealingTCP>().Include(i => i.ProductType).ToList();
        }
    }
}
