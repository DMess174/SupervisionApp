using BusinessLayer;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Supervision.Views.EntityViews.DetailViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class BaseDetailEditVM<TEntity, TUser, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : BaseDetail, new()
        where TUser : Inspector
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {

        private readonly DataContext db;
        private List<string> journalNumbers;
        private List<string> materials;
        private List<string> drawings;
        private List<TEntityTCP> points;
        private List<TUser> inspectors;
        private IEnumerable<TEntityJournal> journal;

        private TEntity selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addItem;

        public TEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntityJournal> Journal
        {
            get { return journal; }
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public List<TEntityTCP> Points
        {
            get { return points; }
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public List<TUser> Inspectors
        {
            get { return inspectors; }
            set
            {
                inspectors = value;
                RaisePropertyChanged("Inspectors");
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
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<TEntityJournal>().UpdateRange(Journal);
                            db.SaveChanges();
                            
                        }
                        else
                        {
                            MessageBox.Show("Объект не найден!", "Ошибка");
                        }

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
                        var wn = new BaseDetailView();
                        var vm = new BaseDetailVM<TEntity, TEntityTCP, TEntityJournal>();
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
                    }));
            }
        }
        public ICommand AddItem
        {
            get
            {
                return addItem ?? (
                    addItem = new DelegateCommand(() =>
                    {
                        
                        var item = new TEntityJournal()
                        {
                            DetailDrawing = SelectedItem.Drawing,
                            DetailNumber = SelectedItem.Number,
                            DetailName = SelectedItem.Name,
                            DetailId = SelectedItem.Id,
                        };
                        db.Set<TEntityJournal>().Add(item);
                        db.SaveChanges();
                        Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                    }));
            }
        }

        public List<string> Materials
        {
            get { return materials; }
            set
            {
                materials = value;
                RaisePropertyChanged("Materials");
            }
        }
        public List<string> Drawings
        {
            get { return drawings; }
            set
            {
                drawings = value;
                RaisePropertyChanged("Drawings");
            }
        }
        public List<string> JournalNumbers
        {
            get { return journalNumbers; }
            set
            {
                journalNumbers = value;
                RaisePropertyChanged("JournalNumbers");
            }
        }




        public BaseDetailEditVM(int id)
        {
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Find(id);
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.Set<TEntity>().Select(d => d.Material).Distinct().ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Set<TUser>().OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
        }
    }
}
