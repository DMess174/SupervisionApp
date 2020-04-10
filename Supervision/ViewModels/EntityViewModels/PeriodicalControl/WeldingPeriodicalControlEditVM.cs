using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Entities.Periodical;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;

namespace Supervision.ViewModels.EntityViewModels.Periodical
{
    public class WeldingPeriodicalControlEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly WeldingPeriodicalRepository repo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> names;
        private IEnumerable<WeldingProceduresTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<WeldingProceduresJournal> journal;
        private IEnumerable<ProductType> productTypes;
        private readonly BaseTable parentEntity;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly ProductTypeRepository productTypeRepo;
        private WeldingProcedures selectedItem;
        private WeldingProceduresTCP selectedTCPPoint;
        private WeldingProceduresJournal operation;

        public WeldingProceduresJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public WeldingProcedures SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<WeldingProceduresJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<WeldingProceduresTCP> Points
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
        public WeldingProceduresTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public static WeldingPeriodicalControlEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            WeldingPeriodicalControlEditVM vm = new WeldingPeriodicalControlEditVM(entity, context);
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
                Journal = SelectedItem.WeldingProceduresJournals;
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
                SelectedItem.WeldingProceduresJournals.Add(new WeldingProceduresJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                Journal = SelectedItem.WeldingProceduresJournals;
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
                        SelectedItem.WeldingProceduresJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        Journal = SelectedItem.WeldingProceduresJournals;
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.WeldingProceduresJournals))
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

        public WeldingPeriodicalControlEditVM(BaseTable entity, DataContext context)
        {
            parentEntity = entity;
            db = context;
            repo = new WeldingPeriodicalRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            productTypeRepo = new ProductTypeRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
        }


    }
}
