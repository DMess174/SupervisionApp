using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using Supervision.Views.EntityViews.DetailViews.CompactGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.CompactGateValve
{
    public class ShutterEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<ShutterDisk> shutterDisks;
        private IEnumerable<ShutterGuide> shutterGuides;
        private ShutterDisk selectedShutterDisk;
        private ShutterDisk selectedShutterDiskFromList;
        private ShutterGuide selectedShutterGuide;
        private ShutterGuide selectedShutterGuideFromList;
        private IEnumerable<string> drawings;
        private readonly BaseTable parentEntity;
        private readonly ShutterRepository repo;
        private readonly ShutterDiskRepository shutterDiskRepo;
        private readonly ShutterGuideRepository shutterGuideRepo;
        private Shutter selectedItem;

        public Shutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public ShutterDisk SelectedShutterDisk
        {
            get => selectedShutterDisk;
            set
            {
                selectedShutterDisk = value;
                RaisePropertyChanged();
            }
        }

        public ShutterDisk SelectedShutterDiskFromList
        {
            get => selectedShutterDiskFromList;
            set
            {
                selectedShutterDiskFromList = value;
                RaisePropertyChanged();
            }
        }
        
        public ShutterGuide SelectedShutterGuide
        {
            get => selectedShutterGuide;
            set
            {
                selectedShutterGuide = value;
                RaisePropertyChanged();
            }
        }

        public ShutterGuide SelectedShutterGuideFromList
        {
            get => selectedShutterGuideFromList;
            set
            {
                selectedShutterGuideFromList = value;
                RaisePropertyChanged();
            }
        }
       
        public IEnumerable<ShutterDisk> ShutterDisks
        {
            get => shutterDisks;
            set
            {
                shutterDisks = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShutterGuide> ShutterGuides
        {
            get => shutterGuides;
            set
            {
                shutterGuides = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged();
            }
        }

        public Supervision.Commands.IAsyncCommand AddShutterDiskToShutterCommand { get; private set; }
        private async Task AddShutterDiskToShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.ShutterDisks?.Count() < 2 || SelectedItem.ShutterDisks == null)
                {
                    if (SelectedShutterDisk != null)
                    {
                        if (!await shutterDiskRepo.IsAssembliedAsync(SelectedShutterDisk))
                        {
                            SelectedShutterDisk.ShutterId = SelectedItem.Id;
                            shutterDiskRepo.Update(SelectedShutterDisk);
                            SelectedShutterDisk = null;
                            ShutterDisks = shutterDiskRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 дисков!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteShutterDiskFromShutterCommand { get; private set; }
        private async Task DeleteShutterDiskFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedShutterDiskFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedShutterDiskFromList.ShutterId = null;
                        shutterDiskRepo.Update(SelectedShutterDiskFromList);
                        ShutterDisks = shutterDiskRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditShutterDiskCommand { get; private set; }
        private void EditShutterDisk()
        {
            if (SelectedShutterDiskFromList != null)
            {
                _ = new ShutterDiskEditView
                {
                    DataContext = ShutterDiskEditVM.LoadVM(SelectedShutterDiskFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddShutterGuideToShutterCommand { get; private set; }
        private async Task AddShutterGuideToShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.ShutterGuides?.Count() < 2 || SelectedItem.ShutterGuides == null)
                {
                    if (SelectedShutterGuide != null)
                    {
                        if (!await shutterGuideRepo.IsAssembliedAsync(SelectedShutterGuide))
                        {
                            SelectedShutterGuide.ShutterId = SelectedItem.Id;
                            shutterGuideRepo.Update(SelectedShutterGuide);
                            SelectedShutterGuide = null;
                            ShutterGuides = shutterGuideRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 направляющих!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteShutterGuideFromShutterCommand { get; private set; }
        private async Task DeleteShutterGuideFromShutter()
        {
            try
            {
                IsBusy = true;
                if (SelectedShutterGuideFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedShutterGuideFromList.ShutterId = null;
                        shutterGuideRepo.Update(SelectedShutterGuideFromList);
                        ShutterGuides = shutterGuideRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditShutterGuideCommand { get; private set; }
        private void EditShutterGuide()
        {
            if (SelectedShutterGuideFromList != null)
            {
                _ = new ShutterGuideEditView
                {
                    DataContext = ShutterGuideEditVM.LoadVM(SelectedShutterGuideFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => repo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem))
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

        public Commands.IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => repo.GetByIdIncludeAsync(id));
                await Task.Run(() => shutterDiskRepo.Load());
                await Task.Run(() => shutterGuideRepo.Load());
                ShutterDisks = shutterDiskRepo.UpdateList();
                ShutterGuides = shutterGuideRepo.UpdateList();
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public static ShutterEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ShutterEditVM vm = new ShutterEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        public ShutterEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new ShutterRepository(db);
            shutterDiskRepo = new ShutterDiskRepository(db);
            shutterGuideRepo = new ShutterGuideRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddShutterDiskToShutterCommand = new Supervision.Commands.AsyncCommand(AddShutterDiskToShutter);
            DeleteShutterDiskFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteShutterDiskFromShutter);
            EditShutterDiskCommand = new Supervision.Commands.Command(o => EditShutterDisk());
            AddShutterGuideToShutterCommand = new Supervision.Commands.AsyncCommand(AddShutterGuideToShutter);
            DeleteShutterGuideFromShutterCommand = new Supervision.Commands.AsyncCommand(DeleteShutterGuideFromShutter);
            EditShutterGuideCommand = new Supervision.Commands.Command(o => EditShutterGuide());
        }
    }
}
