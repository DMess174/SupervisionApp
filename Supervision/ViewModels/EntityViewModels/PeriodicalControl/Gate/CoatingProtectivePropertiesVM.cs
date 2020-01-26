using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using DevExpress.Mvvm;

namespace Supervision.ViewModels.EntityViewModels.Periodical.Gate
{
    public class CoatingProtectivePropertiesVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoatingProtectivePropertiesTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CoatingProtectivePropertiesJournal> journal;
        private CoatingProtectivePropertiesTCP selectedTCPPoint;
        private DateTime lastInspection;
        private DateTime nextInspection;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public IEnumerable<CoatingProtectivePropertiesJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public DateTime LastInspection
        {
            get => lastInspection;
            set
            {
                lastInspection = value;
                RaisePropertyChanged();
            }
        }
        public DateTime NextInspection
        {
            get => nextInspection;
            set
            {
                nextInspection = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingProtectivePropertiesTCP> Points
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
                    db.Set<CoatingProtectivePropertiesJournal>().UpdateRange(Journal);
                    db.SaveChanges();
                    if (Journal != null)
                    {
                        LastInspection = Convert.ToDateTime(db.CoatingProtectivePropertiesJournals.Select(i => i.Date).Max());
                        NextInspection = LastInspection.AddYears(3);
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
                        w?.Close();
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
                            var item = new CoatingProtectivePropertiesJournal()
                            {
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<CoatingProtectivePropertiesJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<CoatingProtectivePropertiesJournal>().OrderByDescending(x => x.Date).ToList();
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

        public CoatingProtectivePropertiesTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public CoatingProtectivePropertiesVM()
        {
            db = new DataContext();
            Journal = db.Set<CoatingProtectivePropertiesJournal>().OrderByDescending(x => x.Date).ToList();
            if (Journal != null)
            {
                LastInspection = Convert.ToDateTime(db.CoatingProtectivePropertiesJournals.Select(i => i.Date).Max());
                NextInspection = LastInspection.AddYears(3);
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<CoatingProtectivePropertiesTCP>().ToList();
        }
    }
}
