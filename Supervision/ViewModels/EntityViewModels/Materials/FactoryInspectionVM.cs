using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Journals;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Materials;
using DevExpress.Mvvm;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class FactoryInspectionVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<FactoryInspectionTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<FactoryInspectionJournal> journal;
        private FactoryInspectionTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public IEnumerable<FactoryInspectionJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<FactoryInspectionTCP> Points
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
                    db.Set<FactoryInspectionJournal>().UpdateRange(Journal);
                    db.SaveChanges();
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
                            var item = new FactoryInspectionJournal()
                            {
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<FactoryInspectionJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<FactoryInspectionJournal>().OrderByDescending(x => x.Date).ToList();
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

        public FactoryInspectionTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public FactoryInspectionVM()
        {
            db = new DataContext();
            Journal = db.Set<FactoryInspectionJournal>().OrderByDescending(x => x.Date).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<FactoryInspectionTCP>().ToList();
        }
    }
}
