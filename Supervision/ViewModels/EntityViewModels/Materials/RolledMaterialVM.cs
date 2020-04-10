using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using DataLayer.Entities.Materials;
using System.Windows;
using Supervision.Views.EntityViews.MaterialViews;
using Supervision.Commands;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer.Journals.Materials;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class RolledMaterialVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly RolledMaterialRepository materialRepo;
        private IEnumerable<RolledMaterial> allInstances;
        private ICollectionView allInstancesView;
        private RolledMaterial selectedItem;

        private string name;
        private string number = "";
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
                    if (obj is RolledMaterial item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
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
                    if (obj is RolledMaterial item && item.Batch != null)
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
                    if (obj is RolledMaterial item && item.Material != null)
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
                    if (obj is RolledMaterial item && item.Certificate != null)
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
                    if (obj is RolledMaterial item && item.Melt != null)
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

        public RolledMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<RolledMaterial> AllInstances
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
                SelectedItem = await materialRepo.AddAsync(new RolledMaterial());
                var tcpPoints = await materialRepo.GetTCPsAsync();
                var records = new List<RolledMaterialJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new RolledMaterialJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                await materialRepo.AddJournalRecordAsync(records);
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
                    var temp = await materialRepo.GetByIdIncludeAsync(SelectedItem.Id);
                    var copy = await materialRepo.AddAsync(new RolledMaterial(temp));
                    var jour = new ObservableCollection<RolledMaterialJournal>();
                    foreach (var i in temp.RolledMaterialJournals)
                    {
                        var record = new RolledMaterialJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    materialRepo.UpdateJournalRecord(jour);
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
                _ = new RolledMaterialEditView
                {
                    DataContext = RolledMaterialEditVM.LoadRolledMaterialEditVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public static RolledMaterialVM LoadRolledMaterialVM(DataContext context)
        {
            RolledMaterialVM vm = new RolledMaterialVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<RolledMaterial>();
                AllInstances = await Task.Run(() => materialRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public RolledMaterialVM(DataContext context)
        {
            db = context;
            materialRepo = new RolledMaterialRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
