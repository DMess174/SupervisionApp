using System.Collections.Generic;
using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Supervision.ViewModels
{
    class CustomerVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly CustomerRepository customerRepo;
        private IEnumerable<Customer> allInstances;
        private ICollectionView allInstancesView;
        private Customer selectedItem;

        public Customer SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Customer> AllInstances
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
                await Task.Run(() => customerRepo.Update(AllInstances));
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
                SelectedItem = await customerRepo.AddAsync(new Customer());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand RemoveSelectedItemCommand { get; private set; }
        private async Task RemoveSelectedItem()
        {
            if (SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        IsBusy = true;
                        await customerRepo.RemoveAsync(SelectedItem);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }


        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<Customer>();
                AllInstances = await Task.Run(() => customerRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (customerRepo.HasChanges(AllInstances))
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

        public static CustomerVM LoadCustomerVM(DataContext context)
        {
            CustomerVM vm = new CustomerVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public CustomerVM(DataContext context)
        {
            db = context;
            customerRepo = new CustomerRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            RemoveSelectedItemCommand = new AsyncCommand(RemoveSelectedItem);
            SaveItemsCommand = new AsyncCommand(SaveItems);
        }
    }
}
