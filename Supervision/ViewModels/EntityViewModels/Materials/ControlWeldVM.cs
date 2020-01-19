using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Materials;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class ControlWeldVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : ControlWeld, new()
        where TEntityTCP : ControlWeldTCP
        where TEntityJournal : ControlWeldJournal, new()
    {
        private readonly DataContext db;
        private IEnumerable<TEntity> allInstances;
        private ICollectionView allInstancesView;
        private TEntity selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand copyItem;
        private ICommand closeWindow;

        private string name;
        private string number = "";
        private string weldingMethod = "";
        private string status = "";

        #region Filter
        public string Number 
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Name != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Status
        {
            get => status;
            set
            {
                status = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string WeldingMethod
        {
            get => weldingMethod;
            set
            {
                weldingMethod = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.WeldingMethod != null)
                    {
                        return item.WeldingMethod.ToLower().Contains(WeldingMethod.ToLower());
                    }
                    else return false;
                };
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
                            var wn = new ControlWeldEditView();
                            var vm = new ControlWeldEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id, SelectedItem);
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
                        var tcpPoints = db.Set<TEntityTCP>().ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new TEntityJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                DetailName = SelectedItem.Name,
                                DetailNumber = SelectedItem.Number,
                                Point = i.Point,
                                Description = i.Description,
                            };
                            if (journal != null)
                            {
                                db.Set<TEntityJournal>().Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new ControlWeldEditView();
                        var vm = new ControlWeldEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id, SelectedItem);
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

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<TEntity> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged();
            }
        }
        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged();
            }
        }

        public ControlWeldVM()
        {
            db = new DataContext();
            db.Set<TEntity>().Load();
            AllInstances = db.Set<TEntity>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            if (AllInstances.Any())
            {
                Name = AllInstances.First().Name;
            }
        }
    }
}
