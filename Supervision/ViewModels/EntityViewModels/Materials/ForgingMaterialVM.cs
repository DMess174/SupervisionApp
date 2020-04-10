using DataLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.Entities.Materials;
using Supervision.Views.EntityViews.MaterialViews;
using DataLayer.Journals.Materials;
using BusinessLayer.Repository.Implementations.Entities.Material;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Supervision.Commands;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class ForgingMaterialVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly ForgingMaterialRepository forgingRepo;
        private IEnumerable<ForgingMaterial> allInstances;
        private ICollectionView allInstancesView;
        private ForgingMaterial selectedItem;

        private string name;
        private string number = "";
        private string metalCharge = "";
        private string batch = "";
        private string material = "";
        private string certificate = "";
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
                    if (obj is ForgingMaterial item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string MetalCharge
        {
            get => metalCharge;
            set
            {
                metalCharge = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ForgingMaterial item && item.MetalCharge != null)
                    {
                        return item.MetalCharge.ToLower().Contains(MetalCharge.ToLower());
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
                    if (obj is ForgingMaterial item && item.Batch != null)
                    {
                        return item.Batch.ToLower().Contains(Batch.ToLower());
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
                material= value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is ForgingMaterial item && item.Material != null)
                    {
                        return item.Material.ToLower().Contains(Material.ToLower());
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
                    if (obj is ForgingMaterial item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
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
                    if (obj is ForgingMaterial item && item.Melt != null)
                    {
                        return item.Melt.ToLower().Contains(Melt.ToLower());
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

        public ForgingMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ForgingMaterial> AllInstances
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
                SelectedItem = await forgingRepo.AddAsync(new ForgingMaterial());
                var tcpPoints = await forgingRepo.GetTCPsAsync();
                var records = new List<ForgingMaterialJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new ForgingMaterialJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                await forgingRepo.AddJournalRecordAsync(records);
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
                    var temp = await forgingRepo.GetByIdIncludeAsync(SelectedItem.Id);
                    var copy = await forgingRepo.AddAsync(new ForgingMaterial(temp));
                    var jour = new ObservableCollection<ForgingMaterialJournal>();
                    foreach (var i in temp.ForgingMaterialJournals)
                    {
                        var record = new ForgingMaterialJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    forgingRepo.UpdateJournalRecord(jour);
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
                _ = new ForgingMaterialEditView
                {
                    DataContext = ForgingMaterialEditVM.LoadForgingMaterialEditVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public static ForgingMaterialVM LoadForgingMaterialVM(DataContext context)
        {
            ForgingMaterialVM vm = new ForgingMaterialVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<ForgingMaterial>();
                AllInstances = await Task.Run(() => forgingRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ForgingMaterialVM(DataContext context)
        {
            db = context;
            forgingRepo = new ForgingMaterialRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
