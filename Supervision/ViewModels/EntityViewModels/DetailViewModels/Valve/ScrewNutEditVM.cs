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
    public class ScrewNutEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private readonly ScrewNutRepository screwNutRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;

        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ScrewNutTCP> points;
        private IEnumerable<Inspector> inspectors;
        private readonly BaseTable parentEntity;
        private ScrewNut selectedItem;
        private ScrewNutTCP selectedTCPPoint;

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

        private ScrewNutJournal operation;
        public ScrewNutJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }
        public ScrewNut SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ScrewNutTCP> Points
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

        public ScrewNutTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }



        public static ScrewNutEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ScrewNutEditVM vm = new ScrewNutEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        public IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => screwNutRepo.GetByIdIncludeAsync(id));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Materials = await Task.Run(() => screwNutRepo.GetPropertyValuesDistinctAsync(i => i.Material));
                Drawings = await Task.Run(() => screwNutRepo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => screwNutRepo.GetTCPsAsync());
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
                if (SelectedItem != null)
                {
                    if (SelectedItem.AmountRemaining == null && SelectedItem.Amount > 0)
                        SelectedItem.AmountRemaining = SelectedItem.Amount;
                    else
                        SelectedItem.AmountRemaining = await screwNutRepo.GetAmountRemaining(SelectedItem);
                }
                await Task.Run(() => screwNutRepo.Update(SelectedItem));
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
                SelectedItem.ScrewNutJournals.Add(new ScrewNutJournal()
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
                        SelectedItem.ScrewNutJournals.Remove(Operation);
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
            if (screwNutRepo.HasChanges(SelectedItem) || screwNutRepo.HasChanges(SelectedItem.ScrewNutJournals))
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

        public ScrewNutEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            screwNutRepo = new ScrewNutRepository(context);
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
