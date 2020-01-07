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
    class SpecificationVM : BasePropertyChanged
    {
        private DataContext db;
        private IEnumerable<Specification> allInstances;
        private ICollectionView allInstancesView;
        private Specification selectedItem;
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

        public Specification SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
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
            db.Specifications.Include(i => i.PIDs).OrderBy(i => i.Number).Load();
            AllInstances = db.Specifications.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
