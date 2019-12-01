using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm;
using Supervision.Views.EntityViews.DetailViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class NozzleEditVM : BasePropertyChanged
    {

        private readonly DataContext db;
        private List<string> journalNumbers;
        private List<string> materials;
        private List<string> drawings;
        private List<string> thickness;
        private List<string> thicknessJoin;
        private List<string> diameter;
        private List<NozzleTCP> points;
        private List<Inspector> inspectors;
        private IEnumerable<NozzleJournal> journal;

        private Nozzle selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addItem;

        public Nozzle SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<NozzleJournal> Journal
        {
            get { return journal; }
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public List<NozzleTCP> Points
        {
            get { return points; }
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public List<Inspector> Inspectors
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
                            db.Nozzles.Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in Journal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.NozzleJournals.UpdateRange(Journal);
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
                        var wn = new NozzleView();
                        var vm = new NozzleVM();
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
                        
                        var item = new NozzleJournal()
                        {
                            DetailDrawing = SelectedItem.Drawing,
                            DetailNumber = SelectedItem.Number,
                            DetailName = SelectedItem.Name,
                            DetailId = SelectedItem.Id,
                        };
                        db.NozzleJournals.Add(item);
                        db.SaveChanges();
                        Journal = db.NozzleJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
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

        public List<string> Thickness
        {
            get { return thickness; }
            set
            {
                thickness = value;
                RaisePropertyChanged("Thickness");
            }
        }

        public List<string> ThicknessJoin
        {
            get { return thicknessJoin; }
            set
            {
                thicknessJoin = value;
                RaisePropertyChanged("ThicknessJoin");
            }
        }

        public List<string> Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
                RaisePropertyChanged("Diameter");
            }
        }

        public NozzleEditVM(int id)
        {
            db = new DataContext();
            SelectedItem = db.Nozzles.Find(id);
            Journal = db.NozzleJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.Nozzles.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.Nozzles.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Thickness = db.Nozzles.Select(t => t.Thickness).Distinct().OrderBy(x => x).ToList();
            ThicknessJoin = db.Nozzles.Select(t => t.ThicknessJoin).Distinct().OrderBy(x => x).ToList();
            Diameter = db.Nozzles.Select(d => d.Diameter).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.NozzleTCPs.ToList();
        }
    }
}
