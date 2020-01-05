using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;

namespace Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating
{
    public class BaseAnticorrosiveCoatingEditVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : BaseAnticorrosiveCoating, new()
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> names;
        private IEnumerable<string> colors;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<TEntityJournal> journal;
        private readonly BaseTable parentEntity;
        private TEntity selectedItem;
        private TEntityTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityTCP> Points
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

        public ICommand SaveItem
        {
            get
            {
                return saveItem ?? (
                    saveItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.Set<TEntity>().Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in Journal)
                            {
                                i.DetailNumber = SelectedItem.Name;
                                i.DetailDrawing = SelectedItem.Batch;
                            }
                            db.Set<TEntityJournal>().UpdateRange(Journal);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не найден!", "Ошибка");
                    }));
            }
        }
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        if (parentEntity is TEntity)
                        {
                            var wn = new BaseAnticorrosiveCoatingView();
                            var vm = new BaseAnticorrosiveCoatingVM<TEntity, TEntityTCP, TEntityJournal>();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else w?.Close();
                    }));
            }
        }
        public ICommand AddOperation
        {
            get
            {
                return addOperation ?? (
                    addOperation = new DelegateCommand(() =>
                    {
                        if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                        else
                        {
                            var item = new TEntityJournal()
                            {
                                DetailDrawing = SelectedItem.Name,
                                DetailNumber = SelectedItem.Batch,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<TEntityJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
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

        public TEntityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public BaseAnticorrosiveCoatingEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Include(i => i.BaseValveWithCoatings).Include(i => i.ReverseShutterWithCoatings).SingleOrDefault(i => i.Id == id);
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Names = db.Set<TEntity>().Select(s => s.Name).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
            if (SelectedItem is AbovegroundCoating)
                Colors = db.AbovegroundCoatings.Select(s => s.Color).Distinct().OrderBy(x => x).ToList();
        }
    }
}
