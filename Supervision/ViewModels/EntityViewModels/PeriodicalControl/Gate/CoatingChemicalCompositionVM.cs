using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using Supervision.Commands;

namespace Supervision.ViewModels.EntityViewModels.Periodical.Gate
{
    public class CoatingChemicalCompositionVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly CoatingChemicalCompositionRepository repo;
        private readonly JournalNumberRepository journalRepo;
        private readonly InspectorRepository inspectorRepo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoatingChemicalCompositionTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CoatingChemicalCompositionJournal> journal;
        private CoatingChemicalCompositionTCP selectedTCPPoint;
        private DateTime lastInspection;
        private DateTime nextInspection;
        private CoatingChemicalCompositionJournal operation;

        public CoatingChemicalCompositionJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CoatingChemicalCompositionJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public DateTime LastInspection
        {
            get => lastInspection;
            set
            {
                lastInspection = value;
                RaisePropertyChanged();
            }
        }
        public DateTime NextInspection
        {
            get => nextInspection;
            set
            {
                nextInspection = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingChemicalCompositionTCP> Points
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

        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public CoatingChemicalCompositionTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public IAsyncCommand LoadItemsCommand { get; private set; }
        public async Task Load()
        {
            try
            {
                IsBusy = true;
                Journal = await Task.Run(() => repo.GetAllAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Points = await Task.Run(() => repo.GetTCPsAsync());
                if (Journal != null)
                {
                    LastInspection = await Task.Run(() => repo.GetLastDateControl());
                    NextInspection = await Task.Run(() => repo.GetNextDateControl(LastInspection));
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => repo.Update(Journal));
                if (Journal != null)
                {
                    LastInspection = await Task.Run(() => repo.GetLastDateControl());
                    NextInspection = await Task.Run(() => repo.GetNextDateControl(LastInspection));
                }
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
                await repo.AddAsync(new CoatingChemicalCompositionJournal(SelectedTCPPoint));
                SelectedTCPPoint = null;
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
                        await repo.RemoveAsync(Operation);
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
            if (repo.HasChanges(Journal))
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

        public static CoatingChemicalCompositionVM LoadVM(DataContext context)
        {
            CoatingChemicalCompositionVM vm = new CoatingChemicalCompositionVM(context);
            vm.LoadItemsCommand.ExecuteAsync();
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }


        public CoatingChemicalCompositionVM(DataContext context)
        {
            db = context;
            repo = new CoatingChemicalCompositionRepository(db);
            journalRepo = new JournalNumberRepository(db);
            inspectorRepo = new InspectorRepository(db);
            LoadItemsCommand = new AsyncCommand(Load);
            SaveItemCommand = new AsyncCommand(SaveItem);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            AddOperationCommand = new AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new AsyncCommand(RemoveOperation);
        }
    }
}
