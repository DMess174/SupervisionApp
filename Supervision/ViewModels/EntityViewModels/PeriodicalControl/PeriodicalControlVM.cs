using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Periodical;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.MaterialViews;
using Supervision.Views.EntityViews.PeriodicalControl;

namespace Supervision.ViewModels.EntityViewModels.Periodical
{
    public class PeriodicalControlVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : PeriodicalControl, new()
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
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
        

        private string findByName = "";
        private string status = "";
        private string productType = "";

        #region Filter
        public string FindByName
        {
            get => findByName;
            set
            {
                findByName = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Name != null)
                    {
                        return item.Name.ToLower().Contains(FindByName.ToLower());
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
        public string ProductType
        {
            get => productType;
            set
            {
                productType = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.ProductType != null)
                    {
                        return item.ProductType.Name.ToLower().Contains(ProductType.ToLower());
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
                            var wn = new PeriodicalControlEditView();
                            var vm = new PeriodicalControlEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id, SelectedItem);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand CopyItem
        {
            get
            {
                return copyItem ?? (
                    copyItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            var item = new TEntity()
                            {
                                Status = SelectedItem.Status,
                                Name = SelectedItem.Name,
                                Comment = SelectedItem.Comment
                            };
                            db.Set<TEntity>().Add(item);
                            db.SaveChanges();
                            var Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).ToList();
                            foreach (var record in Journal)
                            {
                                var Record = new TEntityJournal()
                                {
                                    Date = record.Date,
                                    DetailId = item.Id,
                                    Description = record.Description,
                                    DetailName = item.Name,
                                    DetailDrawing = item.ProductType.Name,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    RemarkIssued = record.RemarkIssued,
                                    RemarkClosed = record.RemarkClosed,
                                    Comment = record.Comment,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber,
                                };
                                db.Set<TEntityJournal>().Add(Record);
                                db.SaveChanges();
                            }

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
                        var wn = new PeriodicalControlEditView();
                        var vm = new PeriodicalControlEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id, SelectedItem);
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

        public PeriodicalControlVM()
        {
            db = new DataContext();
            db.Set<TEntity>().Load();
            AllInstances = db.Set<TEntity>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
