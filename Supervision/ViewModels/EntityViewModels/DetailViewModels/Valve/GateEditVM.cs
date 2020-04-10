using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.ViewModels.EntityViewModels.Periodical.Gate;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.MaterialViews;
using Supervision.Views.EntityViews.PeriodicalControl.Gate;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class GateEditVM: ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<PID> pIDs;
        private GateJournal operation;

        public GateJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
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
        private readonly GateRepository gateRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly MetalMaterialRepository materialRepo;
        private readonly PIDRepository pIDRepo;
        private readonly JournalNumberRepository journalRepo;
        private Gate selectedItem;
        private GateTCP selectedTCPPoint;

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


        public static GateEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            GateEditVM vm = new GateEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        public ICommand DegreasingChemicalCompositionOpenCommand { get; private set; }
        private void DegreasingChemicalCompositionOpen()
        {
            _ = new GatePeriodicalView
            {
                DataContext = DegreasingChemicalCompositionVM.LoadVM(db)
            };
        }

        public ICommand CoatingChemicalCompositionOpenCommand { get; private set; }
        private void CoatingChemicalCompositionOpen()
        {
            _ = new GatePeriodicalView
            {
                DataContext = CoatingChemicalCompositionVM.LoadVM(db)
            };
        }

        public ICommand CoatingPlasticityOpenCommand { get; private set; }
        private void CoatingPlasticityOpen()
        {
            _ = new GatePeriodicalView
            {
                DataContext = CoatingPlasticityVM.LoadVM(db)
            };
        }

        public ICommand CoatingProtectivePropertiesOpenCommand { get; private set; }
        private void CoatingProtectivePropertiesOpen()
        {
            _ = new GatePeriodicalView
            {
                DataContext = CoatingProtectivePropertiesVM.LoadVM(db)
            };
        }

        public ICommand CoatingPorosityOpenCommand { get; private set; }
        private void CoatingPorosityOpen()
        {
            _ = new CoatingPorosityView
            {
                DataContext = CoatingPorosityVM.LoadVM(db)
            };
        }

        public Commands.IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => gateRepo.GetByIdIncludeAsync(id));
                Materials = await Task.Run(() => materialRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                PIDs = await Task.Run(() => pIDRepo.GetAllAsync());
                Drawings = await Task.Run(() => gateRepo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => gateRepo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                InputControlJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                PreparationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId);
                CoatingJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippedJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => gateRepo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.GateJournals.Add(new GateJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                InputControlJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                PreparationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId);
                CoatingJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippedJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
            }
        }

        public Supervision.Commands.IAsyncCommand RemoveOperationCommand { get; private set; }
        private async Task RemoveOperation()
        {
            try
            {
                IsBusy = true;
                if (Operation != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.GateJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        InputControlJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                        PreparationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка поверхности").OrderBy(x => x.PointId);
                        CoatingJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Покрытие").OrderBy(x => x.PointId);
                        TestJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                        DocumentationJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                        ShippedJournal = SelectedItem.GateJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }

        }

        public ICommand EditPIDCommand { get; private set; }
        private void EditPID()
        {
            if (SelectedItem.PID != null)
            {
                _ = new PIDEditView
                {
                    DataContext = PIDEditVM.LoadPIDEditVM(SelectedItem.PID.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("PID не выбран", "Ошибка");
        }

        public ICommand EditMaterialCommand { get; private set; }
        private void EditMaterial()
        {
            if (SelectedItem.MetalMaterial != null)
            {
                if (SelectedItem.MetalMaterial is PipeMaterial)
                {
                    _ = new PipeMaterialEditView
                    {
                        DataContext = PipeMaterialEditVM.LoadPipeMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }

                if (SelectedItem.MetalMaterial is SheetMaterial)
                {
                    _ = new SheetMaterialEditView
                    {
                        DataContext = SheetMaterialEditVM.LoadSheetMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
                else if (SelectedItem.MetalMaterial is ForgingMaterial)
                {
                    _ = new ForgingMaterialEditView
                    {
                        DataContext = ForgingMaterialEditVM.LoadForgingMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
                else if (SelectedItem.MetalMaterial is RolledMaterial)
                {
                    _ = new RolledMaterialEditView
                    {
                        DataContext = RolledMaterialEditVM.LoadRolledMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
            }
            else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
        }

        protected override void CloseWindow(object obj)
        {
            if (gateRepo.HasChanges(SelectedItem) || gateRepo.HasChanges(SelectedItem.GateJournals))
            {
                MessageBoxResult result = MessageBox.Show("Закрыть без сохранения изменений?", "Выход", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Window w = obj as Window;
                    w?.Close();
                }
            }
            else
            {
                Window w = obj as Window;
                w?.Close();
            }
        }

        public GateEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            gateRepo = new GateRepository(db);
            inspectorRepo = new InspectorRepository(db);
            materialRepo = new MetalMaterialRepository(db);
            pIDRepo = new PIDRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
            EditPIDCommand = new Supervision.Commands.Command(o => EditPID());
            DegreasingChemicalCompositionOpenCommand = new Supervision.Commands.Command(o => DegreasingChemicalCompositionOpen());
            CoatingChemicalCompositionOpenCommand = new Supervision.Commands.Command(o => CoatingChemicalCompositionOpen());
            CoatingPlasticityOpenCommand = new Supervision.Commands.Command(o => CoatingPlasticityOpen());
            CoatingPorosityOpenCommand = new Supervision.Commands.Command(o => CoatingPorosityOpen());
            CoatingProtectivePropertiesOpenCommand = new Supervision.Commands.Command(o => CoatingProtectivePropertiesOpen());
        }
    }
}
