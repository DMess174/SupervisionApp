﻿using DataLayer;
using System.Collections.Generic;
using System.Windows;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials;
using BusinessLayer.Repository.Implementations.Entities.Material;
using BusinessLayer.Repository.Implementations.Entities;
using Supervision.Commands;
using System.Threading.Tasks;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class RolledMaterialEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> firstSizes;
        private IEnumerable<string> secondSizes;
        private IEnumerable<string> thirdSizes;
        private IEnumerable<MetalMaterialTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<RolledMaterialJournal> journal;
        private readonly BaseTable parentEntity;
        private readonly RolledMaterialRepository materialRepo;
        private MetalMaterialTCP selectedTCPPoint;

        private RolledMaterial selectedItem;
        private RolledMaterialJournal operation;
        private InspectorRepository inspectorRepo;
        private JournalNumberRepository journalRepo;

        public RolledMaterialJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

        public RolledMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<RolledMaterialJournal> Journal
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

        public IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => materialRepo.GetByIdIncludeAsync(id));
                Materials = await Task.Run(() => materialRepo.GetPropertyValuesDistinctAsync(i => i.Material));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Points = await Task.Run(() => materialRepo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                FirstSizes = await Task.Run(() => materialRepo.GetPropertyValuesDistinctAsync(i => i.FirstSize));
                SecondSizes = await Task.Run(() => materialRepo.GetPropertyValuesDistinctAsync(i => i.SecondSize));
                ThirdSizes = await Task.Run(() => materialRepo.GetPropertyValuesDistinctAsync(i => i.ThirdSize));
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
                await Task.Run(() => materialRepo.Update(SelectedItem));
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
                SelectedItem.RolledMaterialJournals.Add(new RolledMaterialJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
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
                        SelectedItem.RolledMaterialJournals.Remove(Operation);
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
            if (materialRepo.HasChanges(SelectedItem) || materialRepo.HasChanges(SelectedItem.RolledMaterialJournals))
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

        public static RolledMaterialEditVM LoadRolledMaterialEditVM(int id, BaseTable entity, DataContext context)
        {
            RolledMaterialEditVM vm = new RolledMaterialEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        public RolledMaterialEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            materialRepo = new RolledMaterialRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            LoadItemCommand = new AsyncCommand<int>(Load);
            SaveItemCommand = new AsyncCommand(SaveItem);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            AddOperationCommand = new AsyncCommand(AddJournalOperation);
            RemoveOperationCommand = new AsyncCommand(RemoveOperation);
        }
    }
}
