using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using Supervision.Commands;
using Supervision.Views.EntityViews.AssemblyUnit;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class CastGateValveVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly CastGateValveRepository repo;
        private IEnumerable<CastGateValve> allInstances;
        private ICollectionView allInstancesView;
        private CastGateValve selectedItem;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";

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
                    if (obj is CastGateValve item && item.Number != null)
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
                    if (obj is CastGateValve item && item.Drawing != null)
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
                    if (obj is CastGateValve item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
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

        public CastGateValve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CastGateValve> AllInstances
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

        public static CastGateValveVM LoadVM(DataContext context)
        {
            CastGateValveVM vm = new CastGateValveVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<CastGateValve>();
                AllInstances = await Task.Run(() => repo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
                if (AllInstances.Count() != 0)
                {
                    Name = AllInstances.First().Name;
                }
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
                SelectedItem = await repo.AddAsync(new CastGateValve());
                var tcpPoints = await repo.GetTCPsAsync();
                var coatTcp = await repo.GetCoatingTCPsAsync();
                var records = new List<CastGateValveJournal>();
                var coatRecords = new List<CoatingJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new CastGateValveJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                foreach (var tcp in coatTcp)
                {
                    var journal = new CoatingJournal(SelectedItem, tcp);
                    if (journal != null)
                        coatRecords.Add(journal);
                }
                await repo.AddJournalRecordAsync(records);
                await repo.AddCoatJournalRecordAsync(coatRecords);
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
                    var copy = await repo.AddAsync(new CastGateValve(temp));
                    var jour = new ObservableCollection<CastGateValveJournal>();
                    foreach (var i in temp.CastGateValveJournals)
                    {
                        var record = new CastGateValveJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    repo.UpdateJournalRecord(jour);
                    var coatJour = new ObservableCollection<CoatingJournal>();
                    foreach (var i in temp.CoatingJournals)
                    {
                        var record = new CoatingJournal(copy.Id, i);
                        coatJour.Add(record);
                    }
                    repo.UpdateCoatJournalRecord(coatJour);
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
                _ = new CastGateValveEditView
                {
                    DataContext = CastGateValveEditVM.LoadVM(SelectedItem.Id, SelectedItem, db)
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

        public CastGateValveVM(DataContext context)
        {
            db = context;
            repo = new CastGateValveRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
            CloseWindowCommand = new Command(o => CloseWindow(o));
        }
    }
}
