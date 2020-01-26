using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.ViewModels.EntityViewModels.Periodical.Gate;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.MaterialViews;
using Supervision.Views.EntityViews.PeriodicalControl;
using Supervision.Views.EntityViews.PeriodicalControl.Gate;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class GateEditVM: BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private ICommand editPID;
        private IEnumerable<PID> pIDs;
        private ICommand degreasingChemicalCompositionOpen;

        private ICommand coatingChemicalCompositionOpen;

        private ICommand coatingPlasticityOpen;

        private ICommand coatingProtectivePropertiesOpen;

        private ICommand coatingPorosityOpen;

        public ICommand EditPID
        {
            get
            {
                return editPID ?? (
                           editPID = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.PIDId != null)
                               {
                                   var wn = new PIDEditView();
                                   var vm = new PIDEditVM(SelectedItem.PID.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<PID> PIDs
        {
            get => pIDs;
            set
            {
                pIDs = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<GateTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<GateJournal> castInputControlJournal;
        private IEnumerable<GateJournal> sheetInputControlJournal;
        private IEnumerable<GateJournal> castPreparationJournal;
        private IEnumerable<GateJournal> sheetPreparationJournal;
        private IEnumerable<GateJournal> castCoatingJournal;
        private IEnumerable<GateJournal> sheetCoatingJournal;
        private IEnumerable<GateJournal> castTestJournal;
        private IEnumerable<GateJournal> sheetTestJournal;
        private IEnumerable<GateJournal> castDocumentationJournal;
        private IEnumerable<GateJournal> sheetDocumentationJournal;
        private IEnumerable<GateJournal> castShippedJournal;
        private IEnumerable<GateJournal> sheetShippedJournal;
        private readonly BaseTable parentEntity;
        private Gate selectedItem;
        private GateTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editMaterial;

        public Gate SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<GateJournal> CastInputControlJournal
        {
            get => castInputControlJournal;
            set
            {
                castInputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetInputControlJournal
        {
            get => sheetInputControlJournal;
            set
            {
                sheetInputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CastPreparationJournal
        {
            get => castPreparationJournal;
            set
            {
                castPreparationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetPreparationJournal
        {
            get => sheetPreparationJournal;
            set
            {
                sheetPreparationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CastCoatingJournal
        {
            get => castCoatingJournal;
            set
            {
                castCoatingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetCoatingJournal
        {
            get => sheetCoatingJournal;
            set
            {
                sheetCoatingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CastTestJournal
        {
            get => castTestJournal;
            set
            {
                castTestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetTestJournal
        {
            get => sheetTestJournal;
            set
            {
                sheetTestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CastDocumentationJournal
        {
            get => castDocumentationJournal;
            set
            {
                castDocumentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetDocumentationJournal
        {
            get => sheetDocumentationJournal;
            set
            {
                sheetDocumentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CastShippedJournal
        {
            get => castShippedJournal;
            set
            {
                castShippedJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> SheetShippedJournal
        {
            get => sheetShippedJournal;
            set
            {
                sheetShippedJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateTCP> Points
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
                            db.Gates.Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in CastInputControlJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastInputControlJournal);
                            db.SaveChanges();
                            foreach (var i in SheetInputControlJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetInputControlJournal);
                            db.SaveChanges();
                            foreach (var i in CastPreparationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastPreparationJournal);
                            db.SaveChanges();
                            foreach (var i in SheetPreparationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetPreparationJournal);
                            db.SaveChanges();
                            foreach (var i in CastCoatingJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastCoatingJournal);
                            db.SaveChanges();
                            foreach (var i in SheetCoatingJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetCoatingJournal);
                            db.SaveChanges();
                            foreach (var i in CastTestJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastTestJournal);
                            db.SaveChanges();
                            foreach (var i in SheetTestJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetTestJournal);
                            db.SaveChanges();
                            foreach (var i in CastDocumentationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastDocumentationJournal);
                            db.SaveChanges();
                            foreach (var i in SheetDocumentationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetDocumentationJournal);
                            db.SaveChanges();
                            foreach (var i in CastShippedJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CastShippedJournal);
                            db.SaveChanges();
                            foreach (var i in SheetShippedJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(SheetShippedJournal);
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
                        if (parentEntity is Gate)
                        {
                            var wn = new GateView();
                            var vm = new GateVM();
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
                            var item = new GateJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.GateJournals.Add(item);
                            db.SaveChanges();
                            CastInputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
                            SheetInputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
                            CastPreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
                            SheetPreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
                            CastCoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
                            SheetCoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
                            CastTestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
                            SheetTestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
                            CastDocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
                            SheetDocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
                            CastShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
                            SheetShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
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

        public IEnumerable<MetalMaterial> Materials
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

        public GateTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public ICommand DegreasingChemicalCompositionOpen
        {
            get
            {
                return degreasingChemicalCompositionOpen ?? (
                           degreasingChemicalCompositionOpen = new DelegateCommand<Window>((w) =>
                           {
                               var wn = new PeriodicalControlView();
                               var vm = new DegreasingChemicalCompositionVM();
                               wn.DataContext = vm;
                               wn.Show();
                           }));
            }
        }
        public ICommand CoatingChemicalCompositionOpen
        {
            get
            {
                return coatingChemicalCompositionOpen ?? (
                           coatingChemicalCompositionOpen = new DelegateCommand<Window>((w) =>
                           {
                               var wn = new PeriodicalControlView();
                               var vm = new CoatingChemicalCompositionVM();
                               wn.DataContext = vm;
                               wn.Show();
                           }));
            }
        }
        public ICommand CoatingPlasticityOpen
        {
            get
            {
                return coatingPlasticityOpen ?? (
                           coatingPlasticityOpen = new DelegateCommand<Window>((w) =>
                           {
                               var wn = new PeriodicalControlView();
                               var vm = new CoatingPlasticityVM();
                               wn.DataContext = vm;
                               wn.Show();
                           }));
            }
        }
        public ICommand CoatingProtectivePropertiesOpen
        {
            get
            {
                return coatingProtectivePropertiesOpen ?? (
                           coatingProtectivePropertiesOpen = new DelegateCommand<Window>((w) =>
                           {
                               var wn = new PeriodicalControlView();
                               var vm = new CoatingProtectivePropertiesVM();
                               wn.DataContext = vm;
                               wn.Show();
                           }));
            }
        }
        public ICommand CoatingPorosityOpen
        {
            get
            {
                return coatingPorosityOpen ?? (
                           coatingPorosityOpen = new DelegateCommand<Window>((w) =>
                           {
                               var wn = new CoatingPorosityView();
                               var vm = new CoatingPorosityVM();
                               wn.DataContext = vm;
                               wn.Show();
                           }));
            }
        }

        public GateEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Gates.Include(i => i.BaseValve).SingleOrDefault(i => i.Id == id);
            PIDs = db.PIDs.Include(i => i.Specification).ToList();
            CastInputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
            SheetInputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
            CastPreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
            SheetPreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
            CastCoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
            SheetCoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
            CastTestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
            SheetTestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
            CastDocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
            SheetDocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
            CastShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ" && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
            SheetShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ" && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Gates.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.MetalMaterials.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<GateTCP>().ToList();
        }
    }
}
