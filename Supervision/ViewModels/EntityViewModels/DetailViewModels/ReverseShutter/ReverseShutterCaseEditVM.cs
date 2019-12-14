using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class ReverseShutterCaseEditVM : BasePropertyChanged
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ReverseShutterCaseTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ReverseShutterCaseJournal> journal;

        private ReverseShutterCase selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private IEnumerable<Nozzle> nozzles;
        private Nozzle selectedNozzle; 
        private Nozzle selectedNozzleFromList;
        private ICommand editNozzle;
        private ICommand addNozzleToCase;
        private ICommand deleteNozzleFromCase;
        private ReverseShutterCaseTCP selectedTCPPoint;

        public ReverseShutterCase SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<ReverseShutterCaseJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<ReverseShutterCaseTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public IEnumerable<Inspector> Inspectors
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
                            db.ReverseShutterCases.Update(SelectedItem);
                            db.SaveChanges();
                            if (Journal != null)
                            {
                                foreach (var i in Journal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }

                                db.ReverseShutterCaseJournals.UpdateRange(Journal);
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
                        var vm = new ReverseShutterCaseVM();
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
                            var item = new ReverseShutterCaseJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.ReverseShutterCaseJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.ReverseShutterCaseJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        public ReverseShutterCaseTCP SelectedTCPPoint
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

        public ReverseShutterCaseEditVM(int id)
        {
            db = new DataContext();
            SelectedItem = db.ReverseShutterCases
                .Include(i => i.ReverseShutter)
                .SingleOrDefault(i => i.Id == id);
            if (SelectedItem != null)
            {
                db.Nozzles.Load();
                SelectedItem.Nozzles = db.Nozzles.Local
                    .Where(i => i.CastingCaseId == SelectedItem.Id)
                    .ToObservableCollection();
                Journal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id)
                    .OrderBy(x => x.PointId).ToList();
            }
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.ReverseShutterCases.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.ReverseShutterCases.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.ReverseShutterCaseTCPs.ToList();
            Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();

        }
    }
}
