using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans;
using Supervision.Commands;
using System.Threading.Tasks;
using BusinessLayer.Repository.Implementations.Entities;

namespace Supervision.ViewModels.TCPViewModels
{
    class TCPViewModel<TEntityTCP> : ViewModelBase
        where TEntityTCP : BaseTCP, new()
    {
        private readonly DataContext db;
        private readonly TCPRepository<TEntityTCP> repo;
        private readonly ProductTypeRepository productTypeRepo;
        private readonly OperationTypeRepository operationTypeRepo;
        private IEnumerable<ProductType> productTypes;
        private IEnumerable<OperationType> operationTypes;
        private IEnumerable<TEntityTCP> tCPs;
        private ICollectionView tCPsView;
        private TEntityTCP selectedPoint;

        public TEntityTCP SelectedPoint
        {
            get => selectedPoint;
            set
            {
                selectedPoint = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<TEntityTCP> TCPs
        {
            get => tCPs;
            set
            {
                tCPs = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<OperationType> OperationTypes
        {
            get => operationTypes;
            set
            {
                operationTypes = value;
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

        public ICollectionView TCPsView
        {
            get => tCPsView;
            set
            {
                tCPsView = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand SaveItemsCommand { get; private set; }
        private async Task SaveItems()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => repo.Update(TCPs));
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
                SelectedPoint = await repo.AddAsync(new TEntityTCP());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand RemoveSelectedItemCommand { get; private set; }
        private async Task RemoveSelectedItem()
        {
            if (SelectedPoint != null)
            {
                MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        IsBusy = true;
                        await repo.RemoveAsync(SelectedPoint);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(TCPs))
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

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                TCPs = await Task.Run(() => repo.GetAllAsync());
                ProductTypes = await Task.Run(() => productTypeRepo.GetAllAsync());
                OperationTypes = await Task.Run(() => operationTypeRepo.GetAllAsync());
                TCPsView = CollectionViewSource.GetDefaultView(TCPs);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public static TCPViewModel<T> LoadVM<T>(DataContext context) where T : BaseTCP, new()
        {
            TCPViewModel<T> vm = new TCPViewModel<T>(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public TCPViewModel(DataContext context)
        {
            db = context;
            repo = new TCPRepository<TEntityTCP>(db);
            productTypeRepo = new ProductTypeRepository(db);
            operationTypeRepo = new OperationTypeRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            RemoveSelectedItemCommand = new AsyncCommand(RemoveSelectedItem);
            SaveItemsCommand = new AsyncCommand(SaveItems);
        }
    }
}
