using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DevExpress.Mvvm.Native;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter;
using Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class ReverseShutterEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly SlamShutterRepository slamRepo;
        private readonly ShaftShutterRepository shaftRepo;
        private readonly BronzeSleeveShutterRepository bronzeSleeveRepo;
        private readonly SteelSleeveShutterRepository steelSleeveRepo;
        private readonly StubShutterRepository stubRepo;
        private readonly BaseAnticorrosiveCoatingRepository materialRepo;
        private readonly PIDRepository pIDRepo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<BronzeSleeveShutter> bronzeSleeves;
        private IEnumerable<SteelSleeveShutter> steelSleeves;
        private IEnumerable<StubShutter> stubs;
        private BronzeSleeveShutter selectedBronzeSleeve;
        private BronzeSleeveShutter selectedBronzeSleeveFromList;
        private StubShutter selectedStub;
        private StubShutter selectedStubFromList;
        private IEnumerable<BaseAnticorrosiveCoating> anticorrosiveMaterials;
        private SteelSleeveShutter selectedSteelSleeve;
        private SteelSleeveShutter selectedSteelSleeveFromList;
        private IEnumerable<string> drawings;
        private IEnumerable<ReverseShutterTCP> points;
        private IEnumerable<ReverseShutterCase> cases;
        private IEnumerable<SlamShutter> slams;
        private IEnumerable<ShaftShutter> shafts;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ReverseShutterJournal> assemblyJournal;
        private readonly BaseTable parentEntity;
        private readonly ReverseShutterRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly ReverseShutterCaseRepository caseRepo;
        private ReverseShutter selectedItem;
        private ReverseShutterTCP selectedTCPPoint;
        private ReverseShutterJournal operation;
        private CoatingJournal coatingOperation;

        public CoatingJournal CoatingOperation
        {
            get => coatingOperation;
            set
            {
                coatingOperation = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerable<ReverseShutterJournal> testJournal;
        private IEnumerable<ReverseShutterJournal> afterTestJournal;
        private IEnumerable<ReverseShutterJournal> documentationJournal;
        private IEnumerable<ReverseShutterJournal> shippingJournal;
        private IEnumerable<CoatingJournal> coatingJournal;
        private IEnumerable<PID> pIDs;
        private CoatingTCP selectedCoatingTCPPoint;
        private IEnumerable<CoatingTCP> coatingPoints;
        private BaseAnticorrosiveCoating selectedMaterial;
        private ReverseShutterWithCoating selectedMaterialFromList;

        public ReverseShutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ReverseShutterJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> TestJournal
        {
            get => testJournal;
            set
            {
                testJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> AfterTestJournal
        {
            get => afterTestJournal;
            set
            {
                afterTestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> DocumentationJournal
        {
            get => documentationJournal;
            set
            {
                documentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> ShippingJournal
        {
            get => shippingJournal;
            set
            {
                shippingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingJournal> CoatingJournal
        {
            get => coatingJournal;
            set
            {
                coatingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingTCP> CoatingPoints
        {
            get => coatingPoints;
            set
            {
                coatingPoints = value;
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
        
        public BronzeSleeveShutter SelectedBronzeSleeve
        {
            get => selectedBronzeSleeve;
            set
            {
                selectedBronzeSleeve = value;
                RaisePropertyChanged();
            }
        }

        public BronzeSleeveShutter SelectedBronzeSleeveFromList
        {
            get => selectedBronzeSleeveFromList;
            set
            {
                selectedBronzeSleeveFromList = value;
                RaisePropertyChanged();
            }
        }
        
        public SteelSleeveShutter SelectedSteelSleeve
        {
            get => selectedSteelSleeve;
            set
            {
                selectedSteelSleeve = value;
                RaisePropertyChanged();
            }
        }

        public SteelSleeveShutter SelectedSteelSleeveFromList
        {
            get => selectedSteelSleeveFromList;
            set
            {
                selectedSteelSleeveFromList = value;
                RaisePropertyChanged();
            }
        }
        
        public StubShutter SelectedStub
        {
            get => selectedStub;
            set
            {
                selectedStub = value;
                RaisePropertyChanged();
            }
        }

        public StubShutter SelectedStubFromList
        {
            get => selectedStubFromList;
            set
            {
                selectedStubFromList = value;
                RaisePropertyChanged();
            }
        }
        
        public BaseAnticorrosiveCoating SelectedMaterial
        {
            get => selectedMaterial;
            set
            {
                selectedMaterial = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterWithCoating SelectedMaterialFromList
        {
            get => selectedMaterialFromList;
            set
            {
                selectedMaterialFromList = value;
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

        public IEnumerable<ReverseShutterCase> Cases
        {
            get => cases;
            set
            {
                cases = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SlamShutter> Slams
        {
            get => slams;
            set
            {
                slams = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ShaftShutter> Shafts
        {
            get => shafts;
            set
            {
                shafts = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<BronzeSleeveShutter> BronzeSleeves
        {
            get => bronzeSleeves;
            set
            {
                bronzeSleeves = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SteelSleeveShutter> SteelSleeves
        {
            get => steelSleeves;
            set
            {
                steelSleeves = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<StubShutter> Stubs
        {
            get => stubs;
            set
            {
                stubs = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<BaseAnticorrosiveCoating> AnticorrosiveMaterials
        {
            get => anticorrosiveMaterials;
            set
            {
                anticorrosiveMaterials = value;
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

        public ReverseShutterTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public CoatingTCP SelectedCoatingTCPPoint
        {
            get => selectedCoatingTCPPoint;
            set
            {
                selectedCoatingTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public Supervision.Commands.IAsyncCommand AddMaterialToShutterCommand { get; private set; }
        private async Task AddMaterialToShutter()
        {
            try
            {
                if (SelectedMaterial != null)
                {
                    IsBusy = true;
                    SelectedItem.ReverseShutterWithCoatings.Add(new ReverseShutterWithCoating() { ReverseShutterId = SelectedItem.Id, BaseAnticorrosiveCoatingId = SelectedMaterial.Id });
                    materialRepo.Update(SelectedMaterial);
                    SelectedMaterial = null;
                    await SaveItemCommand.ExecuteAsync();
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteMaterialFromShutterCommand { get; private set; }
        private async Task DeleteMaterialFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedMaterialFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedMaterial = SelectedMaterialFromList.BaseAnticorrosiveCoating;
                        SelectedItem.ReverseShutterWithCoatings.Remove(SelectedMaterialFromList);
                        materialRepo.Update(SelectedMaterial);
                        SelectedMaterial = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditMaterialCommand { get; private set; }
        private void EditMaterial()
        {
            if (SelectedMaterialFromList != null)
            {
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is Undercoat)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = UndercoatEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbovegroundCoating)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = AbovegroundCoatingEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is UndergroundCoating)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = UndergroundCoatingEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbrasiveMaterial)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = AbrasiveMaterialEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddBronzeSleeveToShutterCommand { get; private set; }
        private async Task AddBronzeSleeveToShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.BronzeSleeveShutters?.Count() < 2 || SelectedItem.BronzeSleeveShutters == null)
                {
                    if (SelectedBronzeSleeve != null)
                    {
                        if (!await bronzeSleeveRepo.IsAssembliedAsync(SelectedBronzeSleeve))
                        {
                            SelectedBronzeSleeve.ReverseShutterId = SelectedItem.Id;
                            bronzeSleeveRepo.Update(SelectedBronzeSleeve);
                            SelectedBronzeSleeve = null;
                            BronzeSleeves = bronzeSleeveRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 втулок!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteBronzeSleeveFromShutterCommand { get; private set; }
        private async Task DeleteBronzeSleeveFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedBronzeSleeveFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedBronzeSleeveFromList.ReverseShutterId = null;
                        bronzeSleeveRepo.Update(SelectedBronzeSleeveFromList);
                        BronzeSleeves = bronzeSleeveRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditBronzeSleeveCommand { get; private set; }
        private void EditBronzeSleeve()
        {
            if (SelectedBronzeSleeveFromList != null)
            {
                _ = new BronzeSleeveShutterEditView
                {
                    DataContext = BronzeSleeveShutterEditVM.LoadVM(SelectedBronzeSleeveFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddSteelSleeveToShutterCommand { get; private set; }
        private async Task AddSteelSleeveToShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.SteelSleeveShutters?.Count() < 2 || SelectedItem.SteelSleeveShutters == null)
                {
                    if (SelectedSteelSleeve != null)
                    {
                        if (!await steelSleeveRepo.IsAssembliedAsync(SelectedSteelSleeve))
                        {
                            SelectedSteelSleeve.ReverseShutterId = SelectedItem.Id;
                            steelSleeveRepo.Update(SelectedSteelSleeve);
                            SelectedSteelSleeve = null;
                            SteelSleeves = steelSleeveRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 втулок!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteSteelSleeveFromShutterCommand { get; private set; }
        private async Task DeleteSteelSleeveFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedSteelSleeveFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedSteelSleeveFromList.ReverseShutterId = null;
                        steelSleeveRepo.Update(SelectedSteelSleeveFromList);
                        SteelSleeves = steelSleeveRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSteelSleeveCommand { get; private set; }
        private void EditSteelSleeve()
        {
            if (SelectedSteelSleeveFromList != null)
            {
                _ = new ReverseShutterDetailEditView
                {
                    DataContext = SteelSleeveShutterEditVM.LoadVM(SelectedSteelSleeveFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddStubToShutterCommand { get; private set; }
        private async Task AddStubToShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.StubShutters?.Count() < 2 || SelectedItem.StubShutters == null)
                {
                    if (SelectedStub != null)
                    {
                        if (!await stubRepo.IsAssembliedAsync(SelectedStub))
                        {
                            SelectedStub.ReverseShutterId = SelectedItem.Id;
                            stubRepo.Update(SelectedStub);
                            SelectedStub = null;
                            Stubs = stubRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 заглушек!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteStubFromShutterCommand { get; private set; }
        private async Task DeleteStubFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedStubFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedStubFromList.ReverseShutterId = null;
                        stubRepo.Update(SelectedStubFromList);
                        Stubs = stubRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditStubCommand { get; private set; }
        private void EditStub()
        {
            if (SelectedStubFromList != null)
            {
                _ = new ReverseShutterDetailEditView
                {
                    DataContext = StubShutterEditVM.LoadVM(SelectedStubFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public ICommand EditCaseCommand { get; private set; }
        private void EditCase()
        {
            if (SelectedItem.ReverseShutterCase != null)
            {
                _ = new ReverseShutterCaseEditView
                {
                    DataContext = ReverseShutterCaseEditVM.LoadVM(SelectedItem.ReverseShutterCase.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите корпус", "Ошибка");
        }

        public ICommand EditShaftCommand { get; private set; }
        private void EditShaft()
        {
            if (SelectedItem.ShaftShutter != null)
            {
                _ = new ReverseShutterDetailEditView
                {
                    DataContext = ShaftShutterEditVM.LoadVM(SelectedItem.ShaftShutter.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите ось", "Ошибка");
        }

        public ICommand EditSlamCommand { get; private set; }
        private void EditSlam()
        {
            if (SelectedItem.SlamShutter != null)
            {
                _ = new SlamShutterEditView
                {
                    DataContext = SlamShutterEditVM.LoadVM(SelectedItem.SlamShutter.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите захлопку", "Ошибка");
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
            else MessageBox.Show("Для просмотра привяжите PID", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                //if (SelectedItem.PIDId != null)
                //{
                //    if (!await Task.Run(() => pIDRepo.IsAmountRemaining(SelectedItem)))
                //    {
                //        SelectedItem.PID = null;
                //    }
                //}
                if (SelectedItem.ReverseShutterCaseId != null)
                {
                    if (await Task.Run(() => caseRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.ReverseShutterCase = null;
                    }
                }
                if (SelectedItem.SlamShutterId != null)
                {
                    if (await Task.Run(() => slamRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.SlamShutter = null;
                    }
                }
                if (SelectedItem.ShaftShutterId != null)
                {
                    if (await Task.Run(() => shaftRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.ShaftShutter = null;
                    }
                }
                await Task.Run(() => repo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.ReverseShutterJournals.Add(new ReverseShutterJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                AssemblyJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                AfterTestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippingJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
                SelectedTCPPoint = null;
            }
        }

        public Commands.IAsyncCommand RemoveOperationCommand { get; private set; }
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
                        SelectedItem.ReverseShutterJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        AssemblyJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                        TestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                        AfterTestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                        DocumentationJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                        ShippingJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddCoatingOperationCommand { get; private set; }
        public async Task AddCoatingOperation()
        {
            if (SelectedCoatingTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.CoatingJournals.Add(new CoatingJournal(SelectedItem, SelectedCoatingTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                SelectedCoatingTCPPoint = null;
            }
        }

        public Commands.IAsyncCommand RemoveCoatingOperationCommand { get; private set; }
        private async Task RemoveCoatingOperation()
        {
            try
            {
                IsBusy = true;
                if (CoatingOperation != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.CoatingJournals.Remove(CoatingOperation);
                        await SaveItemCommand.ExecuteAsync();
                        CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.ReverseShutterJournals) || repo.HasChanges(SelectedItem.CoatingJournals))
            {
                MessageBoxResult result = MessageBox.Show("Закрыть без сохранения изменений?", "Выход", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    base.CloseWindow(obj);
                }
            }
            else
            {
                base.CloseWindow(obj);
            }
        }

        public static ReverseShutterEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ReverseShutterEditVM vm = new ReverseShutterEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        

        public Commands.IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => repo.GetByIdIncludeAsync(id));
                PIDs = await Task.Run(() => pIDRepo.GetAllAsync());
                Cases = await Task.Run(() => caseRepo.GetAllAsync());
                Slams = await Task.Run(() => slamRepo.GetAllAsync());
                Shafts = await Task.Run(() => shaftRepo.GetAllAsync());
                await Task.Run(() => bronzeSleeveRepo.Load());
                await Task.Run(() => steelSleeveRepo.Load());
                await Task.Run(() => stubRepo.Load());
                AnticorrosiveMaterials = await Task.Run(() => materialRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                CoatingPoints = await Task.Run(() => repo.GetCoatingTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                BronzeSleeves = bronzeSleeveRepo.UpdateList();
                SteelSleeves = steelSleeveRepo.UpdateList();
                Stubs = stubRepo.UpdateList();
                AssemblyJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                AfterTestJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippingJournal = SelectedItem.ReverseShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ReverseShutterEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new ReverseShutterRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            caseRepo = new ReverseShutterCaseRepository(db);
            slamRepo = new SlamShutterRepository(db);
            shaftRepo = new ShaftShutterRepository(db);
            bronzeSleeveRepo = new BronzeSleeveShutterRepository(db);
            steelSleeveRepo = new SteelSleeveShutterRepository(db);
            stubRepo = new StubShutterRepository(db);
            materialRepo = new BaseAnticorrosiveCoatingRepository(db);
            pIDRepo = new PIDRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            AddCoatingOperationCommand = new Supervision.Commands.AsyncCommand(AddCoatingOperation);
            RemoveCoatingOperationCommand = new Supervision.Commands.AsyncCommand(RemoveCoatingOperation);
            AddBronzeSleeveToShutterCommand = new Supervision.Commands.AsyncCommand(AddBronzeSleeveToShutter);
            DeleteBronzeSleeveFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteBronzeSleeveFromShutter);
            EditBronzeSleeveCommand = new Supervision.Commands.Command(o => EditBronzeSleeve());
            AddSteelSleeveToShutterCommand = new Supervision.Commands.AsyncCommand(AddSteelSleeveToShutter);
            DeleteSteelSleeveFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteSteelSleeveFromShutter);
            EditSteelSleeveCommand = new Supervision.Commands.Command(o => EditSteelSleeve());
            AddStubToShutterCommand = new Supervision.Commands.AsyncCommand(AddStubToShutter);
            DeleteStubFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteStubFromShutter);
            EditStubCommand = new Supervision.Commands.Command(o => EditStub());
            AddMaterialToShutterCommand = new Supervision.Commands.AsyncCommand(AddMaterialToShutter);
            DeleteMaterialFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteMaterialFromShutter);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
            EditCaseCommand = new Supervision.Commands.Command(o => EditCase());
            EditSlamCommand = new Supervision.Commands.Command(o => EditSlam());
            EditShaftCommand = new Supervision.Commands.Command(o => EditShaft());
            EditPIDCommand = new Supervision.Commands.Command(o => EditPID());
        }
    }
}
