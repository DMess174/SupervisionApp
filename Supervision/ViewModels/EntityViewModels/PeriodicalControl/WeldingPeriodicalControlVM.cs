using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Entities.Periodical;
using Supervision.Commands;
using Supervision.Views.EntityViews.PeriodicalControl;

namespace Supervision.ViewModels.EntityViewModels.Periodical
{
    public class WeldingPeriodicalControlVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly WeldingPeriodicalRepository repo;
        private IEnumerable<WeldingProcedures> allInstances;
        private ICollectionView allInstancesView;
        private WeldingProcedures selectedItem;
        private string name = "";
        private string status = "";
        private string productType = "";

        #region Filter
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is WeldingProcedures item && item.Name != null)
                    {
                        return item.Name.ToLower().Contains(Name.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Status
        {
            get => status;
            set
            {
                status = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is WeldingProcedures item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string ProductType
        {
            get => productType;
            set
            {
                productType = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is WeldingProcedures item && item.ProductType.Name != null)
                    {
                        return item.ProductType.Name.ToLower().Contains(ProductType.ToLower());
                    }
                    else return true;
                };
            }
        }
        #endregion

        public WeldingProcedures SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<WeldingProcedures> AllInstances
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

        public IAsyncCommand AddNewItemCommand { get; private set; }
        private async Task AddNewItem()
        {
            try
            {
                IsBusy = true;
                SelectedItem = await repo.AddAsync(new WeldingProcedures());
                EditSelectedItem();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand RemoveSelectedItemCommand { get; private set; }

        public ICommand EditSelectedItemCommand { get; private set; }
        private void EditSelectedItem()
        {
            if (SelectedItem != null)
            {
                _ = new PeriodicalControlEditView
                {
                    DataContext = WeldingPeriodicalControlEditVM.LoadVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        protected override void CloseWindow(object obj)
        {
            Window w = obj as Window;
            w?.Close();
        }

        private bool CanExecute()
        {
            return true;
        }

        public static WeldingPeriodicalControlVM LoadVM(DataContext context)
        {
            WeldingPeriodicalControlVM vm = new WeldingPeriodicalControlVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public WeldingPeriodicalControlVM(DataContext context)
        {
            db = context;
            repo = new WeldingPeriodicalRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
            CloseWindowCommand = new Command(o => CloseWindow(o));
        }



    }
}
