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
    public class CoatingChemicalCompositionVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoatingChemicalCompositionTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CoatingChemicalCompositionJournal> journal;
        private CoatingChemicalCompositionTCP selectedTCPPoint;
        private DateTime lastInspection;
        private DateTime nextInspection;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public IEnumerable<CoatingChemicalCompositionJournal> Journal
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
        public IEnumerable<CoatingChemicalCompositionTCP> Points
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
                    db.Set<CoatingChemicalCompositionJournal>().UpdateRange(Journal);
                    db.SaveChanges();
                    if (Journal != null)
                    {
                        LastInspection = Convert.ToDateTime(db.CoatingChemicalCompositionJournals.Select(i => i.Date).Max());
                        NextInspection = LastInspection.AddDays(7);
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
                            var item = new CoatingChemicalCompositionJournal()
                            {
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<CoatingChemicalCompositionJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<CoatingChemicalCompositionJournal>().OrderByDescending(x => x.Date).ToList();
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

        public CoatingChemicalCompositionTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public CoatingChemicalCompositionVM()
        {
            db = new DataContext();
            Journal = db.Set<CoatingChemicalCompositionJournal>().OrderByDescending(x => x.Date).ToList();
            if (Journal != null)
            {
                LastInspection = Convert.ToDateTime(db.CoatingChemicalCompositionJournals.Select(i => i.Date).Max());
                NextInspection = LastInspection.AddDays(7);
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<CoatingChemicalCompositionTCP>().ToList();
        }
    }
}
