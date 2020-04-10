using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class CastGateValveCoverEditVM : ViewModelBase
    {

        private readonly DataContext db;
        private readonly BaseTable parentEntity;
        private readonly CastGateValveCoverRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly CoverSealingRingRepository coverSealingRingRepo;
        private readonly RunningSleeveRepository runningSleeveRepo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<CastGateValveCoverTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CastGateValveCoverJournal> assemblyWeldingJournal;
        private IEnumerable<CastGateValveCoverJournal> inputControlJournal;
        private IEnumerable<CastGateValveCoverJournal> inputNDTControlJournal;
        private IEnumerable<CastGateValveCoverJournal> mechanicalJournal;
        private IEnumerable<CastGateValveCoverJournal> assemblyJournal;
        private IEnumerable<CastGateValveCoverJournal> nDTJournal;
        private CastGateValveCover selectedItem;
        private CastGateValveCoverTCP selectedTCPPoint;
        private IEnumerable<CoverSealingRing> coverSealingRings;
        private IEnumerable<RunningSleeve> runningSleeves;
        private IEnumerable<Spindle> spindles;
        private SpindleRepository spindleRepo;
        private CastGateValveCoverJournal operation;

        public CastGateValveCoverJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public CastGateValveCover SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CastGateValveCoverJournal> AssemblyWeldingJournal
        {
            get => assemblyWeldingJournal;
            set
            {
                assemblyWeldingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverTCP> Points
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

        public CastGateValveCoverTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
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
        public IEnumerable<CoverSealingRing> CoverSealingRings
        {
            get => coverSealingRings;
            set
            {
                coverSealingRings = value;
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

        public static CastGateValveCoverEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            CastGateValveCoverEditVM vm = new CastGateValveCoverEditVM(entity, context);
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
                CoverSealingRings = await Task.Run(() => coverSealingRingRepo.GetAllAsync());
                RunningSleeves = await Task.Run(() => runningSleeveRepo.GetAllAsync());
                Spindles = await Task.Run(() => spindleRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Materials = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Material));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                InputControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                AssemblyWeldingJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
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
                if (SelectedItem.CoverSealingRingId != null)
                {
                    if (await Task.Run(() => coverSealingRingRepo.IsAssembliedInCoverAsync(SelectedItem)))
                    {
                        SelectedItem.CoverSealingRing = null;
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
                SelectedItem.CastGateValveCoverJournals.Add(new CastGateValveCoverJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                InputControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                InputNDTControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                MechanicalJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                AssemblyWeldingJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                NDTJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
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
                        SelectedItem.CastGateValveCoverJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        InputControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId);
                        InputNDTControlJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId);
                        MechanicalJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId);
                        AssemblyWeldingJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId);
                        AssemblyJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                        NDTJournal = SelectedItem.CastGateValveCoverJournals.Where(i => i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId);
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

        public ICommand EditCoverSealingRingCommand { get; private set; }
        private void EditCoverSealingRing()
        {
            if (SelectedItem.CoverSealingRing != null)
            {
                _ = new CoverSealingRingEditView
                {
                    DataContext = CoverSealingRingEditVM.LoadVM(SelectedItem.CoverSealingRing.Id, SelectedItem, db)
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.CastGateValveCoverJournals))
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

        public CastGateValveCoverEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new CastGateValveCoverRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            coverSealingRingRepo = new CoverSealingRingRepository(db);
            runningSleeveRepo = new RunningSleeveRepository(db);
            spindleRepo = new SpindleRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditSpindleCommand = new Supervision.Commands.Command(o => EditSpindle());
            EditCoverSealingRingCommand = new Supervision.Commands.Command(o => EditCoverSealingRing());
            EditRunningSleeveCommand = new Supervision.Commands.Command(o => EditRunningSleeve());
        }
    }
}
