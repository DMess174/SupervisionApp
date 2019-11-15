using BusinessLayer;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class BaseDetailVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : BaseDetail, new()
        where TEntityJournal : BaseJournal<TEntity,TEntityTCP>, new()
        where TEntityTCP : BaseTCP
    {
        private readonly DataContext db;
        private IEnumerable<TEntity> allInstances;
        private ICollectionView allInstancesView;
        private TEntity selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand closeWindow;
        



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
                            var vm = new BaseDetailEditVM<TEntity, Inspector, TEntityTCP, TEntityJournal>(SelectedItem.Id);
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
                        var item = new TEntity();
                        db.Set<TEntity>().Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.BronzeSleeveShutterTCPs.ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new TEntityJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                DetailName = SelectedItem.Name,
                                DetailNumber = SelectedItem.Number,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                db.Set<TEntityJournal>().Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new BaseDetailEditView();
                        var vm = new BaseDetailEditVM<TEntity, Inspector, TEntityTCP, TEntityJournal>(SelectedItem.Id);
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
                    removeItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.Set<TEntity>().Remove(SelectedItem);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не выбран!", "Ошибка");
                    }));
            }
        }
        #endregion

        public TEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntity> AllInstances
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

        public BaseDetailVM()
        {
            db = new DataContext();
            db.Set<TEntity>().Load();
            AllInstances = db.Set<TEntity>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
