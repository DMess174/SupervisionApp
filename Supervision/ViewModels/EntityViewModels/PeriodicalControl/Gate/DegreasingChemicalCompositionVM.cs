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
    public class DegreasingChemicalCompositionVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<DegreasingChemicalCompositionTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<DegreasingChemicalCompositionJournal> journal;
        private DegreasingChemicalCompositionTCP selectedTCPPoint;
        private DateTime lastInspection;
        private DateTime nextInspection;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public IEnumerable<DegreasingChemicalCompositionJournal> Journal
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
        public IEnumerable<DegreasingChemicalCompositionTCP> Points
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
                    db.Set<DegreasingChemicalCompositionJournal>().UpdateRange(Journal);
                    db.SaveChanges();
                    if (Journal != null)
                    {
                        LastInspection = Convert.ToDateTime(db.DegreasingChemicalCompositionJournals.Select(i => i.Date).Max());
                        NextInspection = LastInspection.AddMonths(1);
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
                            var item = new DegreasingChemicalCompositionJournal()
                            {
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<DegreasingChemicalCompositionJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<DegreasingChemicalCompositionJournal>().OrderByDescending(x => x.Date).ToList();
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

        public DegreasingChemicalCompositionTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public DegreasingChemicalCompositionVM()
        {
            db = new DataContext();
            Journal = db.Set<DegreasingChemicalCompositionJournal>().OrderByDescending(x => x.Date).ToList();
            if (Journal != null)
            {
                LastInspection = Convert.ToDateTime(db.DegreasingChemicalCompositionJournals.Select(i => i.Date).Max());
                NextInspection = LastInspection.AddMonths(1);
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<DegreasingChemicalCompositionTCP>().ToList();
        }
    }
}
