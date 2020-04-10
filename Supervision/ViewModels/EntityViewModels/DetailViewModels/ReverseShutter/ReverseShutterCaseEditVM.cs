using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using Supervision.Commands;
using Supervision.Views.EntityViews.DetailViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class ReverseShutterCaseEditVM : ViewModelBase
    {
        private readonly BaseTable parentEntity;
        private readonly ReverseShutterCaseRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly NozzleRepository nozzleRepo;
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ReverseShutterCaseTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ReverseShutterCaseJournal> inputControlJournal;
        private IEnumerable<ReverseShutterCaseJournal> inputNDTControlJournal;
        private IEnumerable<ReverseShutterCaseJournal> mechanicalJournal;
        private IEnumerable<ReverseShutterCaseJournal> assemblyJournal;
        private IEnumerable<ReverseShutterCaseJournal> nDTJournal;
        private IEnumerable<ReverseShutterCaseJournal> overlayingJournal;

        private ReverseShutterCase selectedItem;
        private IEnumerable<Nozzle> nozzles;
        private Nozzle selectedNozzle;
        private Nozzle selectedNozzleFromList;
        private ReverseShutterCaseTCP selectedTCPPoint;
        private ReverseShutterCaseJournal operation;

        public ReverseShutterCaseJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterCase SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ReverseShutterCaseJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> OverlayingJournal
        {
            get => overlayingJournal;
            set
            {
                overlayingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseTCP> Points
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

        public Nozzle SelectedNozzle
        {
            get => selectedNozzle;
            set
            {
                selectedNozzle = value;
                RaisePropertyChanged();
            }
        }

        public Nozzle SelectedNozzleFromList
        {
            get => selectedNozzleFromList;
            set
            {
                selectedNozzleFromList = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterCaseTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
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

        public IEnumerable<Nozzle> Nozzles
        {
            get => nozzles;
            set
            {
                nozzles = value;
                RaisePropertyChanged();
            }
        }

        public Supervision.Commands.IAsyncCommand AddNozzleToCaseCommand { get; private set; }
        private async Task AddNozzleToCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.Nozzles?.Count() < 2 || SelectedItem.Nozzles == null)
                {
                    if (SelectedNozzle != null)
                    {
                        if (!await nozzleRepo.IsAssembliedAsync(SelectedNozzle))
                        {
                            SelectedNozzle.CastingCaseId = SelectedItem.Id;
                            nozzleRepo.Update(SelectedNozzle);
                            SelectedNozzle = null;
                            Nozzles = nozzleRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 катушек!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteNozzleFromCaseCommand { get; private set; }
        private async Task DeleteNozzleFromCase()
        {
            try
            {
                IsBusy = true;
                if (SelectedNozzleFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedNozzleFromList.CastingCaseId = null;
                        nozzleRepo.Update(SelectedNozzleFromList);
                        Nozzles = nozzleRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditNozzleCommand { get; private set; }
        private void EditNozzle()
        {
            if (SelectedNozzleFromList != null)
            {
                _ = new NozzleEditView
                {
                    DataContext = NozzleEditVM.LoadVM(SelectedNozzleFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public static ReverseShutterCaseEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ReverseShutterCaseEditVM vm = new ReverseShutterCaseEditVM(entity, context);
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
                await Task.Run(() => nozzleRepo.Load());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Materials = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Material));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Nozzles = await Task.Run(() => nozzleRepo.UpdateList());
                InputControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                OverlayingJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
                SelectedItem.ReverseShutterCaseJournals.Add(new ReverseShutterCaseJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                InputControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                OverlayingJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
                        SelectedItem.ReverseShutterCaseJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        InputControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                        InputNDTControlJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                        MechanicalJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                        AssemblyJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                        NDTJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                        OverlayingJournal = SelectedItem.ReverseShutterCaseJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.ReverseShutterCaseJournals))
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

        public ReverseShutterCaseEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new ReverseShutterCaseRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            nozzleRepo = new NozzleRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            AddNozzleToCaseCommand = new AsyncCommand(AddNozzleToCase);
            DeleteNozzleFromCaseCommand = new Supervision.Commands.AsyncCommand(DeleteNozzleFromCase);
            EditNozzleCommand = new Supervision.Commands.Command(o => EditNozzle());
        }
    }
}
