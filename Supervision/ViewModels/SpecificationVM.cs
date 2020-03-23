using System.Collections.Generic;
using DevExpress.Mvvm;
using DataLayer;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews;
using DataLayer.Journals;

namespace Supervision.ViewModels
{
    class SpecificationVM : BasePropertyChanged
    {
        private DataContext db;
        private IEnumerable<Specification> allInstances;
        private ICollectionView allInstancesView;
        private Specification selectedItem;
        private PID selectedPID;
        private ICommand addItem;
        private ICommand saveItem;
        private ICommand removeItem;
        private ICommand addPID;
        private ICommand editPID;
        private ICommand removePID;
        private IEnumerable<Customer> customers;
        private string number = "";

        public string Number
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is Specification item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }

        public ICommand AddItem
        {
            get
            {
                return addItem ??
                    (
                    addItem = new DelegateCommand(() =>
                            {
                                var item = new Specification();
                                db.Specifications.Add(item);
                                db.SaveChanges();
                                SelectedItem = item;
                            })
                    );
            }
        }
        public ICommand SaveItem
        {
            get
            {
                return saveItem ??
                    (
                    saveItem = new DelegateCommand(() =>
                            {
                                if (AllInstances != null)
                                {
                                    db.Specifications.UpdateRange(AllInstances);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Записи отсутствуют!", "Ошибка");
                            })
                    );
            }
        }
        public ICommand RemoveItem
        {
            get
            {
                return removeItem ??
                    (
                    removeItem = new DelegateCommand(() =>
                            {
                                if (SelectedItem != null)
                                {
                                    db.Specifications.Remove(SelectedItem);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }
        public ICommand AddPID
        {
            get
            {
                return addPID ??
                    (
                    addPID = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedItem != null)
                        {
                            var item = new PID()
                            {
                                SpecificationId = SelectedItem.Id,
                            };
                            db.PIDs.Add(item);
                            db.SaveChanges();
                            SelectedPID = item;
                            var tcpPoints = db.PIDTCPs.ToList();
                            foreach (var i in tcpPoints)
                            {
                                var journal = new PIDJournal()
                                {
                                    DetailId = SelectedPID.Id,
                                    PointId = i.Id,
                                    DetailName = "PID",
                                    DetailNumber = SelectedPID.Number,
                                    Point = i.Point,
                                    Description = i.Description
                                };
                                if (journal != null)
                                {
                                    db.PIDJournals.Add(journal);
                                    db.SaveChanges();
                                }
                            }
                            var wn = new PIDEditView();
                            var vm = new PIDEditVM(SelectedPID.Id, SelectedPID);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Выберите спецификацию!", "Ошибка");
                    }));
            }
        }
        public ICommand EditPID
        {
            get
            {
                return editPID ??
                    (
                    editPID = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedItem != null && SelectedPID != null)
                        { 
                            var wn = new PIDEditView();
                            var vm = new PIDEditVM(SelectedPID.Id, SelectedPID);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Выберите PID!", "Ошибка");
                    }));
            }
        }
        public ICommand RemovePID
        {
            get
            {
                return removePID ??
                    (
                    removePID = new DelegateCommand(() =>
                    {
                        if (SelectedPID != null)
                        {
                            var item = db.PIDs.Find(SelectedPID.Id);
                            db.PIDs.Remove(item);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не выбран!", "Ошибка");
                    })
                    );
            }
        }

        public Specification SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public PID SelectedPID
        {
            get => selectedPID;
            set
            {
                selectedPID = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Specification> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
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

        public SpecificationVM()
        {
            db = new DataContext();
            db.Specifications.Include(i => i.PIDs).ThenInclude(i => i.ProductType).OrderBy(i => i.Number).Load();
            AllInstances = db.Specifications.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            Customers = db.Customers.OrderBy(i => i.Name).ToList();
        }
    }
}
