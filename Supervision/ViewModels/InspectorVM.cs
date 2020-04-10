using DataLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;

namespace Supervision.ViewModels
{
    class InspectorVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly InspectorRepository repo;
        private IEnumerable<Inspector> allInstances;
        private ICollectionView allInstancesView;
        private IEnumerable<string> departments;
        private IEnumerable<string> subdivisions;
        private IEnumerable<string> apointments;
        private Inspector selectedItem;
        private string name = string.Empty;
        private string department = string.Empty;
        private string subdivision = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Name != null)
                        {
                            return insp.Name.ToLower().Contains(Name.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Department
        {
            get => department;
            set
            {
                department = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Department != null)
                        {
                            return insp.Department.ToLower().Contains(Department.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Subdivision
        {
            get => subdivision;
            set
            {
                subdivision = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Subdivision != null)
                        {
                            return insp.Subdivision.ToLower().Contains(Subdivision.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }

        public Inspector SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Inspector> AllInstances
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

        public IEnumerable<string> Departments
        {
            get => departments;
            set
            {
                departments = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> Subdivisions
        {
            get => subdivisions;
            set
            {
                subdivisions = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> Apointments
        {
            get => apointments;
            set
            {
                apointments = value;
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
                SelectedItem = await repo.AddAsync(new Inspector());
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
                Departments = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Department));
                Subdivisions = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Subdivision));
                Apointments = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Apointment));
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

        public static InspectorVM LoadVM(DataContext context)
        {
            InspectorVM vm = new InspectorVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public InspectorVM(DataContext context)
        {
            db = context;
            repo = new InspectorRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            RemoveSelectedItemCommand = new AsyncCommand(RemoveSelectedItem);
            SaveItemsCommand = new AsyncCommand(SaveItems);
        }
    }
}
