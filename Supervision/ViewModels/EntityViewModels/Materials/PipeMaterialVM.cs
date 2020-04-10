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
    public class PipeMaterialVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly PipeMaterialRepository materialRepo;
        private IEnumerable<PipeMaterial> allInstances;
        private ICollectionView allInstancesView;
        private PipeMaterial selectedItem;

        private string name;
        private string number = "";
        private string pipeNumber = "";
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
                    if (obj is PipeMaterial item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string PipeNumber
        {
            get => pipeNumber;
            set
            {
                pipeNumber = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is PipeMaterial item && item.MaterialCertificateNumber != null)
                    {
                        return item.MaterialCertificateNumber.ToLower().Contains(PipeNumber.ToLower());
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
                    if (obj is PipeMaterial item && item.Status != null)
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
                    if (obj is PipeMaterial item && item.Material != null)
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
                    if (obj is PipeMaterial item && item.Certificate != null)
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
                    if (obj is PipeMaterial item && item.Melt != null)
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

        public PipeMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<PipeMaterial> AllInstances
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
                SelectedItem = await materialRepo.AddAsync(new PipeMaterial());
                var tcpPoints = await materialRepo.GetTCPsAsync();
                var records = new List<PipeMaterialJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new PipeMaterialJournal(SelectedItem, tcp);
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
                    var copy = await materialRepo.AddAsync(new PipeMaterial(temp));
                    var jour = new ObservableCollection<PipeMaterialJournal>();
                    foreach (var i in temp.PipeMaterialJournals)
                    {
                        var record = new PipeMaterialJournal(copy.Id, i);
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
                _ = new PipeMaterialEditView
                {
                    DataContext = PipeMaterialEditVM.LoadPipeMaterialEditVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public static PipeMaterialVM LoadPipeMaterialVM(DataContext context)
        {
            PipeMaterialVM vm = new PipeMaterialVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<PipeMaterial>();
                AllInstances = await Task.Run(() => materialRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public PipeMaterialVM(DataContext context)
        {
            db = context;
            materialRepo = new PipeMaterialRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
