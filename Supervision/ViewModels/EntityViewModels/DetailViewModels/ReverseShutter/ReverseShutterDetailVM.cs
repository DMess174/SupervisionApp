using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class ReverseShutterDetailVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : ReverseShutterDetail, new()
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
        private ICommand copyItem;
        private ICommand closeWindow;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";
        private string certificate = "";

        #region Filter
        public string Number 
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged("Number");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Drawing
        {
            get => drawing;
            set
            {
                drawing = value;
                RaisePropertyChanged("Drawing");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Drawing != null)
                    {
                        return item.Drawing.ToLower().Contains(Drawing.ToLower());
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
                RaisePropertyChanged("Status");
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
        public string Certificate
        {
            get => certificate;
            set
            {
                certificate = value;
                RaisePropertyChanged("Certificate");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is TEntity item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
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
                            var wn = new ReverseShutterDetailEditView();
                            var vm = new ReverseShutterDetailEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id);
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
                                Number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер детали:"),
                                Drawing = SelectedItem.Drawing,
                                Certificate = SelectedItem.Certificate,
                                Status = SelectedItem.Status,
                                Name = SelectedItem.Name
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
                                    DetailNumber = item.Number,
                                    DetailDrawing = item.Drawing,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    Remark = record.Remark,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber
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
                        var tcpPoints = db.Set<TEntityTCP>().ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new TEntityJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                DetailName = SelectedItem.Name,
                                DetailNumber = SelectedItem.Number,
                                DetailDrawing = SelectedItem.Drawing,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                db.Set<TEntityJournal>().Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new ReverseShutterDetailEditView();
                        var vm = new ReverseShutterDetailEditVM<TEntity, TEntityTCP, TEntityJournal>(SelectedItem.Id);
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
                RaisePropertyChanged("Name");
            }
        }

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntity> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged("AllInstances");
            }
        }
        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged("AllInstancesView");
            }
        }

        public ReverseShutterDetailVM()
        {
            db = new DataContext();
            db.Set<TEntity>().Load();
            AllInstances = db.Set<TEntity>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            if (AllInstances.Count() != 0)
            {
                Name = AllInstances.First().Name;
            }
        }
    }
}
