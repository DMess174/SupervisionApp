using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
using DataLayer.Journals;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;

namespace Supervision.ViewModels.TCPViewModels
{
    public class JournalNumbersViewModel : ViewModelBase
    {
        private readonly DataContext db;
        private readonly JournalNumberRepository repo;
        private IEnumerable<JournalNumber> allInstances;
        private ICollectionView allInstancesView;
        private JournalNumber selectedPoint;

        public JournalNumber SelectedPoint
        {
            get => selectedPoint;
            set
            {
                selectedPoint = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<JournalNumber> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged();
            }
        }

        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand SaveItemsCommand { get; private set; }
        private async Task SaveItems()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => repo.Update(AllInstances));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand AddNewItemCommand { get; private set; }
        private async Task AddNewItem()
        {
            try
            {
                IsBusy = true;
                await repo.AddAsync(new JournalNumber());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = await Task.Run(() => repo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(AllInstances))
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

        public static JournalNumbersViewModel LoadVM(DataContext context)
        {
            JournalNumbersViewModel vm = new JournalNumbersViewModel(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public JournalNumbersViewModel(DataContext context)
        {
            db = context;
            repo = new JournalNumberRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            SaveItemsCommand = new AsyncCommand(SaveItems);
        }
    }
}
