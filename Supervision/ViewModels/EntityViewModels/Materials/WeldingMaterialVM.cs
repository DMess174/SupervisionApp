using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using Supervision.Commands;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class WeldingMaterialVM : ViewModelBase
    { 
        private readonly DataContext db;
        private readonly WeldingMaterialRepository repo;
        private IEnumerable<WeldingMaterial> allInstances;
        private ICollectionView allInstancesView;
        private WeldingMaterial selectedItem;

        private string name;
        private string number = "";
        private string status = "";
        private string certificate = "";
        private string batch = "";

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
                    if (obj is WeldingMaterial item && item.Name != null)
                    {
                        return item.Name.ToLower().Contains(Number.ToLower());
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
                    if (obj is WeldingMaterial item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
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
                    if (obj is WeldingMaterial item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Batch
        {
            get => batch;
            set
            {
                batch = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is WeldingMaterial item && item.Batch != null)
                    {
                        return item.Batch.ToLower().Contains(Batch.ToLower());
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

        public WeldingMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<WeldingMaterial> AllInstances
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

        public IAsyncCommand AddNewItemCommand { get; private set; }
        private async Task AddNewItem()
        {
            try
            {
                IsBusy = true;
                SelectedItem = await repo.AddAsync(new WeldingMaterial());
                var tcpPoints = await repo.GetTCPsAsync();
                var records = new List<WeldingMaterialJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new WeldingMaterialJournal(SelectedItem, tcp);
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
                    var copy = await repo.AddAsync(new WeldingMaterial(temp));
                    var jour = new ObservableCollection<WeldingMaterialJournal>();
                    foreach (var i in temp.WeldingMaterialJournals)
                    {
                        var record = new WeldingMaterialJournal(copy.Id, i);
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
                _ = new WeldingMaterialEditView
                {
                    DataContext = WeldingMaterialEditVM.LoadVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public static WeldingMaterialVM LoadVM(DataContext context)
        {
            WeldingMaterialVM vm = new WeldingMaterialVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<WeldingMaterial>();
                AllInstances = await Task.Run(() => repo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public WeldingMaterialVM(DataContext context)
        {
            db = context;
            repo = new WeldingMaterialRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
