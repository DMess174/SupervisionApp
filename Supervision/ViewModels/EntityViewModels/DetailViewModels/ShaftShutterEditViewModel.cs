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
    public class ShaftShutterEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<string> materials;
        private List<string> drawings;
        private List<ShaftShutterTCP> points;
        private List<Inspector> inspectors;

        private ShaftShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public ShaftShutter SelectedItem
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
                            db.ShaftShutters.Update(SelectedItem);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.ShaftShutterJournals);
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
                        var wn = new ShaftShutterView();
                        var vm = new ShaftShutterViewModel();
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
        public List<ShaftShutterTCP> Points
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


        public ShaftShutterEditViewModel(ShaftShutter selected)
        {
            db = new DataContext();
            SelectedItem = selected;
            SelectedItem.ShaftShutterJournals = db.ShaftShutterJournals.Where(i => i.ShaftShutterId == selected.Id).ToList();
            Materials = db.ShaftShutters.Select(d => d.Material).Distinct().ToList();
            Drawings = db.ShaftShutters.Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.ShaftShutterTCPs.ToList();
        }
    }
}
