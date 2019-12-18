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
    class ProductTypeViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<ProductType> allInstances;
        private ICollectionView allInstancesView;
        private ProductType selectedItem;
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
                                ProductType item = new ProductType();
                                db.ProductTypes.Add(item);
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
                                    db.ProductTypes.UpdateRange(AllInstances);
                                    db.SaveChanges();
                                }
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
                                    db.ProductTypes.Remove(SelectedItem);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }

        public ProductType SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<ProductType> AllInstances
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

        public ProductTypeViewModel()
        {
            db = new DataContext();
            db.ProductTypes.OrderBy(i => i.Name).Load();
            AllInstances = db.ProductTypes.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
