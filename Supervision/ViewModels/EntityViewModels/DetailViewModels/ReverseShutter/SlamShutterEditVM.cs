using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class SlamShutterEditVM : ViewModelBase
    {
        private readonly BaseTable parentEntity;
        private readonly SlamShutterRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<SlamShutterTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SlamShutterJournal> inputControlJournal;
        private IEnumerable<SlamShutterJournal> inputNDTControlJournal;
        private IEnumerable<SlamShutterJournal> mechanicalJournal;
        private IEnumerable<SlamShutterJournal> overlayingJournal;

        private SlamShutter selectedItem;
        private SlamShutterTCP selectedTCPPoint;
        private SlamShutterJournal operation;

        public SlamShutterJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public SlamShutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SlamShutterJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> OverlayingJournal
        {
            get => overlayingJournal;
            set
            {
                overlayingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterTCP> Points
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

        public SlamShutterTCP SelectedTCPPoint
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

        public static SlamShutterEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            SlamShutterEditVM vm = new SlamShutterEditVM(entity, context);
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
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Materials = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Material));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                InputControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                OverlayingJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
                SelectedItem.SlamShutterJournals.Add(new SlamShutterJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                InputControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                OverlayingJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
                        SelectedItem.SlamShutterJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        InputControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                        InputNDTControlJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                        MechanicalJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                        OverlayingJournal = SelectedItem.SlamShutterJournals.Where(i => i.EntityTCP.OperationType.Name == "Наплавка").OrderBy(x => x.PointId);
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.SlamShutterJournals))
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

        public SlamShutterEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new SlamShutterRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
        }
    }
}
