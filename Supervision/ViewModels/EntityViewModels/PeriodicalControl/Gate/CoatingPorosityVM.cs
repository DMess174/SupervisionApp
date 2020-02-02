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
    public class CoatingPorosityVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoatingPorosityTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CoatingPorosityJournal> journal;
        private CoatingPorosityTCP selectedTCPPoint;
        private DateTime lastInspection;
        private DateTime nextInspection;
        private int shippedAmount;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public IEnumerable<CoatingPorosityJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public int ShippedAmount
        {
            get => shippedAmount;
            set
            {
                shippedAmount = value;
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
        public IEnumerable<CoatingPorosityTCP> Points
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
                    db.Set<CoatingPorosityJournal>().UpdateRange(Journal);
                    db.SaveChanges();
                    if (Journal != null)
                    {
                        LastInspection = Convert.ToDateTime(db.CoatingPorosityJournals.Select(i => i.Date).Max());
                        NextInspection = LastInspection.AddYears(1);
                        ShippedAmount = Convert.ToInt32(db.GateJournals.Where(i => i.Date > LastInspection && i.EntityTCP.OperationType.Name == "Отгрузка").Select(i => i.DetailId).Distinct().Count());
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
                            var item = new CoatingPorosityJournal()
                            {
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<CoatingPorosityJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<CoatingPorosityJournal>().OrderByDescending(x => x.Date).ToList();
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

        public CoatingPorosityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public CoatingPorosityVM()
        {
            db = new DataContext();
            Journal = db.Set<CoatingPorosityJournal>().OrderByDescending(x => x.Date).ToList();
            if (Journal != null)
            {
                LastInspection = Convert.ToDateTime(db.CoatingPorosityJournals.Select(i => i.Date).Max());
                NextInspection = LastInspection.AddYears(1);
                ShippedAmount = Convert.ToInt32(db.GateJournals.Where(i => i.Date > LastInspection && i.EntityTCP.OperationType.Name == "Отгрузка").Select(i => i.DetailId).Distinct().Count());
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<CoatingPorosityTCP>().ToList();
            
        }
    }
}
