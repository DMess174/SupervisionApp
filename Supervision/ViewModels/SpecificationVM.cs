using System.Collections.Generic;
using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Supervision.Views.EntityViews;
using DataLayer.Journals;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System;
using System.IO;
using Supervision.Views.FileWorkViews;

namespace Supervision.ViewModels
{
    public class SpecificationVM : ViewModelBase
    {
        private DataContext db;
        private readonly SpecificationRepository specificationRepo;
        private readonly CustomerRepository customerRepo;
        private readonly PIDRepository pIDRepo;
        private IEnumerable<Specification> allInstances;
        private ICollectionView allInstancesView;
        private Specification selectedItem;
        private PID selectedPID;
        private IEnumerable<Customer> customers;
        private string number = "";

        public string Number
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is Specification item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
  

        public Specification SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public PID SelectedPID
        {
            get => selectedPID;
            set
            {
                selectedPID = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Specification> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
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

        public ICommand AddFileCommand { get; private set; }
        private void AddFile()
        {
//            try
//            {
//                IsBusy = true;
//                if (SelectedItem != null)
//                {

//                    OpenFileDialog dialog = new OpenFileDialog();
//                    bool? result = dialog.ShowDialog();
//                    if (result == true)
//                    {
//                        var fileName = dialog.FileName;
//                        var extension = Path.GetExtension(fileName);
//#if DEBUG
//                        DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + SelectedItem.Number);
//                        if (!dirInfo.Exists)
//                        {
//                            dirInfo.Create();
//                        }
//                        var newFileName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + SelectedItem.Number + @"\" + SelectedItem.Number + extension;
//#else
//                        DirectoryInfo dirInfo = new DirectoryInfo(@"O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\Спецификации\" + SelectedItem.Number);
//                        if (!dirInfo.Exists)
//                        {
//                            dirInfo.Create();
//                        }
//                        var newFileName = @"O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\Спецификации\" + SelectedItem.Number + @"\" + SelectedItem.Number + extension;
//#endif
//                        if (File.Exists(newFileName))
//                            File.Delete(newFileName);
//                        File.Copy(fileName, newFileName, true);
//                        SelectedItem.FilePath = newFileName;
//                        SaveItemsCommand.ExecuteAsync();
                        
//                    }
//                }
//            }
//            finally
//            {
//                IsBusy = false;
//            }
        }

        public ICommand EditPIDCommand { get; private set; }
        private void EditPID()
        {
            if (SelectedPID != null)
            {
                _ = new PIDEditView
                {
                    DataContext = PIDEditVM.LoadPIDEditVM(SelectedPID.Id, SelectedPID, db)
                };
            }
        }

        public ICommand FileStorageOpenCommand { get; private set; }
        private void FileStorageOpen()
        {
            if (SelectedItem != null)
            {
                _ = new AddFileView
                {
                    DataContext = AddFileVM.LoadVM(db, SelectedItem)
                };
            }
        }
        



        public IAsyncCommand SaveItemsCommand { get; private set; }
        private async Task SaveItems()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => specificationRepo.Update(AllInstances));
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
                SelectedItem = await specificationRepo.AddAsync(new Specification());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand AddNewPIDCommand { get; private set; }
        private async Task AddNewPID()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem != null)
                {
                    SelectedPID = await pIDRepo.AddAsync(new PID(SelectedItem));
                    var tcpPoints = await pIDRepo.GetTCPsAsync();
                    var records = new List<PIDJournal>();
                    foreach (var tcp in tcpPoints)
                    {
                        var journal = new PIDJournal(SelectedPID, tcp);
                        if (journal != null)
                            records.Add(journal);
                    }
                    await pIDRepo.AddJournalRecordAsync(records);
                    EditPID();
                }
                else MessageBox.Show("Выберите спецификацию!", "Ошибка");
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
                try
                {
                    IsBusy = true;
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                        await specificationRepo.RemoveAsync(SelectedItem);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public IAsyncCommand RemoveSelectedPIDCommand { get; private set; }
        private async Task RemoveSelectedPID()
        {
            if (SelectedPID != null)
            {
                try
                {
                    IsBusy = true;
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.PIDs.Remove(SelectedPID);
                        await SaveItemsCommand.ExecuteAsync();
                    }
                }
                finally
                {
                    IsBusy = false;
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
                AllInstances = new ObservableCollection<Specification>();
                AllInstances = await Task.Run(() => specificationRepo.GetAllAsync());
                Customers = await Task.Run(() => customerRepo.GetAllAsync());
                AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (specificationRepo.HasChanges(AllInstances))
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

        public static SpecificationVM LoadSpecificationVM(DataContext context)
        {
            SpecificationVM vm = new SpecificationVM(context);
            vm.UpdateListCommand.ExecuteAsync();
            return vm;
        }

        public SpecificationVM(DataContext context)
        {
            db = context;
            specificationRepo = new SpecificationRepository(db);
            customerRepo = new CustomerRepository(db);
            pIDRepo = new PIDRepository(db);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            UpdateListCommand = new AsyncCommand(UpdateList, CanExecute);
            AddNewItemCommand = new AsyncCommand(AddNewItem);
            AddNewPIDCommand = new AsyncCommand(AddNewPID);
            RemoveSelectedItemCommand = new AsyncCommand(RemoveSelectedItem);
            RemoveSelectedPIDCommand = new AsyncCommand(RemoveSelectedPID);
            SaveItemsCommand = new AsyncCommand(SaveItems);
            EditPIDCommand = new Command(_ => EditPID());
            FileStorageOpenCommand = new Command(_ => FileStorageOpen());
            AddFileCommand = new Command(_ => AddFile());
        }
    }
}
