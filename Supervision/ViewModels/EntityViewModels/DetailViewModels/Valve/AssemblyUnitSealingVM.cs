﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using Supervision.Commands;
using Supervision.Views.EntityViews.DetailViews.Valve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class AssemblyUnitSealingVM : ViewModelBase
    {
        private readonly AssemblyUnitSealingRepository sealRepo;
        private readonly DataContext db;
        private IEnumerable<AssemblyUnitSealing> allInstances;
        private ICollectionView allInstancesView;
        private AssemblyUnitSealing selectedItem;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";
        private string certificate = "";
        private string material = "";
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
                    if (obj is AssemblyUnitSealing item && item.Number != null)
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
                    if (obj is AssemblyUnitSealing item && item.Drawing != null)
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
                    if (obj is AssemblyUnitSealing item && item.Status != null)
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
                    if (obj is AssemblyUnitSealing item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
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
                    if (obj is AssemblyUnitSealing item && item.Material != null)
                    {
                        return item.Material.ToLower().Contains(Material.ToLower());
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
                    if (obj is AssemblyUnitSealing item && item.Batch != null)
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

        public AssemblyUnitSealing SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<AssemblyUnitSealing> AllInstances
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

        public static AssemblyUnitSealingVM LoadVM(DataContext context)
        {
            AssemblyUnitSealingVM vm = new AssemblyUnitSealingVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public IAsyncCommand UpdateListCommand { get; private set; }
        private async Task UpdateList()
        {
            try
            {
                IsBusy = true;
                AllInstances = new ObservableCollection<AssemblyUnitSealing>();
                AllInstances = await Task.Run(() => sealRepo.GetAllAsync());
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
                SelectedItem = await sealRepo.AddAsync(new AssemblyUnitSealing());
                var tcpPoints = await sealRepo.GetTCPsAsync();
                var records = new List<AssemblyUnitSealingJournal>();
                foreach (var tcp in tcpPoints)
                {
                    var journal = new AssemblyUnitSealingJournal(SelectedItem, tcp);
                    if (journal != null)
                        records.Add(journal);
                }
                await sealRepo.AddJournalRecordAsync(records);
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
                    var temp = await sealRepo.GetByIdIncludeAsync(SelectedItem.Id);
                    var copy = await sealRepo.AddAsync(new AssemblyUnitSealing(temp));
                    var jour = new ObservableCollection<AssemblyUnitSealingJournal>();
                    foreach (var i in temp.AssemblyUnitSealingJournals)
                    {
                        var record = new AssemblyUnitSealingJournal(copy.Id, i);
                        jour.Add(record);
                    }
                    sealRepo.UpdateJournalRecord(jour);
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
                _ = new AssemblyUnitSealingEditView
                {
                    DataContext = AssemblyUnitSealingEditVM.LoadVM(SelectedItem.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        private bool CanExecute()
        {
            return true;
        }

        public AssemblyUnitSealingVM(DataContext context)
        {
            db = context;
            sealRepo = new AssemblyUnitSealingRepository(db);
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem, CanExecute);
            CopySelectedItemCommand = new AsyncCommand(CopySelectedItem, CanExecute);
            EditSelectedItemCommand = new Command(o => EditSelectedItem());
        }
    }
}
