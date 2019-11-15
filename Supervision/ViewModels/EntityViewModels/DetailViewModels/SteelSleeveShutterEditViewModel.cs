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
    public class SteelSleeveShutterEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<string> materials;
        private List<string> drawings;
        private List<SteelSleeveShutterTCP> points;
        private List<Inspector> inspectors;

        private SteelSleeveShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public SteelSleeveShutter SelectedItem
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
                        SteelSleeveShutter sleeve = SelectedItem;
                        if (sleeve != null)
                        {
                            db.SteelSleeveShutters.Update(sleeve);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.SteelSleeveShutterJournals);
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
                        var wn = new SteelSleeveShutterView();
                        var vm = new SteelSleeveShutterViewModel();
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
        public List<SteelSleeveShutterTCP> Points
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


        public SteelSleeveShutterEditViewModel(SteelSleeveShutter selected)
        {
            db = new DataContext();
            SelectedItem = selected;
            SelectedItem.SteelSleeveShutterJournals = db.SteelSleeveShutterJournals.Where(i => i.SteelSleeveShutterId == selected.Id).ToList();
            Materials = db.SteelSleeveShutters.Select(d => d.Material).Distinct().ToList();
            Drawings = db.SteelSleeveShutters.Select(s => s.Drawing).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.SteelSleeveShutterTCPs.ToList();
        }
    }
}
