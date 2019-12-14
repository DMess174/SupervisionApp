using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class CastingCaseEditVM<TEntity, TUser, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : BaseCastingCase, new()
        where TUser : Inspector
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<TUser> inspectors;
        private IEnumerable<TEntityJournal> journal;

        private TEntity selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private IEnumerable<Nozzle> nozzles;
        private Nozzle selectedNozzle; 
        private Nozzle selectedNozzleFromList;
        private ICommand editNozzle;
        private ICommand addNozzleToCase;
        private ICommand deleteNozzleFromCase;
        private TEntityTCP selectedTCPPoint;

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntityJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<TEntityTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public IEnumerable<TUser> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged("Inspectors");
            }
        }

        public Nozzle SelectedNozzle
        {
            get => selectedNozzle;
            set
            {
                selectedNozzle = value;
                RaisePropertyChanged("SelectedNozzle");
            }
        }

        public Nozzle SelectedNozzleFromList
        {
            get => selectedNozzleFromList;
            set
            {
                selectedNozzleFromList = value;
                RaisePropertyChanged("SelectedNozzleFromList");
            }
        }

        public ICommand EditNozzle
        {
            get
            {
                return editNozzle ?? (
                    editNozzle = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedNozzleFromList != null)
                        {
                            var wn = new NozzleEditView();
                            var vm = new NozzleEditVM(SelectedNozzleFromList.Id, SelectedItem);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand DeleteNozzleFromCase
        {
            get
            {
                return deleteNozzleFromCase ?? (
                    deleteNozzleFromCase = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedNozzleFromList != null)
                        {
                            var item = SelectedNozzleFromList;
                            item.CastingCaseId = null;
                            db.Nozzles.Update(item);
                            db.SaveChanges();
                            Nozzles = null;
                            Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
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
                            if (Journal != null)
                            {
                                foreach (var i in Journal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }

                                db.Set<TEntityJournal>().UpdateRange(Journal);
                            }
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
                        var wn = new CastingCaseView();
                        var vm = new CastingCaseVM<TEntity, TEntityTCP, TEntityJournal>();
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
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
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
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

        public TEntityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public ICommand AddNozzleToCase
        {
            get
            {
                return addNozzleToCase ?? (
                    addNozzleToCase = new DelegateCommand(() =>
                    {
                        if (SelectedItem.Nozzles.Count() < 2)
                        {
                            if (SelectedNozzle != null)
                            {
                                var item = SelectedNozzle;
                                item.CastingCaseId = SelectedItem.Id;
                                db.Nozzles.Update(item);
                                db.SaveChanges();
                                Nozzles = null;
                                Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();
                            }
                            else MessageBox.Show("Объект не выбран!", "Ошибка");
                        }
                        else MessageBox.Show("Невозможно привязать более 2 катушек!", "Ошибка");
                    }));
            }
        }

        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged("Materials");
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged("Drawings");
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged("JournalNumbers");
            }
        }

        public IEnumerable<Nozzle> Nozzles
        {
            get => nozzles;
            set
            {
                nozzles = value;
                RaisePropertyChanged("Nozzles");
            }
        }

        public CastingCaseEditVM(int id)
        {
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Find(id);
            db.Nozzles.Load();
            SelectedItem.Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == SelectedItem.Id).ToObservableCollection();
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.Set<TEntity>().Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Set<TUser>().OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
            Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();

        }
    }
}
