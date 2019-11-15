using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnitViewModels
{
    public class ShutterReverseViewModel : BasePropertyChanged
    {
        private readonly DataContext db;

        private ObservableCollection<ShutterReverse> shutterReverses;
        private ICollectionView shutterReversesView;
        //private List<string> departments;
        //private List<string> subdivisions;
        private ShutterReverse selectedShutterReverse;
        private ICommand addShutterReverse;
        //private RelayCommand saveShutterReverse;
        private ICommand removeShutterReverse;
        private string shutterReverseNumber = string.Empty;
        private string shutterReverseDrawing = string.Empty;
        private string shutterReversePID = string.Empty;
        private string shutterReverseStatus = string.Empty;

        public string ShutterReverseNumber
        {
            get { return shutterReverseNumber; }
            set
            {
                shutterReverseNumber = value;
                RaisePropertyChanged("ShutterReverseNumber");

            }
        }
        public string ShutterReverseDrawing
        {
            get { return shutterReverseDrawing; }
            set
            {
                shutterReverseDrawing = value;
                RaisePropertyChanged("ShutterReverseDrawing");

            }
        }
        public string ShutterReversePID
        {
            get { return shutterReversePID; }
            set
            {
                shutterReversePID = value;
                RaisePropertyChanged("ShutterReversePID");

            }
        }

        public string ShutterReverseStatus
        {
            get { return shutterReverseStatus; }
            set
            {
                shutterReverseStatus = value;
                RaisePropertyChanged("ShutterReverseStatus");

            }
        }



        public ICommand AddShutterReverse
        {
            get
            {
                return addShutterReverse ??
                    (
                    addShutterReverse = new DelegateCommand
                        (
                            () =>
                            {
                                ShutterReverse shutterReverse= new ShutterReverse() { };
                                db.ShutterReverses.Add(shutterReverse);
                                db.SaveChanges();
                                SelectedShutterReverse = shutterReverse;
                            })
                    );
            }
        }

        //public RelayCommand SaveShutterReverse
        //{
        //    get
        //    {
        //        return saveShutterReverse ??
        //            (
        //            saveShutterReverse = new RelayCommand
        //                (
        //                    () =>
        //                    {
        //                        ShutterReverse shutterReverse = SelectedShutterReverse;
        //                        if (shutterReverse != null)
        //                        {
        //                            db.ShutterReverses.Update(shutterReverse);
        //                            db.SaveChanges();
        //                            SelectedShutterReverse = shutterReverse;
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Объект не выбран!", "Ошибка");
        //                        }
        //                    })
        //            );
        //    }
        //}

        public ICommand RemoveShutterReverse
        {
            get
            {
                return removeShutterReverse ??
                    (
                    removeShutterReverse = new DelegateCommand
                        (
                            () =>
                            {
                                ShutterReverse shutterReverse = SelectedShutterReverse;
                                if (shutterReverse != null)
                                {
                                    db.ShutterReverses.Remove(shutterReverse);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }



        public ShutterReverse SelectedShutterReverse
        {
            get { return selectedShutterReverse; }
            set
            {
                selectedShutterReverse = value;
                RaisePropertyChanged("SelectedShutterReverse");
            }
        }

        public ObservableCollection<ShutterReverse> ShutterReverses
        {
            get { return shutterReverses; }
            set
            {
                shutterReverses = value;
                RaisePropertyChanged("ShutterReverses");
            }
        }

        public ICollectionView ShutterReversesView
        {
            get { return shutterReversesView; }
            set
            {
                shutterReversesView = value;
                RaisePropertyChanged("ShutterReversesView");
            }
        }

        //public List<string> Departments
        //{
        //    get { return departments; }
        //    set
        //    {
        //        departments = value;
        //        RaisePropertyChanged("Departments");
        //    }
        //}

        //public List<string> Subdivisions
        //{
        //    get { return subdivisions; }
        //    set
        //    {
        //        subdivisions = value;
        //        RaisePropertyChanged("Subdivisions");
        //    }
        //}



        public ShutterReverseViewModel()
        {
            db = new DataContext();
            db.ShutterReverses.Load();
            ShutterReverses = db.ShutterReverses.Local.ToObservableCollection();
            //Departments = Inspectors.Select(d => d.Department).Distinct().ToList();
            //Subdivisions = Inspectors.Select(s => s.Subdivision).Distinct().ToList();
            ShutterReversesView = CollectionViewSource.GetDefaultView(ShutterReverses);
        }

    }
}
