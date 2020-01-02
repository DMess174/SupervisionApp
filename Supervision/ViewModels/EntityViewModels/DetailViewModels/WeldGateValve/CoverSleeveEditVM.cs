using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class CoverSleeveEditVM: BasePropertyChanged
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<MetalMaterial> materials;
        private IEnumerable<CoverSealingRing> coverSealingRings;
        private IEnumerable<string> drawings;
        private IEnumerable<CoverSleeveTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CoverSleeveJournal> journal;
        private readonly BaseTable parentEntity;
        private CoverSleeve selectedItem;
        private CoverSleeveTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editMaterial;
        private ICommand editCoverSealingRing;

        public CoverSleeve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CoverSleeveJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoverSleeveTCP> Points
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
                            if (SelectedItem.CoverSealingRing != null)
                            {
                                var detail = db.CoverSealingRings.Include(i => i.CoverSleeve).SingleOrDefault(i => i.Id == SelectedItem.CoverSealingRingId);
                                if (detail?.CoverSleeve != null && detail.CoverSleeve.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Кольцо уплотнительное собрано с {detail.CoverSleeve.Name} № {detail.CoverSleeve.Number}", "Ошибка");
                                    return;
                                }
                            }
                            db.CoverSleeves.Update(SelectedItem);
                            db.SaveChanges();
                            foreach (var i in Journal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.CoverSleeveJournals.UpdateRange(Journal);
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
                        if (parentEntity is CoverSleeve)
                        {
                            var wn = new CoverSleeveView();
                            var vm = new CoverSleeveVM();
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
                            var item = new CoverSleeveJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.CoverSleeveJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.CoverSleeveJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }
        public ICommand EditMaterial
        {
            get
            {
                return editMaterial ?? (
                           editMaterial = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.MetalMaterial is PipeMaterial)
                               {
                                   var wn = new PipeMaterialEditView();
                                   var vm = new PipeMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else if (SelectedItem.MetalMaterial != null)
                               {
                                   if (SelectedItem.MetalMaterial is SheetMaterial)
                                   {
                                       var wn = new SheetMaterialEditView();
                                       var vm = new SheetMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   else if (SelectedItem.MetalMaterial is ForgingMaterial)
                                   {
                                       var wn = new ForgingMaterialEditView();
                                       var vm = new ForgingMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   else if (SelectedItem.MetalMaterial is RolledMaterial)
                                   {
                                       var wn = new RolledMaterialEditView();
                                       var vm = new RolledMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                               }
                               else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
                           }));
            }
        }
        public ICommand EditCoverSealingRing
        {
            get
            {
                return editCoverSealingRing ?? (
                           editCoverSealingRing = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CoverSealingRing != null)
                               {
                                   var wn = new CoverSealingRingEditView();
                                   var vm = new CoverSealingRingEditVM(SelectedItem.CoverSealingRing.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
                           }));
            }
        }

        public IEnumerable<MetalMaterial> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoverSealingRing> CoverSealingRings
        {
            get => coverSealingRings;
            set
            {
                coverSealingRings = value;
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

        public CoverSleeveTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public CoverSleeveEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.CoverSleeves.Include(i => i.WeldGateValveCover).SingleOrDefault(i => i.Id == id);
            Journal = db.CoverSleeveJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.CoverSleeves.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.MetalMaterials.ToList();
            CoverSealingRings = db.CoverSealingRings.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<CoverSleeveTCP>().ToList();
        }
    }
}
