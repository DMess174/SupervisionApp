using System.Collections.Generic;
using DataLayer;
using System.ComponentModel;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Diagnostics;
using DataLayer.Files;
using DataLayer.Entities.AssemblyUnits;

namespace Supervision.ViewModels
{
    public class AddFileVM : ViewModelBase
    {
        private DataContext db;
        private readonly BaseTable _entity;
        private FileType? searchFileType;
        private FileType? newFileType;
        private string searchFileName;
        private string newFileName;
        private DateTime? searchFileDate;
        private DateTime? newFileDate;
        private IList<ElectronicDocument> files;
        private ICollectionView allInstancesView;
        private ElectronicDocument selectedFile;
        private ICollectionView view;
        public ICollectionView View
        {
            get => view;
            set
            {
                view = value;
                RaisePropertyChanged();
            }
        }


        public FileType? SearchFileType
        {
            get => searchFileType;
            set
            {
                searchFileType = value;
                RaisePropertyChanged();
            }
        }

        public FileType? NewFileType
        {
            get => newFileType;
            set
            {
                newFileType = value;
                RaisePropertyChanged();
            }
        }

        public string SearchFileName
        {
            get => searchFileName;
            set
            {
                searchFileName = value;
                RaisePropertyChanged();
            }
        }

        public string NewFileName
        {
            get => newFileName;
            set
            {
                newFileName = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? SearchFileDate
        {
            get => searchFileDate;
            set
            {
                searchFileDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? NewFileDate
        {
            get => newFileDate;
            set
            {
                newFileDate = value;
                RaisePropertyChanged();
            }
        }

        public ElectronicDocument SelectedFile
        {
            get => selectedFile;
            set
            {
                selectedFile = value;
                RaisePropertyChanged();
            }
        }

        public IList<ElectronicDocument> Files
        {
            get => files;
            set
            {
                files = value;
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

        public ICommand AddNewFileCommand { get; private set; }
        private void AddNewFile()
        {
            if (NewFileDate == null)
            {
                MessageBox.Show("Введите дату файла", "Ошибка!");
                return;
            }
            if (NewFileName == null)
            {
                MessageBox.Show("Введите имя файла", "Ошибка!");
                return;
            }
            if (NewFileType == null)
            {
                MessageBox.Show("Введите тип файла", "Ошибка!");
                return;
            }

            try
            {
                IsBusy = true;
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    bool? result = dialog.ShowDialog();
                    if (result == true)
                    {
                        var fileName = dialog.FileName;
                        var extension = Path.GetExtension(fileName);
#if DEBUG
                        if (NewFileType == FileType.Specification & _entity is Specification)
                        {
                            var item = _entity as Specification;
                            DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Спецификации" + @"\Спецификации\" + item.Number);
                            if (!dirInfo.Exists)
                            {
                                dirInfo.Create();
                            }
                            var newFilePath = dirInfo.FullName + @"\" + item.Number + extension;
                            if (File.Exists(newFilePath))
                                File.Delete(newFilePath);
                            File.Copy(fileName, newFilePath, true);
                            var newFile = new ElectronicDocument(NewFileName, NewFileType.Value, NewFileDate.Value.Date, newFilePath);
                            db.ElectronicDocuments.Add(newFile);
                            db.SaveChanges();
                            SpecificationWithFile file = new SpecificationWithFile(item.Id, newFile);
                            db.SpecificationWithFiles.Add(file);
                            db.SaveChanges();
                        }
#else
                        DirectoryInfo dirInfo = new DirectoryInfo(@"O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\Спецификации\" + SelectedItem.Number);
                        if (!dirInfo.Exists)
                        {
                            dirInfo.Create();
                        }
                        var newFileName = @"O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\Спецификации\" + SelectedItem.Number + @"\" + SelectedItem.Number + extension;
#endif
                        

                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand AddFileToItemCommand { get; private set; }
        private void AddFileToItem()
        {
            if (SelectedFile != null)
            {
                if (_entity is Specification)
                {
                    var item = _entity as Specification;
                    SpecificationWithFile file = new SpecificationWithFile(item.Id, SelectedFile);
                    db.SpecificationWithFiles.Add(file);
                    db.SaveChanges();
                }
                if (_entity is CastGateValve)
                {
                    var item = _entity as CastGateValve;
                    BaseAssemblyUnitWithFile file = new BaseAssemblyUnitWithFile(item.Id, SelectedFile);
                    db.BaseAssemblyUnitWithFiles.Add(file);
                    db.SaveChanges();
                }
            }
        }

        public ICommand OpenFileCommand { get; private set; }
        private void OpenFile()
        {
            if (SelectedFile != null & File.Exists(SelectedFile.FilePath))
                Process.Start(SelectedFile.FilePath);
        }
        

        public ICommand FindFilesCommand { get; private set; }
        private void FindFiles()
        {
            try
            {
                IsBusy = true;
                Files = new List<ElectronicDocument>();
                db.ElectronicDocuments.Load();
                if (SearchFileType != null)
                    Files = db.ElectronicDocuments.Local.Where(i => i.FileType == SearchFileType).ToList();
                else Files = db.ElectronicDocuments.Local.ToList();

                View = CollectionViewSource.GetDefaultView(Files);
                View.GroupDescriptions.Add(new PropertyGroupDescription("FileType"));
                View.SortDescriptions.Add(new SortDescription("Number", ListSortDirection.Ascending));
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            base.CloseWindow(obj);
        }

        private bool CanExecute()
        {
            return true;
        }

        public static AddFileVM LoadVM(DataContext context, BaseTable entity)
        {
            AddFileVM vm = new AddFileVM(context, entity);
            return vm;
        }

        public AddFileVM(DataContext context, BaseTable entity)
        {
            db = context;
            _entity = entity;
            CloseWindowCommand = new Command(o => CloseWindow(o));
            FindFilesCommand = new Command(_ => FindFiles());
            AddNewFileCommand = new Command(_ => AddNewFile());
            OpenFileCommand = new Command(_ => OpenFile());
        }
    }
}
