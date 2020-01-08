using System.Collections.Generic;
using DevExpress.Mvvm;
using DataLayer;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace Supervision.ViewModels
{
    class CustomerVM : BasePropertyChanged
    {
        private DataContext db;
        private IEnumerable<Customer> allInstances;
        private ICollectionView allInstancesView;
        private Customer selectedItem;
        private ICommand addItem;
        private ICommand saveItem;
        private ICommand removeItem;

        public ICommand AddItem
        {
            get
            {
                return addItem ??
                    (
                    addItem = new DelegateCommand(() =>
                            {
                                Customer item = new Customer();
                                db.Customers.Add(item);
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
                                    db.Customers.UpdateRange(AllInstances);
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
                                    db.Customers.Remove(SelectedItem);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }

        public Customer SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Customer> AllInstances
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

        public CustomerVM()
        {
            db = new DataContext();
            db.Customers.OrderBy(i => i.Name).Load();
            AllInstances = db.Customers.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
