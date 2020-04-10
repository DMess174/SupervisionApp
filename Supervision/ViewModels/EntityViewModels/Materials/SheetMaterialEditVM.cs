using DataLayer;
using System.Collections.Generic;
using System.Windows;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials;
using BusinessLayer.Repository.Implementations.Entities.Material;
using BusinessLayer.Repository.Implementations.Entities;
using System.Threading.Tasks;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class SheetMaterialEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> firstSizes;
        private IEnumerable<string> secondSizes;
        private IEnumerable<string> thirdSizes;
        private IEnumerable<MetalMaterialTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SheetMaterialJournal> journal;
        private readonly BaseTable parentEntity;
        private readonly SheetMaterialRepository sheetRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private MetalMaterialTCP selectedTCPPoint;

        private SheetMaterial selectedItem;
        private SheetMaterialJournal operation;

        public SheetMaterialJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
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

        public IEnumerable<SheetMaterialJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<MetalMaterialTCP> Points
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

        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
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

        public IEnumerable<string> FirstSizes
        {
            get => firstSizes;
            set
            {
                firstSizes = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> SecondSizes
        {
            get => secondSizes;
            set
            {
                secondSizes = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> ThirdSizes
        {
            get => thirdSizes;
            set
            {
                thirdSizes = value;
                RaisePropertyChanged();
            }
        }

        public MetalMaterialTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        

        public Commands.IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => sheetRepo.GetByIdIncludeAsync(id));
                Materials = await Task.Run(() => sheetRepo.GetPropertyValuesDistinctAsync(i => i.Material));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Points = await Task.Run(() => sheetRepo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                FirstSizes = await Task.Run(() => sheetRepo.GetPropertyValuesDistinctAsync(i => i.FirstSize));
                SecondSizes = await Task.Run(() => sheetRepo.GetPropertyValuesDistinctAsync(i => i.SecondSize));
                ThirdSizes = await Task.Run(() => sheetRepo.GetPropertyValuesDistinctAsync(i => i.ThirdSize));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => sheetRepo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Commands.IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.SheetMaterialJournals.Add(new SheetMaterialJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                SelectedTCPPoint = null;
            }
        }

        public Supervision.Commands.IAsyncCommand RemoveOperationCommand { get; private set; }
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
                        SelectedItem.SheetMaterialJournals.Remove(Operation);
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

        protected override void CloseWindow(object obj)
        {
            if (sheetRepo.HasChanges(SelectedItem) || sheetRepo.HasChanges(SelectedItem.SheetMaterialJournals))
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

        public static SheetMaterialEditVM LoadSheetMaterialEditVM(int id, BaseTable entity, DataContext context)
        {
            SheetMaterialEditVM vm = new SheetMaterialEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        public SheetMaterialEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            sheetRepo = new SheetMaterialRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Commands.AsyncCommand(RemoveOperation);
        }
    }
}
