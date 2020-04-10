using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class SheetGateValveCoverEditVM : ViewModelBase
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoverFlange> coverFlanges;
        private IEnumerable<CoverSleeve> coverSleeves;
        private IEnumerable<Spindle> spindles;
        private IEnumerable<RunningSleeve> runningSleeves;
        private IEnumerable<string> drawings;
        private IEnumerable<SheetGateValveCoverTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SheetGateValveCoverJournal> assemblyJournal;
        private IEnumerable<SheetGateValveCoverJournal> assemblyWeldingJournal;
        private IEnumerable<SheetGateValveCoverJournal> mechanicalJournal;
        private IEnumerable<SheetGateValveCoverJournal> nDTJournal;
        private readonly BaseTable parentEntity;
        private readonly SheetGateValveCoverRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly CoverFlangeRepository coverFlangeRepo;
        private readonly CoverSleeveRepository coverSleeveRepo;
        private readonly RunningSleeveRepository runningSleeveRepo;
        private readonly SpindleRepository spindleRepo;
        private SheetGateValveCover selectedItem;
        private SheetGateValveCoverTCP selectedTCPPoint;
        private SheetGateValveCoverJournal operation;

        public SheetGateValveCoverJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public SheetGateValveCover SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SheetGateValveCoverJournal> AssemblyWeldingJournal
        {
            get => assemblyWeldingJournal;
            set
            {
                assemblyWeldingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCoverJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCoverJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCoverJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveCoverTCP> Points
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

        public IEnumerable<CoverFlange> CoverFlanges
        {
            get => coverFlanges;
            set
            {
                coverFlanges = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoverSleeve> CoverSleeves
        {
            get => coverSleeves;
            set
            {
                coverSleeves = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Spindle> Spindles
        {
            get => spindles;
            set
            {
                spindles = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<RunningSleeve> RunningSleeves
        {
            get => runningSleeves;
            set
            {
                runningSleeves = value;
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

        public SheetGateValveCoverTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public static SheetGateValveCoverEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            SheetGateValveCoverEditVM vm = new SheetGateValveCoverEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
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
                CoverFlanges = await Task.Run(() => coverFlangeRepo.GetAllAsync());
                CoverSleeves = await Task.Run(() => coverSleeveRepo.GetAllAsync());
                RunningSleeves = await Task.Run(() => runningSleeveRepo.GetAllAsync());
                Spindles = await Task.Run(() => spindleRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                AssemblyWeldingJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.SpindleId != null)
                {
                    if (await Task.Run(() => spindleRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.Spindle = null;
                    }
                }
                if (SelectedItem.CoverSleeveId != null)
                {
                    if (await Task.Run(() => coverSleeveRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.CoverSleeve = null;
                    }
                }
                if (SelectedItem.CoverFlangeId != null)
                {
                    if (await Task.Run(() => coverFlangeRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.CoverFlange = null;
                    }
                }
                if (SelectedItem.RunningSleeveId != null)
                {
                    if (await Task.Run(() => runningSleeveRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.RunningSleeve = null;
                    }
                }
                await Task.Run(() => repo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddJournalOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.SheetGateValveCoverJournals.Add(new SheetGateValveCoverJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                AssemblyWeldingJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                SelectedTCPPoint = null;
            }
        }

        public Commands.IAsyncCommand RemoveOperationCommand { get; private set; }
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
                        SelectedItem.SheetGateValveCoverJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        AssemblyWeldingJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                        MechanicalJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                        NDTJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
                        AssemblyJournal = SelectedItem.SheetGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSpindleCommand { get; private set; }
        private void EditSpindle()
        {
            if (SelectedItem.Spindle != null)
            {
                _ = new SpindleEditView
                {
                    DataContext = SpindleEditVM.LoadVM(SelectedItem.Spindle.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите шпиндель", "Ошибка");
        }

        public ICommand EditCoverSleeveCommand { get; private set; }
        private void EditCoverSleeve()
        {
            if (SelectedItem.CoverSleeve != null)
            {
                _ = new CoverSleeveEditView
                {
                    DataContext = CoverSleeveEditVM.LoadVM(SelectedItem.CoverSleeve.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
        }

        public ICommand EditCoverFlangeCommand { get; private set; }
        private void EditCoverFlange()
        {
            if (SelectedItem.CoverFlange != null)
            {
                _ = new CoverFlangeEditView
                {
                    DataContext = CoverFlangeEditVM.LoadVM(SelectedItem.CoverFlange.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
        }

        public ICommand EditRunningSleeveCommand { get; private set; }
        private void EditRunningSleeve()
        {
            if (SelectedItem.RunningSleeve != null)
            {
                _ = new RunningSleeveEditView
                {
                    DataContext = RunningSleeveEditVM.LoadVM(SelectedItem.RunningSleeve.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
        }

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.SheetGateValveCoverJournals))
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

        public SheetGateValveCoverEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new SheetGateValveCoverRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            coverFlangeRepo = new CoverFlangeRepository(db);
            coverSleeveRepo = new CoverSleeveRepository(db);
            runningSleeveRepo = new RunningSleeveRepository(db);
            spindleRepo = new SpindleRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditSpindleCommand = new Supervision.Commands.Command(o => EditSpindle());
            EditCoverFlangeCommand = new Supervision.Commands.Command(o => EditCoverFlange());
            EditCoverSleeveCommand = new Supervision.Commands.Command(o => EditCoverSleeve());
            EditRunningSleeveCommand = new Supervision.Commands.Command(o => EditRunningSleeve());
        }

        

        
    }
}
