using DataLayer;
using DataLayer.Entities.Detailing;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using DataLayer.Journals.Detailing;
using Supervision.Views.EntityViews.DetailViews;
using DataLayer.TechnicalControlPlans.Detailing;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class NozzleViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private ObservableCollection<Nozzle> allInstances;
        private ICollectionView allInstancesView;
        private Nozzle selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand closeWindow;

        private string number = string.Empty;
        private string drawing = string.Empty;
        private string material = string.Empty;
        private string certificate = string.Empty;
        private string melt = string.Empty;
        private string status = string.Empty;

        #region Filters
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Number != null)
                        {
                            return item.Number.ToLower().Contains(Number.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Drawing
        {
            get { return drawing; }
            set
            {
                drawing = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Drawing != null)
                        {
                            return item.Drawing.ToLower().Contains(Drawing.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Material
        {
            get { return material; }
            set
            {
                material = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Material != null)
                        {
                            return item.Material.ToLower().Contains(Material.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Certificate
        {
            get { return certificate; }
            set
            {
                certificate = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Certificate != null)
                        {
                            return item.Certificate.ToLower().Contains(Certificate.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Melt
        {
            get { return melt; }
            set
            {
                melt = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Melt != null)
                        {
                            return item.Melt.ToLower().Contains(Melt.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Nozzle item)
                    {
                        if (item.Status != null)
                        {
                            return item.Status.ToLower().Contains(Status.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                AllInstancesView.Refresh();
            }
        }
        #endregion

        #region Commands              
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
        public ICommand EditItem
        {
            get
            {
                return editItem ?? (
                    editItem = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedItem != null)
                        {
                            var wn = new NozzleEditView();
                            var vm = new NozzleEditViewModel(SelectedItem);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }


        public ICommand AddItem
        {
            get
            {
                return addItem ?? (
                    addItem = new DelegateCommand<Window>((w) =>
                    {
                        var item = new Nozzle();
                        db.Nozzles.Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.NozzleTCPs.ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new NozzleJournal()
                            {
                                NozzleId = SelectedItem.Id,
                                NozzleTCPId = i.Id
                            };
                            if (journal != null)
                            {
                                db.NozzleJournals.Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new NozzleEditView();
                        var vm = new NozzleEditViewModel(SelectedItem);
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
                    }));
            }
        }
        public ICommand RemoveItem
        {
            get
            {
                return removeItem ?? (
                    removeItem = new DelegateCommand (() =>
                    {
                            if (SelectedItem != null)
                            {
                                db.Nozzles.Remove(SelectedItem);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Объект не выбран!", "Ошибка");
                    }));
            }
        }
        #endregion

        public Nozzle SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<Nozzle> AllInstances
        {
            get { return allInstances; }
            set
            {
                allInstances = value;
                RaisePropertyChanged("AllInstances");
            }
        }
        public ICollectionView AllInstancesView
        {
            get { return allInstancesView; }
            set
            {
                allInstancesView = value;
                RaisePropertyChanged("AllInstancesView");
            }
        }

        public NozzleViewModel()
        {
            db = new DataContext();
            db.Nozzles.Load();
            AllInstances = db.Nozzles.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
