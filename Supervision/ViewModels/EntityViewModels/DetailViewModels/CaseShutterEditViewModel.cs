using DevExpress.Mvvm;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing;
using BusinessLayer;
using DataLayer.Journals.Detailing;
using Supervision.Views.EntityViews.DetailViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class CaseShutterEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<Nozzle> nozzles;
        private List<string> materials;
        private List<string> drawings;
        private List<CaseShutterTCP> points;
        private List<Inspector> inspectors;

        private CaseShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public CaseShutter SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
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
                            db.CaseShutters.Update(SelectedItem);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.CaseShutterJournals);
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
                        var wn = new CaseShutterView();
                        var vm = new CaseShutterViewModel();
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();

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
        public List<CaseShutterTCP> Points
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
        public List<Nozzle> Nozzles
        {
            get { return nozzles; }
            set
            {
                nozzles = value;
                RaisePropertyChanged("Nozzles");
            }
        }


        public CaseShutterEditViewModel(CaseShutter selected)
        {
            db = new DataContext();
            SelectedItem = db.CaseShutters.Find(selected.Id);
            SelectedItem.CaseShutterJournals = db.CaseShutterJournals.Where(i => i.CaseShutterId == selected.Id).ToList();
            Materials = db.CaseShutters.Select(d => d.Material).Distinct().ToList();
            Drawings = db.CaseShutters.Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.CaseShutterTCPs.ToList();
            Nozzles = db.Nozzles.ToList();
        }
    }
}
