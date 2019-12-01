using DevExpress.Mvvm;
using DataLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace Supervision.ViewModels
{
    class InspectorViewModel : BasePropertyChanged
    {
        private readonly DataContext db;
        private ObservableCollection<Inspector> allInstances;
        private ICollectionView allInstancesView;
        private List<string> departments;
        private List<string> subdivisions;
        private Inspector selectedItem;
        private ICommand addItem;
        private ICommand saveItem;
        private ICommand removeItem;
        private string name = string.Empty;
        private string department = string.Empty;
        private string subdivision = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Name != null)
                        {
                            return insp.Name.ToLower().Contains(Name.ToLower());
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
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Department != null)
                        {
                            return insp.Department.ToLower().Contains(Department.ToLower());
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
        public string Subdivision
        {
            get { return subdivision; }
            set
            {
                subdivision = value;
                AllInstancesView.Filter = (obj) =>
                {
                    if (obj is Inspector insp)
                    {
                        if (insp.Subdivision != null)
                        {
                            return insp.Subdivision.ToLower().Contains(Subdivision.ToLower());
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

        public ICommand AddItem
        {
            get
            {
                return addItem ??
                    (
                    addItem = new DelegateCommand
                        (
                            () =>
                            {
                                Inspector item = new Inspector();
                                db.Inspectors.Add(item);
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
                    saveItem = new DelegateCommand
                        (
                            () =>
                            {
                                db.Inspectors.UpdateRange(AllInstances);
                                db.SaveChanges();
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
                    removeItem = new DelegateCommand
                        (
                            () =>
                            {
                                if (SelectedItem != null)
                                {
                                    db.Inspectors.Remove(SelectedItem);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }

        public Inspector SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<Inspector> AllInstances
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

        public List<string> Departments
        {
            get { return departments; }
            set
            {
                departments = value;
                RaisePropertyChanged("Departments");
            }
        }

        public List<string> Subdivisions
        {
            get { return subdivisions; }
            set
            {
                subdivisions = value;
                RaisePropertyChanged("Subdivisions");
            }
        }

        public InspectorViewModel()
        {
            db = new DataContext();
            db.Inspectors.OrderBy(i => i.Name).Load();
            AllInstances = db.Inspectors.Local.ToObservableCollection();
            Departments = AllInstances.Select(d => d.Department).Distinct().ToList();
            Subdivisions = AllInstances.Select(s => s.Subdivision).Distinct().ToList();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
