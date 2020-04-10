﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using Supervision.Commands;

namespace Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating
{
    public class AbovegroundCoatingEditVM : ViewModelBase
    {
        private readonly DataContext db;
        private readonly AbovegroundCoatingRepository repo;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> names;
        private IEnumerable<string> colors;
        private IEnumerable<string> factories;
        private IEnumerable<AnticorrosiveCoatingTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<AbovegroundCoatingJournal> journal;
        private readonly BaseTable parentEntity;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private AbovegroundCoating selectedItem;
        private AnticorrosiveCoatingTCP selectedTCPPoint;
        private AbovegroundCoatingJournal operation;
        private IEnumerable<BaseValveWithCoating> valves;
        private IEnumerable<ReverseShutterWithCoating> shutters;

        public IEnumerable<BaseValveWithCoating> Valves
        {
            get => valves;
            set
            {
                valves = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterWithCoating> Shutters
        {
            get => shutters;
            set
            {
                shutters = value;
                RaisePropertyChanged();
            }
        }

        public AbovegroundCoatingJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }
        public AbovegroundCoating SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AbovegroundCoatingJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<AnticorrosiveCoatingTCP> Points
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
 
        public IEnumerable<string> Names
        {
            get => names;
            set
            {
                names = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> Colors
        {
            get => colors;
            set
            {
                colors = value;
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
        public IEnumerable<string> Factories
        {
            get => factories;
            set
            {
                factories = value;
                RaisePropertyChanged();
            }
        }

        public AnticorrosiveCoatingTCP SelectedTCPPoint
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
                SelectedItem = await Task.Run(() => repo.GetByIdIncludeAsync(id));
                Names = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Name));
                Colors = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Color));
                Factories = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Factory));
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Points = await Task.Run(() => repo.GetTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Journal = SelectedItem.AbovegroundCoatingJournals;
                Valves = SelectedItem.BaseValveWithCoatings;
                Shutters = SelectedItem.ReverseShutterWithCoatings;
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
                await Task.Run(() => repo.Update(SelectedItem));
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
                SelectedItem.AbovegroundCoatingJournals.Add(new AbovegroundCoatingJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                Journal = SelectedItem.AbovegroundCoatingJournals;
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
                        SelectedItem.AbovegroundCoatingJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        Journal = SelectedItem.AbovegroundCoatingJournals;
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
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.AbovegroundCoatingJournals))
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

        public static AbovegroundCoatingEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            AbovegroundCoatingEditVM vm = new AbovegroundCoatingEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        public AbovegroundCoatingEditVM(BaseTable entity, DataContext context)
        {
            parentEntity = entity;
            db = new DataContext();
            repo = new AbovegroundCoatingRepository(db);
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
