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
    public class ScrewStudEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private readonly ScrewStudRepository screwStudRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;

        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ScrewStudTCP> points;
        private IEnumerable<Inspector> inspectors;
        private readonly BaseTable parentEntity;
        private ScrewStud selectedItem;
        private ScrewStudTCP selectedTCPPoint;

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

        private ScrewStudJournal operation;
        public ScrewStudJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }
        public ScrewStud SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ScrewStudTCP> Points
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

        public ScrewStudTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }



        public static ScrewStudEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ScrewStudEditVM vm = new ScrewStudEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        public IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => screwStudRepo.GetByIdIncludeAsync(id));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Materials = await Task.Run(() => screwStudRepo.GetPropertyValuesDistinctAsync(i => i.Material));
                Drawings = await Task.Run(() => screwStudRepo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => screwStudRepo.GetTCPsAsync());
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
                        SelectedItem.AmountRemaining = await screwStudRepo.GetAmountRemaining(SelectedItem);
                }
                await Task.Run(() => screwStudRepo.Update(SelectedItem));
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
                SelectedItem.ScrewStudJournals.Add(new ScrewStudJournal()
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
                        SelectedItem.ScrewStudJournals.Remove(Operation);
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
            if (screwStudRepo.HasChanges(SelectedItem) || screwStudRepo.HasChanges(SelectedItem.ScrewStudJournals))
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

        public ScrewStudEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            screwStudRepo = new ScrewStudRepository(context);
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
