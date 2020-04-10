using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Supervision.Commands;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class FactoryInspectionVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly FactoryInspectionRepository repo;
        private readonly JournalNumberRepository journalRepo;
        private readonly InspectorRepository inspectorRepo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<FactoryInspectionTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<FactoryInspectionJournal> journal;
        private FactoryInspectionTCP selectedTCPPoint;
        private FactoryInspectionJournal operation;

        public FactoryInspectionJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<FactoryInspectionJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<FactoryInspectionTCP> Points
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

        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public FactoryInspectionTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand LoadItemsCommand { get; private set; }
        public async Task Load()
        {
            try
            {
                IsBusy = true;
                Journal = await Task.Run(() => repo.GetAllAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Points = await Task.Run(() => repo.GetTCPsAsync());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => repo.Update(Journal));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                await repo.AddAsync(new FactoryInspectionJournal(SelectedTCPPoint));
                SelectedTCPPoint = null;
            }
        }

        public IAsyncCommand RemoveOperationCommand { get; private set; }
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
                        await repo.RemoveAsync(Operation);
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
            if (repo.HasChanges(Journal))
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

        public static FactoryInspectionVM LoadVM(DataContext context)
        {
            FactoryInspectionVM vm = new FactoryInspectionVM(context);
            vm.LoadItemsCommand.ExecuteAsync();
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }


        public FactoryInspectionVM(DataContext context)
        {
            db = context;
            repo = new FactoryInspectionRepository(db);
            journalRepo = new JournalNumberRepository(db);
            inspectorRepo = new InspectorRepository(db);
            LoadItemsCommand = new AsyncCommand(Load);
            SaveItemCommand = new AsyncCommand(SaveItem);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            AddOperationCommand = new AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new AsyncCommand(RemoveOperation);
        }
    }
}
