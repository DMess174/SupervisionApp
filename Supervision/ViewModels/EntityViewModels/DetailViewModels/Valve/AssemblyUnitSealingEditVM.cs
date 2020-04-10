using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Supervision.Commands;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class AssemblyUnitSealingEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private readonly AssemblyUnitSealingRepository sealRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;

        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<AssemblyUnitSealingTCP> points;
        private IEnumerable<Inspector> inspectors;
        private readonly BaseTable parentEntity;
        private AssemblyUnitSealing selectedItem;
        private AssemblyUnitSealingTCP selectedTCPPoint;
        private IEnumerable<string> names;

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            protected set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        private AssemblyUnitSealingJournal operation;
        public AssemblyUnitSealingJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
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

        public IEnumerable<AssemblyUnitSealingTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> Names
        {
            get => names;
            set
            {
                names = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
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
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public AssemblyUnitSealingTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }



        public static AssemblyUnitSealingEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            AssemblyUnitSealingEditVM vm = new AssemblyUnitSealingEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        public IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => sealRepo.GetByIdIncludeAsync(id));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Materials = await Task.Run(() => sealRepo.GetPropertyValuesDistinctAsync(i => i.Material));
                Drawings = await Task.Run(() => sealRepo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Names = await Task.Run(() => sealRepo.GetPropertyValuesDistinctAsync(i => i.Name));
                Points = await Task.Run(() => sealRepo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand SaveItemCommand { get; private set; }
        private async Task Save()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.Amount > 0)
                    SelectedItem.AmountRemaining = SelectedItem.Amount - SelectedItem.BaseValveWithSeals.Count;
                await Task.Run(() => sealRepo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.AssemblyUnitSealingJournals.Add(new AssemblyUnitSealingJournal()
                {
                    DetailDrawing = SelectedItem.Drawing,
                    DetailNumber = SelectedItem.Number,
                    DetailName = SelectedItem.Name,
                    DetailId = SelectedItem.Id,
                    Point = SelectedTCPPoint.Point,
                    Description = SelectedTCPPoint.Description,
                    PointId = SelectedTCPPoint.Id,
                });
                await SaveItemCommand.ExecuteAsync();
            }
        }


        public IAsyncCommand RemoveOperationCommand { get; private set; }
        private async Task RemoveOperation()
        {
            try
            {
                IsBusy = true;
                if (Operation != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.AssemblyUnitSealingJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }

        }

        public ICommand CloseWindowCommand { get; private set; }
        private void CloseWindow(object obj)
        {
            if (sealRepo.HasChanges(SelectedItem) || sealRepo.HasChanges(SelectedItem.AssemblyUnitSealingJournals))
            {
                MessageBoxResult result = MessageBox.Show("Закрыть без сохранения изменений?", "Выход", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Window w = obj as Window;
                    w?.Close();
                }
            }
            else
            {
                Window w = obj as Window;
                w?.Close();
            }
        }

        private bool CanExecute()
        {
            return true;
        }

        public AssemblyUnitSealingEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            sealRepo = new AssemblyUnitSealingRepository(context);
            inspectorRepo = new InspectorRepository(context);
            journalRepo = new JournalNumberRepository(context);
            LoadItemCommand = new AsyncCommand<int>(Load);
            SaveItemCommand = new AsyncCommand(Save);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            AddOperationCommand = new AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new AsyncCommand(RemoveOperation);
        }
    }
}
