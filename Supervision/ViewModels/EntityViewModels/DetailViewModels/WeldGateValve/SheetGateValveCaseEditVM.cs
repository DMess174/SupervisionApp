using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class SheetGateValveCaseEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CaseFlange> caseFlanges;
        private IEnumerable<CaseBottom> caseBottoms;
        private IEnumerable<FrontWall> frontWalls;
        private IEnumerable<WeldNozzle> weldNozzles;
        private IEnumerable<CaseEdge> caseEdges;
        private FrontWall selectedFrontWall;
        private FrontWall selectedFrontWallFromList;
        private CaseEdge selectedEdge;
        private CaseEdge selectedEdgeFromList;
        private WeldNozzle selectedWeldNozzleFromList;
        private ICommand editWeldNozzle;
        private IEnumerable<SideWall> sideWalls;
        private SideWall selectedSideWall;
        private SideWall selectedSideWallFromList;
        private IEnumerable<string> drawings;
        private IEnumerable<SheetGateValveCaseTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SheetGateValveCaseJournal> assemblyJournal;
        private IEnumerable<SheetGateValveCaseJournal> mechanicalJournal;
        private IEnumerable<SheetGateValveCaseJournal> nDTJournal;
        private readonly BaseTable parentEntity;
        private readonly SheetGateValveCaseRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly CaseFlangeRepository caseFlangeRepo;
        private readonly CaseBottomRepository caseBottomRepo;
        private readonly FrontWallRepository frontWallRepo;
        private readonly SideWallRepository sideWallRepo;
        private readonly CaseEdgeRepository caseEdgeRepo;
        private SheetGateValveCase selectedItem;
        private SheetGateValveCaseTCP selectedTCPPoint;
        private SheetGateValveCaseJournal operation;

        public SheetGateValveCaseJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public SheetGateValveCase SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SheetGateValveCaseJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCaseJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCaseJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCaseTCP> Points
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

        public FrontWall SelectedFrontWall
        {
            get => selectedFrontWall;
            set
            {
                selectedFrontWall	= value;
                RaisePropertyChanged();
            }
        }

        public FrontWall SelectedFrontWallFromList
        {
            get => selectedFrontWallFromList;
            set
            {
                selectedFrontWallFromList = value;
                RaisePropertyChanged();
            }
        }

        public CaseEdge SelectedEdge
        {
            get => selectedEdge;
            set
            {
                selectedEdge = value;
                RaisePropertyChanged();
            }
        }

        public CaseEdge SelectedEdgeFromList
        {
            get => selectedEdgeFromList;
            set
            {
                selectedEdgeFromList = value;
                RaisePropertyChanged();
            }
        }

        public SideWall SelectedSideWall
        {
            get => selectedSideWall;
            set
            {
                selectedSideWall = value;
                RaisePropertyChanged();
            }
        }

        public SideWall SelectedSideWallFromList
        {
            get => selectedSideWallFromList	;
            set
            {
                selectedSideWallFromList	 = value;
                RaisePropertyChanged();
            }
        }

        public WeldNozzle SelectedWeldNozzleFromList
        {
            get => selectedWeldNozzleFromList;
            set
            {
                selectedWeldNozzleFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand EditWeldNozzle
        {
            get
            {
                return editWeldNozzle ?? (
                           editWeldNozzle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedWeldNozzleFromList != null)
                               {
                                   _ = new WeldNozzleEditView
                                   {
                                       DataContext = WeldNozzleEditVM.LoadVM(SelectedWeldNozzleFromList.Id, SelectedItem, db)
                                   };
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<CaseFlange> CaseFlanges
        {
            get => caseFlanges;
            set
            {
                caseFlanges = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CaseBottom> CaseBottoms
        {
            get => caseBottoms;
            set
            {
                caseBottoms = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<FrontWall> FrontWalls
        {
            get => frontWalls;
            set
            {
                frontWalls = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SideWall> SideWalls
        {
            get => sideWalls;
            set
            {
                sideWalls = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<WeldNozzle> WeldNozzles
        {
            get => weldNozzles;
            set
            {
                weldNozzles = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CaseEdge> CaseEdges
        {
            get => caseEdges;
            set
            {
                caseEdges = value;
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

        public SheetGateValveCaseTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.SheetGateValveCaseJournals))
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
                await Task.Run(() => caseEdgeRepo.Load());
                await Task.Run(() => frontWallRepo.Load());
                await Task.Run(() => sideWallRepo.Load());
                CaseFlanges = await Task.Run(() => caseFlangeRepo.GetAllAsync());
                CaseBottoms = await Task.Run(() => caseBottomRepo.GetAllAsync());
                CaseEdges = caseEdgeRepo.UpdateList();
                FrontWalls = frontWallRepo.UpdateList();
                SideWalls = sideWallRepo.UpdateList();
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                AssemblyJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditCaseFlangeCommand { get; private set; }
        private void EditCaseFlange()
        {
            if (SelectedItem.CaseFlange != null)
            {
                _ = new CaseFlangeEditView
                {
                    DataContext = CaseFlangeEditVM.LoadVM(SelectedItem.CaseFlange.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
        }

        public ICommand EditCaseBottomCommand { get; private set; }
        private void EditCaseBottom()
        {
            if (SelectedItem.CaseBottom != null)
            {
                _ = new CaseBottomEditView
                {
                    DataContext = CaseBottomEditVM.LoadVM(SelectedItem.CaseBottom.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.CaseFlangeId != null)
                {
                    if (await Task.Run(() => caseFlangeRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.CaseFlange = null;
                    }
                }
                if (SelectedItem.CaseBottomId != null)
                {
                    if (await Task.Run(() => caseBottomRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.CaseBottom = null;
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
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.SheetGateValveCaseJournals.Add(new SheetGateValveCaseJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                AssemblyJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
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
                        SelectedItem.SheetGateValveCaseJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        AssemblyJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                        MechanicalJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                        NDTJournal = SelectedItem.SheetGateValveCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddFrontWallToCaseCommand { get; private set; }
        private async Task AddFrontWallToCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.FrontWalls?.Count() < 2 || SelectedItem.FrontWalls == null)
                {
                    if (SelectedFrontWall != null)
                    {
                        if (!await frontWallRepo.IsAssembliedAsync(SelectedFrontWall))
                        {
                            SelectedFrontWall.WeldGateValveCaseId = SelectedItem.Id;
                            frontWallRepo.Update(SelectedFrontWall);
                            SelectedFrontWall = null;
                            FrontWalls = frontWallRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteFrontWallFromCaseCommand { get; private set; }
        private async Task DeleteFrontWallFromCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedFrontWallFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedFrontWallFromList.WeldGateValveCaseId = null;
                        frontWallRepo.Update(SelectedFrontWallFromList);
                        FrontWalls = frontWallRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditFrontWallCommand { get; private set; }
        private void EditFrontWall()
        {
            if (SelectedFrontWallFromList != null)
            {
                _ = new FrontWallEditView
                {
                    DataContext = FrontWallEditVM.LoadVM(SelectedFrontWallFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddSideWallToCaseCommand { get; private set; }
        private async Task AddSideWallToCase()
        {
            try
            {
                if (SelectedItem.SideWalls?.Count() < 2 || SelectedItem.SideWalls == null)
                {
                    if (SelectedSideWall != null)
                    {
                        IsBusy = true;
                        if (!await sideWallRepo.IsAssembliedAsync(SelectedSideWall))
                        {
                            SelectedSideWall.WeldGateValveCaseId = SelectedItem.Id;
                            sideWallRepo.Update(SelectedSideWall);
                            SelectedSideWall = null;
                            SideWalls = sideWallRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteSideWallFromCaseCommand { get; private set; }
        private async Task DeleteSideWallFromCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedSideWallFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedSideWallFromList.WeldGateValveCaseId = null;
                        sideWallRepo.Update(SelectedSideWallFromList);
                        SideWalls = sideWallRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSideWallCommand { get; private set; }
        private void EditSideWall()
        {
            if (SelectedSideWallFromList != null)
            {
                _ = new SideWallEditView
                {
                    DataContext = SideWallEditVM.LoadVM(SelectedSideWallFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddEdgeToCaseCommand { get; private set; }
        private async Task AddEdgeToCase()
        {
            try
            {
                if (SelectedEdge != null)
                {
                    IsBusy = true;
                    if (!await caseEdgeRepo.IsAssembliedAsync(SelectedEdge))
                    {
                        SelectedEdge.WeldGateValveCaseId = SelectedItem.Id;
                        caseEdgeRepo.Update(SelectedEdge);
                        SelectedEdge = null;
                        CaseEdges = caseEdgeRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteEdgeFromCaseCommand { get; private set; }
        private async Task DeleteEdgeFromCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedEdgeFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedEdgeFromList.WeldGateValveCaseId = null;
                        caseEdgeRepo.Update(SelectedEdgeFromList);
                        CaseEdges = caseEdgeRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditEdgeCommand { get; private set; }
        private void EditEdge()
        {
            if (SelectedEdgeFromList != null)
            {
                _ = new CaseEdgeEditView
                {
                    DataContext = CaseEdgeEditVM.LoadVM(SelectedEdgeFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public static SheetGateValveCaseEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            SheetGateValveCaseEditVM vm = new SheetGateValveCaseEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        public SheetGateValveCaseEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new SheetGateValveCaseRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            caseFlangeRepo = new CaseFlangeRepository(db);
            caseBottomRepo = new CaseBottomRepository(db);
            frontWallRepo = new FrontWallRepository(db);
            sideWallRepo = new SideWallRepository(db);
            caseEdgeRepo = new CaseEdgeRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditCaseBottomCommand = new Supervision.Commands.Command(o => EditCaseBottom());
            EditCaseFlangeCommand = new Supervision.Commands.Command(o => EditCaseFlange());
            AddFrontWallToCaseCommand = new Supervision.Commands.AsyncCommand(AddFrontWallToCase);
            DeleteFrontWallFromCaseCommand = new Supervision.Commands.AsyncCommand(DeleteFrontWallFromCase);
            EditFrontWallCommand = new Supervision.Commands.Command(o => EditFrontWall());
            AddSideWallToCaseCommand = new Supervision.Commands.AsyncCommand(AddSideWallToCase);
            DeleteSideWallFromCaseCommand = new Supervision.Commands.AsyncCommand(DeleteSideWallFromCase);
            EditSideWallCommand = new Supervision.Commands.Command(o => EditSideWall());
            AddEdgeToCaseCommand = new Supervision.Commands.AsyncCommand(AddEdgeToCase);
            DeleteEdgeFromCaseCommand = new Supervision.Commands.AsyncCommand(DeleteEdgeFromCase);
            EditEdgeCommand = new Supervision.Commands.Command(o => EditEdge());
        }
    }
}
