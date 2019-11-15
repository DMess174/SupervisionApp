using DataLayer;
using DataLayer.Entities.Detailing;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using DataLayer.Journals.Detailing;
using Supervision.Views.EntityViews.DetailViews;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Windows.Data;
using BusinessLayer;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class BronzeSleeveShutterViewModel : BasePropertyChanged
    {
        private readonly UnitOfWork Base; 
        private readonly DataContext db;
        private IEnumerable<BronzeSleeveShutter> allInstances;
        private ICollectionView allInstancesView;
        private BronzeSleeveShutter selectedItem;
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
                    if (obj is BronzeSleeveShutter item)
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
                    if (obj is BronzeSleeveShutter item)
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
                    if (obj is BronzeSleeveShutter item)
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
                    if (obj is BronzeSleeveShutter item)
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
                    if (obj is BronzeSleeveShutter item)
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
                    if (obj is BronzeSleeveShutter item)
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
                            var wn = new BaseDetailEditView();
                            var vm = new BronzeSleeveShutterEditViewModel(SelectedItem);
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
                        var item = new BronzeSleeveShutter();
                        db.BronzeSleeveShutters.Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.BronzeSleeveShutterTCPs.ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new BronzeSleeveShutterJournal()
                            {
                                BronzeSleeveShutterId = SelectedItem.Id,
                                BronzeSleeveShutterTCPId = i.Id
                            };
                            if (journal != null)
                            {
                                db.BronzeSleeveShutterJournals.Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new BaseDetailEditView();
                        var vm = new BronzeSleeveShutterEditViewModel(SelectedItem);
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
                                Base.BronzeSleeveShutter.Remove(SelectedItem);
                                Base.Complete();
                                //db.BronzeSleeveShutters.Remove(SelectedItem);
                                //db.SaveChanges();
                            }
                            else MessageBox.Show("Объект не выбран!", "Ошибка");
                    }));
            }
        }
        #endregion

        public BronzeSleeveShutter SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<BronzeSleeveShutter> AllInstances
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

        public BronzeSleeveShutterViewModel()
        {
            Base = new UnitOfWork(new DataContext());
            AllInstances = Base.BronzeSleeveShutter.GetAll();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            //db = new DataContext();
            //db.BronzeSleeveShutters.Load();
            //AllInstances = db.BronzeSleeveShutters.Local.ToObservableCollection();
            //AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);


        }
    }
}
