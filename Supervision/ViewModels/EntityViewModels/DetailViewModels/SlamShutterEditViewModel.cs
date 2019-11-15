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
    public class SlamShutterEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<string> materials;
        private List<string> drawings;
        private List<SlamShutterTCP> points;
        private List<Inspector> inspectors;

        private SlamShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public SlamShutter SelectedItem
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
                            db.SlamShutters.Update(SelectedItem);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.SlamShutterJournals);
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
                        var wn = new SlamShutterView();
                        var vm = new SlamShutterViewModel();
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
        public List<SlamShutterTCP> Points
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


        public SlamShutterEditViewModel(SlamShutter selected)
        {
            db = new DataContext();
            SelectedItem = selected;
            SelectedItem.SlamShutterJournals = db.SlamShutterJournals.Where(i => i.SlamShutterId == selected.Id).ToList();
            Materials = db.SlamShutters.Select(d => d.Material).Distinct().ToList();
            Drawings = db.SlamShutters.Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.SlamShutterTCPs.ToList();
        }
    }
}
