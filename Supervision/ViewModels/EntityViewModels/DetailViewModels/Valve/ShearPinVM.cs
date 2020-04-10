using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using Supervision.Commands;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class ShearPinVM : ViewModelBase
    {
        private readonly DataContext db;
        private IList<ShearPin> allInstances;
        private ICollectionView allInstancesView;
        private ShearPin selectedItem;
        private readonly ShearPinRepository repo;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";
        private string certificate = "";
        private string material = "";
        private string melt = "";

        #region Filter
        public string Number
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ShearPin item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Drawing
        {
            get => drawing;
            set
            {
                drawing = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ShearPin item && item.Drawing != null)
                    {
                        return item.Drawing.ToLower().Contains(Drawing.ToLower());
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
                    if (obj is ShearPin item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Material
        {
            get => material;
            set
            {
                material = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ShearPin item && item.Material != null)
                    {
                        return item.Material.ToLower().Contains(Material.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Melt
        {
            get => melt;
            set
            {
                melt = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ShearPin item && item.Melt != null)
                    {
                        return item.Melt.ToLower().Contains(Melt.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Certificate
        {
            get => certificate;
            set
            {
                certificate = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ShearPin item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
                    }
                    else return true;
                };
            }
        }
        #endregion

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public ShearPin SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IList<ShearPin> AllInstances
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

        public static ShearPinVM LoadVM(DataContext context)
        {
            ShearPinVM vm = new ShearPinVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<ShearPin>();
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
                SelectedItem = await repo.AddAsync(new ShearPin());
                var tcpPoints = await repo.GetTCPsAsync();
                var records = new List<ShearPinJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new ShearPinJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                await repo.AddJournalRecordAsync(records);
                EditSelectedItem();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand CopySelectedItemCommand { get; private set; }
        private async Task CopySelectedItem()
        {
            if (SelectedItem != null)
            {
                try
                {
                    IsBusy = true;
                    var temp = await repo.GetByIdIncludeAsync(SelectedItem.Id);
                    var copy = await repo.AddAsync(new ShearPin(temp));
                    var jour = new ObservableCollection<ShearPinJournal>();
                    foreach (var i in temp.ShearPinJournals)
                    {
                        var record = new ShearPinJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    repo.UpdateJournalRecord(jour);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        public IAsyncCommand RemoveSelectedItemCommand { get; private set; }

        public ICommand EditSelectedItemCommand { get; private set; }
        private void EditSelectedItem()
        {
            if (SelectedItem != null)
            {
                _ = new ShearPinEditView
                {
                    DataContext = ShearPinEditVM.LoadVM(SelectedItem.Id, SelectedItem, db)
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

        public ShearPinVM(DataContext context)
        {
            db = context;
            repo = new ShearPinRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
            CloseWindowCommand = new Command(o => CloseWindow(o));
        }
    }
}
