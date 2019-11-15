using DevExpress.Mvvm;
using DataLayer;
using DataLayer.Entities.Detailing;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Detailing;
using Supervision.Views.EntityViews.DetailViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class BronzeSleeveShutterEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<string> materials;
        private List<string> drawings;
        private List<BronzeSleeveShutterTCP> points;
        private List<Inspector> inspectors;

        private BronzeSleeveShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public BronzeSleeveShutter SelectedItem
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
                            db.BronzeSleeveShutters.Update(SelectedItem);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.BronzeSleeveShutterJournals);
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
                    var wn = new BaseDetailView();
                    var vm = new BronzeSleeveShutterViewModel();
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
        public List<BronzeSleeveShutterTCP> Points
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


        public BronzeSleeveShutterEditViewModel(BronzeSleeveShutter selected)
        {
            db = new DataContext();
            SelectedItem = selected;
            SelectedItem.BronzeSleeveShutterJournals = db.BronzeSleeveShutterJournals.Where(i => i.BronzeSleeveShutterId == selected.Id).ToList();
            Materials = db.BronzeSleeveShutters.Select(d => d.Material).Distinct().ToList();
            Drawings = db.BronzeSleeveShutters.Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.BronzeSleeveShutterTCPs.ToList();
        }
    }
}
