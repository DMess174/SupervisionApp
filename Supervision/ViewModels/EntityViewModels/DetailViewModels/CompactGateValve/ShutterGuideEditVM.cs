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
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.CompactGateValveDetails;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.CompactGateValve
{
    public class ShutterGuideEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IList<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ShutterGuideTCP> points;
        private IList<Inspector> inspectors;
        private IEnumerable<ShutterGuideJournal> castJournal;
        private IEnumerable<ShutterGuideJournal> shutterJournal;
        private readonly BaseTable parentEntity;
        private ShutterGuideJournal operation;
        private ShutterGuide selectedItem;
        private ShutterGuideTCP selectedTCPPoint;
        private readonly ShutterGuideRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly MetalMaterialRepository materialRepo;
        private readonly JournalNumberRepository journalRepo;

        public ShutterGuide SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public ShutterGuideJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ShutterGuideJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShutterGuideJournal> ShutterJournal
        {
            get => shutterJournal;
            set
            {
                shutterJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShutterGuideTCP> Points
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

        public ShutterGuideTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }


        public static ShutterGuideEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            ShutterGuideEditVM vm = new ShutterGuideEditVM(entity, context);
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
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                CastJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                ShutterJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗО").OrderBy(x => x.PointId);
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
                SelectedItem.ShutterGuideJournals.Add(new ShutterGuideJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                CastJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                ShutterJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗО").OrderBy(x => x.PointId);
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
                        SelectedItem.ShutterGuideJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        CastJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                        ShutterJournal = SelectedItem.ShutterGuideJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗО").OrderBy(x => x.PointId);
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

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.ShutterGuideJournals))
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

        public ShutterGuideEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new ShutterGuideRepository(db);
            inspectorRepo = new InspectorRepository(db);
            materialRepo = new MetalMaterialRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
        }
    }
}
