using System.Collections.Generic;
using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;

namespace Supervision.ViewModels
{
    class ProductTypeViewModel : ViewModelBase
    {
        private DataContext db;
        private readonly ProductTypeRepository repo;
        private IEnumerable<ProductType> allInstances;
        private ICollectionView allInstancesView;
        private ProductType selectedItem;

        public ProductType SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ProductType> AllInstances
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
                SelectedItem = await repo.AddAsync(new ProductType());
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
                        await repo.RemoveAsync(SelectedItem);
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

        public static ProductTypeViewModel LoadVM(DataContext context)
        {
            ProductTypeViewModel vm = new ProductTypeViewModel(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public ProductTypeViewModel(DataContext context)
        {
            db = context;
            repo = new ProductTypeRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            RemoveSelectedItemCommand = new AsyncCommand(RemoveSelectedItem);
            SaveItemsCommand = new AsyncCommand(SaveItems);
        }
    }
}
