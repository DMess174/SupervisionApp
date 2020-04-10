using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
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

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class SpindleEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IList<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<SpindleTCP> points;
        private IList<Inspector> inspectors;
        private IEnumerable<SpindleJournal> castJournal;
        private IEnumerable<SpindleJournal> sheetJournal;
        private IEnumerable<SpindleJournal> compactJournal;
        private readonly BaseTable parentEntity;
        private SpindleJournal operation;
        private Spindle selectedItem;
        private SpindleTCP selectedTCPPoint;
        private readonly SpindleRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly MetalMaterialRepository materialRepo;
        private readonly JournalNumberRepository journalRepo;

        public Spindle SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public SpindleJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SpindleJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SpindleJournal> SheetJournal
        {
            get => sheetJournal;
            set
            {
                sheetJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SpindleJournal> CompactJournal
        {
            get => compactJournal;
            set
            {
                compactJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SpindleTCP> Points
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

        public SpindleTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }


        public static SpindleEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            SpindleEditVM vm = new SpindleEditVM(entity, context);
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
                CastJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                SheetJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                CompactJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
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
                SelectedItem.SpindleJournals.Add(new SpindleJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                CastJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                SheetJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                CompactJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
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
                        SelectedItem.SpindleJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        CastJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                        SheetJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                        CompactJournal = SelectedItem.SpindleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.SpindleJournals))
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

        public SpindleEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new SpindleRepository(db);
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
