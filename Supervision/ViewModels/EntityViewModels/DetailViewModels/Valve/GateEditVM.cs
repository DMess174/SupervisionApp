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
        private IEnumerable<GateJournal> inputControlJournal;
        private IEnumerable<GateJournal> preparationJournal;
        private IEnumerable<GateJournal> coatingJournal;
        private IEnumerable<GateJournal> testJournal;
        private IEnumerable<GateJournal> documentationJournal;
        private IEnumerable<GateJournal> shippedJournal;
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

        public IEnumerable<GateJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
       
        public IEnumerable<GateJournal> PreparationJournal
        {
            get => preparationJournal;
            set
            {
                preparationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> CoatingJournal
        {
            get => coatingJournal;
            set
            {
                coatingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> TestJournal
        {
            get => testJournal;
            set
            {
                testJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> DocumentationJournal
        {
            get => documentationJournal;
            set
            {
                documentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<GateJournal> ShippedJournal
        {
            get => shippedJournal;
            set
            {
                shippedJournal = value;
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
                            foreach(var i in InputControlJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(InputControlJournal);
                            foreach (var i in PreparationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(PreparationJournal);
                            foreach (var i in CoatingJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(CoatingJournal);
                            foreach (var i in TestJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(TestJournal);
                            foreach (var i in DocumentationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(DocumentationJournal);
                            foreach (var i in ShippedJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.GateJournals.UpdateRange(ShippedJournal);
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
                            InputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
                            PreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
                            CoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
                            TestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
                            DocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
                            ShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
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
                               var wn = new GatePeriodicalView();
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
                               var wn = new GatePeriodicalView();
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
                               var wn = new GatePeriodicalView();
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
                               var wn = new GatePeriodicalView();
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
            InputControlJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
            PreparationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId).ToList();
            CoatingJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId).ToList();
            TestJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
            DocumentationJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
            ShippedJournal = db.Set<GateJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Gates.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.MetalMaterials.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<GateTCP>().ToList();
        }
    }
}
