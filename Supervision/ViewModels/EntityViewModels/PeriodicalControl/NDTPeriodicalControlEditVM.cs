using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Entities.Periodical;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;

namespace Supervision.ViewModels.EntityViewModels.Periodical
{
    public class NDTPeriodicalControlEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly NDTPeriodicalRepository repo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> names;
        private IEnumerable<NDTControlTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<NDTControlJournal> journal;
        private IEnumerable<ProductType> productTypes;
        private readonly BaseTable parentEntity;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly ProductTypeRepository productTypeRepo;
        private NDTControl selectedItem;
        private NDTControlTCP selectedTCPPoint;
        private NDTControlJournal operation;

        public NDTControlJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public NDTControl SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<NDTControlJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<NDTControlTCP> Points
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
 
        public IEnumerable<string> Names
        {
            get => names;
            set
            {
                names = value;
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
        public IEnumerable<ProductType> ProductTypes
        {
            get => productTypes;
            set
            {
                productTypes = value;
                RaisePropertyChanged();
            }
        }
        public NDTControlTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public static NDTPeriodicalControlEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            NDTPeriodicalControlEditVM vm = new NDTPeriodicalControlEditVM(entity, context);
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
                ProductTypes = await Task.Run(() => productTypeRepo.GetAllAsync());
                Names = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Name));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Journal = SelectedItem.NDTControlJournals;
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
                repo.SetLastControlDate(SelectedItem);
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
                SelectedItem.NDTControlJournals.Add(new NDTControlJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                Journal = SelectedItem.NDTControlJournals;
                SelectedTCPPoint = null;
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
                        SelectedItem.NDTControlJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        Journal = SelectedItem.NDTControlJournals;
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.NDTControlJournals))
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

        public NDTPeriodicalControlEditVM(BaseTable entity, DataContext context)
        {
            parentEntity = entity;
            db = context;
            repo = new NDTPeriodicalRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            productTypeRepo = new ProductTypeRepository(db);
            LoadItemCommand = new Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
        }

        
    }
}
