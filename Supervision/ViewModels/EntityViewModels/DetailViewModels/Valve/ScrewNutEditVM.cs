using System.Collections.Generic;
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
    public class ScrewNutEditVM: BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ScrewNutTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ScrewNutJournal> castJournal;
        private IEnumerable<ScrewNutJournal> sheetJournal;
        private IEnumerable<ScrewNutJournal> compactJournal;
        private readonly BaseTable parentEntity;
        private ScrewNut selectedItem;
        private ScrewNutTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        public ScrewNut SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ScrewNutJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ScrewNutJournal> SheetJournal
        {
            get => sheetJournal;
            set
            {
                sheetJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ScrewNutJournal> CompactJournal
        {
            get => compactJournal;
            set
            {
                compactJournal = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ScrewNutTCP> Points
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
                            if (SelectedItem.AmountRemaining == null && SelectedItem.Amount > 0) SelectedItem.AmountRemaining = SelectedItem.Amount;
                            else SelectedItem.AmountRemaining = SelectedItem.Amount - SelectedItem.BaseValveWithScrewNuts?.Select(i => i.ScrewNutAmount).Sum();
                            db.ScrewNuts.Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in CastJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.ScrewNutJournals.UpdateRange(CastJournal);
                            db.SaveChanges();
                            foreach (var i in SheetJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.ScrewNutJournals.UpdateRange(SheetJournal);
                            db.SaveChanges();
                            foreach (var i in CompactJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.ScrewNutJournals.UpdateRange(CompactJournal);
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
                        if (parentEntity is ScrewNut)
                        {
                            var wn = new ScrewNutView();
                            var vm = new ScrewNutVM();
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
                            var item = new ScrewNutJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.ScrewNutJournals.Add(item);
                            db.SaveChanges();
                            CastJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            SheetJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            CompactJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
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

        public ScrewNutTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public ScrewNutEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.ScrewNuts.Include(i => i.BaseValveWithScrewNuts).SingleOrDefault(i => i.Id == id);
            CastJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            SheetJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            CompactJournal = db.ScrewNutJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.ScrewNuts.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.ScrewNuts.Select(s => s.Material).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<ScrewNutTCP>().Include(i => i.ProductType).ToList();
        }
    }
}
