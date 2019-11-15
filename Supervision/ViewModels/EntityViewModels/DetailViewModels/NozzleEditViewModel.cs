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
    public class NozzleEditViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private List<string> materials;
        private List<string> drawings;
        private List<string> diameter;
        private List<string> thickness;
        private List<string> thicknessJoin;
        private List<NozzleTCP> points;
        private List<Inspector> inspectors;

        private Nozzle selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;

        public Nozzle SelectedItem
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
                            db.Nozzles.Update(SelectedItem);
                            db.SaveChanges();
                            db.UpdateRange(SelectedItem.NozzleJournals);
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
                        var vm = new NozzleViewModel();
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
        public List<string> Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
                RaisePropertyChanged("Diameter");
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


        public NozzleEditViewModel(Nozzle selected)
        {
            db = new DataContext();
            SelectedItem = selected;
            SelectedItem.NozzleJournals = db.NozzleJournals.Where(i => i.NozzleId == selected.Id).ToList();
            Materials = db.Nozzles.Select(d => d.Material).Distinct().ToList();
            Drawings = db.Nozzles.Select(s => s.Drawing).Distinct().ToList();
            Diameter = db.Nozzles.Select(d => d.Diameter).Distinct().ToList();
            Thickness = db.Nozzles.Select(d => d.Thickness).Distinct().ToList();
            ThicknessJoin = db.Nozzles.Select(d => d.ThicknessJoin).Distinct().ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();  
            Points = db.NozzleTCPs.ToList();
        }
    }
}
