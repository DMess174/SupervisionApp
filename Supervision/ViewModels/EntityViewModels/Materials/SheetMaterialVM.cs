using DataLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.Entities.Materials;
using Supervision.Views.EntityViews.MaterialViews;
using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;
using Supervision.Commands;
using System.Threading.Tasks;
using BusinessLayer.Repository.Implementations.Entities.Material;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class SheetMaterialVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly SheetMaterialRepository sheetRepo;
        private IEnumerable<SheetMaterial> allInstances;
        private ICollectionView allInstancesView;
        private SheetMaterial selectedItem;

        private string name;
        private string number = "";
        private string sheetNumber = "";
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
                    if (obj is SheetMaterial item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string SheetNumber
        {
            get => sheetNumber;
            set
            {
                sheetNumber = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is SheetMaterial item && item.MaterialCertificateNumber != null)
                    {
                        return item.MaterialCertificateNumber.ToLower().Contains(SheetNumber.ToLower());
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
                    if (obj is SheetMaterial item && item.Batch != null)
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
                    if (obj is SheetMaterial item && item.Material != null)
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
                    if (obj is SheetMaterial item && item.Certificate != null)
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
                    if (obj is SheetMaterial item && item.Melt != null)
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

        public SheetMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SheetMaterial> AllInstances
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
                SelectedItem = await sheetRepo.AddAsync(new SheetMaterial());
                var tcpPoints = await sheetRepo.GetTCPsAsync();
                var records = new List<SheetMaterialJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new SheetMaterialJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                await sheetRepo.AddJournalRecordAsync(records);
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
                    var temp = await sheetRepo.GetByIdIncludeAsync(SelectedItem.Id);
                    var copy = await sheetRepo.AddAsync(new SheetMaterial(temp));
                    var jour = new ObservableCollection<SheetMaterialJournal>();
                    foreach (var i in temp.SheetMaterialJournals)
                    {
                        var record = new SheetMaterialJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    sheetRepo.UpdateJournalRecord(jour);
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
                _ = new SheetMaterialEditView
                {
                    DataContext = SheetMaterialEditVM.LoadSheetMaterialEditVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public static SheetMaterialVM LoadSheetMaterialVM(DataContext context)
        {
            SheetMaterialVM vm = new SheetMaterialVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<SheetMaterial>();
                AllInstances = await Task.Run(() => sheetRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public SheetMaterialVM(DataContext context)
        {
            db = context;
            sheetRepo = new SheetMaterialRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
