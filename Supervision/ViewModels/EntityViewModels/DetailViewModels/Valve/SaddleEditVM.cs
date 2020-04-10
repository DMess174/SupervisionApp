using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm.Native;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class SaddleEditVM: ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IList<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<SaddleTCP> points;
        private IList<Inspector> inspectors;
        private IEnumerable<SaddleJournal> castJournal;
        private IEnumerable<SaddleJournal> sheetJournal;
        private IEnumerable<SaddleJournal> compactJournal;
        private IList<FrontalSaddleSealing> frontalSaddleSeals;
        private FrontalSaddleSealing selectedFrontalSaddleSealing;
        private SaddleWithSealing selectedFrontalSaddleSealingFromList;
        private readonly BaseTable parentEntity;
        private SaddleJournal operation;
        private Saddle selectedItem;
        private SaddleTCP selectedTCPPoint;
        private readonly SaddleRepository saddleRepo;
        private readonly InspectorRepository inspectorRepo;
        private readonly MetalMaterialRepository materialRepo;
        private readonly FrontalSaddleSealingRepository sealsRepo;
        private readonly JournalNumberRepository journalRepo;

        public Saddle SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public SaddleJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SaddleJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleJournal> SheetJournal
        {
            get => sheetJournal;
            set
            {
                sheetJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleJournal> CompactJournal
        {
            get => compactJournal;
            set
            {
                compactJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleTCP> Points
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
        public IList<FrontalSaddleSealing> FrontalSaddleSeals
        {
            get => frontalSaddleSeals;
            set
            {
                frontalSaddleSeals = value;
                RaisePropertyChanged();
            }
        }
        public FrontalSaddleSealing SelectedFrontalSaddleSealing
        {
            get => selectedFrontalSaddleSealing;
            set
            {
                selectedFrontalSaddleSealing = value;
                RaisePropertyChanged();
            }
        }

        public SaddleWithSealing SelectedFrontalSaddleSealingFromList
        {
            get => selectedFrontalSaddleSealingFromList;
            set
            {
                selectedFrontalSaddleSealingFromList = value;
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

        public SaddleTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }


        public static SaddleEditVM LoadSaddleEditVM(int id, BaseTable entity, DataContext context)
        {
            SaddleEditVM vm = new SaddleEditVM(entity, context);
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
                SelectedItem = await Task.Run(() => saddleRepo.GetByIdIncludeAsync(id));
                Materials = await Task.Run(() => materialRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                FrontalSaddleSeals = await Task.Run(() => sealsRepo.GetAllAsync());
                Drawings = await Task.Run(() => saddleRepo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => saddleRepo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                CastJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                SheetJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                CompactJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
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
                await Task.Run(() => saddleRepo.Update(SelectedItem));
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
                SelectedItem.SaddleJournals.Add(new SaddleJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                CastJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                SheetJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                CompactJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
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
                        SelectedItem.SaddleJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        CastJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId);
                        SheetJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId);
                        CompactJournal = SelectedItem.SaddleJournals.Where(i => i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }

        }

        public Supervision.Commands.IAsyncCommand AddSealToSaddleCommand { get; private set; }
        private async Task AddSealToSaddle()
        {
            try
            {
                if (SelectedItem.SaddleWithSealings?.Count() < 2 || SelectedItem.SaddleWithSealings == null)
                {
                    if (SelectedFrontalSaddleSealing != null)
                    {
                        IsBusy = true;
                        if (await sealsRepo.IsAmountRemaining(SelectedFrontalSaddleSealing))
                        {
                            SelectedItem.SaddleWithSealings.Add(new SaddleWithSealing() { SaddleId = SelectedItem.Id, FrontalSaddleSealingId = SelectedFrontalSaddleSealing.Id });
                            SelectedFrontalSaddleSealing.AmountRemaining -= 1;
                            sealsRepo.Update(SelectedFrontalSaddleSealing);
                            SelectedFrontalSaddleSealing = null;
                            await SaveItemCommand.ExecuteAsync();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 уплотнений!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand RemoveSealFromSaddleCommand { get; private set; }
        private async Task RemoveSealFromSaddle()
        {
            try
            {
                IsBusy = true;
                if (SelectedFrontalSaddleSealingFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedFrontalSaddleSealing = SelectedFrontalSaddleSealingFromList.FrontalSaddleSealing;
                        SelectedFrontalSaddleSealing.AmountRemaining += 1;
                        SelectedItem.SaddleWithSealings.Remove(SelectedFrontalSaddleSealingFromList);
                        sealsRepo.Update(SelectedFrontalSaddleSealing);
                        SelectedFrontalSaddleSealing = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSealCommand { get; private set; }
        private void EditSeal()
        {
            if (SelectedFrontalSaddleSealingFromList != null)
            {
                _ = new FrontalSaddleSealingEditView
                {
                    DataContext = FrontalSaddleSealingEditVM.LoadFrontalSaddleSealingEditVM(SelectedFrontalSaddleSealingFromList.FrontalSaddleSealing.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
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
            if (saddleRepo.HasChanges(SelectedItem) || saddleRepo.HasChanges(SelectedItem.SaddleJournals))
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

        public SaddleEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            saddleRepo = new SaddleRepository(db);
            inspectorRepo = new InspectorRepository(db);
            materialRepo = new MetalMaterialRepository(db);
            sealsRepo = new FrontalSaddleSealingRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            AddSealToSaddleCommand = new Supervision.Commands.AsyncCommand(AddSealToSaddle);
            RemoveSealFromSaddleCommand = new Supervision.Commands.AsyncCommand(RemoveSealFromSaddle);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
            EditSealCommand = new Supervision.Commands.Command(o => EditSeal());
        }
    }
}
