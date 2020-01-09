using DataLayer;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.MaterialViews;
using DataLayer.TechnicalControlPlans;
using DataLayer.Journals;
using Supervision.Views.EntityViews;

namespace Supervision.ViewModels
{
    public class PIDEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<PIDTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<PIDJournal> journal;
        private readonly BaseTable parentEntity;
        private PIDTCP selectedTCPPoint;

        private PID selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private IEnumerable<ProductType> productTypes;
        private IEnumerable<string> designations;

        public PID SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<PIDJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<PIDTCP> Points
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
                            db.PIDs.Update(SelectedItem);
                            db.SaveChanges();
                            if (Journal != null)
                            {
                                foreach (var i in Journal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                }
                                db.PIDJournals.UpdateRange(Journal);
                            }
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
                        if (!(parentEntity is PID)) w?.Close();
                        else
                        {
                            var wn = new SpecificationView();
                            var vm = new SpecificationVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
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
                            var item = new PIDJournal()
                            {
                                DetailNumber = SelectedItem.Number,
                                DetailName = "PID",
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.PIDJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.PIDJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                            SelectedTCPPoint = null;
                        }
                    }));
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

        public PIDTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ProductType> ProductTypes
        {
            get => productTypes;
            set
            {
                productTypes = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> Designations
        {
            get => designations;
            set
            {
                designations = value;
                RaisePropertyChanged();
            }
        }

        public PIDEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.PIDs.Include(i => i.BaseAssemblyUnits).Include(i => i.Specification).ThenInclude(i => i.Customer).SingleOrDefault(i => i.Id == id);
            Designations = db.PIDs.Select(i => i.Designation).Distinct().OrderBy(i => i).ToList();
            SelectedItem.AmountShipped = SelectedItem.BaseAssemblyUnits.Where(i => i.Status == "Отгружен").Count();
            Journal = db.Set<PIDJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            ProductTypes = db.ProductTypes.OrderBy(i => i.Name).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.PIDTCPs.Include(i => i.OperationType).ToList();
        }
    }
}
