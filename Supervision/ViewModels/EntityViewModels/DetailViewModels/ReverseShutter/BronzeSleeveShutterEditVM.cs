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
    public class BronzeSleeveShutterEditVM : ViewModelBase
    {
        private readonly BaseTable parentEntity;
        private readonly BronzeSleeveShutterRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<BronzeSleeveShutterTCP> points;
        private IEnumerable<Inspector> inspectors;

        private BronzeSleeveShutter selectedItem;
        private BronzeSleeveShutterTCP selectedTCPPoint;
        private BronzeSleeveShutterJournal operation;

        public BronzeSleeveShutterJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public BronzeSleeveShutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<BronzeSleeveShutterTCP> Points
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

        public BronzeSleeveShutterTCP SelectedTCPPoint
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

        public static BronzeSleeveShutterEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            BronzeSleeveShutterEditVM vm = new BronzeSleeveShutterEditVM(entity, context);
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
                SelectedItem.BronzeSleeveShutterJournals.Add(new BronzeSleeveShutterJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
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
                        SelectedItem.BronzeSleeveShutterJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.BronzeSleeveShutterJournals))
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

        public BronzeSleeveShutterEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new BronzeSleeveShutterRepository(db);
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
