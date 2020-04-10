using DataLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DataLayer.Entities.Materials;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.MaterialViews;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Material;
using System.Threading.Tasks;
using System.Linq;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using DataLayer.Entities.Detailing;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class CoverSleeveEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IList<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<CoverSleeveTCP> points;
        private IList<Inspector> inspectors;
        private readonly BaseTable parentEntity;
        private CoverSleeveJournal operation;
        private CoverSleeve selectedItem;
        private CoverSleeveTCP selectedTCPPoint;
        private readonly CoverSleeveRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly MetalMaterialRepository materialRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly CoverSealingRingRepository ringRepo;
        private IEnumerable<CoverSealingRing> coverSealingRings;

        public IEnumerable<CoverSealingRing> CoverSealingRings
        {
            get => coverSealingRings;
            set
            {
                coverSealingRings = value;
                RaisePropertyChanged();
            }
        }

        public CoverSleeve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public CoverSleeveJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CoverSleeveTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IList<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
            }
        }

        public IList<MetalMaterial> Materials
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

        public CoverSleeveTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }


        public static CoverSleeveEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            CoverSleeveEditVM vm = new CoverSleeveEditVM(entity, context);
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
                Materials = await Task.Run(() => materialRepo.GetAllAsync());
                CoverSealingRings = await Task.Run(() => ringRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
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
                if (!await Task.Run(() => ringRepo.IsAssembliedInSleeveAsync(SelectedItem)))
                {
                    IsBusy = true;
                    await Task.Run(() => repo.Update(SelectedItem));
                }
                else
                {
                    IsBusy = true;
                    SelectedItem.CoverSealingRing = null;
                    await Task.Run(() => repo.Update(SelectedItem));
                }
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
                SelectedItem.CoverSleeveJournals.Add(new CoverSleeveJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
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
                        SelectedItem.CoverSleeveJournals.Remove(Operation);
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

        public ICommand EditMaterialCommand { get; private set; }
        private void EditMaterial()
        {
            if (SelectedItem.MetalMaterial != null)
            {
                if (SelectedItem.MetalMaterial is PipeMaterial)
                {
                    _ = new PipeMaterialEditView
                    {
                        DataContext = PipeMaterialEditVM.LoadPipeMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }

                if (SelectedItem.MetalMaterial is SheetMaterial)
                {
                    _ = new SheetMaterialEditView
                    {
                        DataContext = SheetMaterialEditVM.LoadSheetMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
                else if (SelectedItem.MetalMaterial is ForgingMaterial)
                {
                    _ = new ForgingMaterialEditView
                    {
                        DataContext = ForgingMaterialEditVM.LoadForgingMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
                else if (SelectedItem.MetalMaterial is RolledMaterial)
                {
                    _ = new RolledMaterialEditView
                    {
                        DataContext = RolledMaterialEditVM.LoadRolledMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem, db)
                    };
                }
            }
            else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
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

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.CoverSleeveJournals))
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

        public CoverSleeveEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new CoverSleeveRepository(db);
            inspectorRepo = new InspectorRepository(db);
            materialRepo = new MetalMaterialRepository(db);
            journalRepo = new JournalNumberRepository(db);
            ringRepo = new CoverSealingRingRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
            EditCoverSealingRingCommand = new Supervision.Commands.Command(o => EditCoverSealingRing());
        }
    }
}
