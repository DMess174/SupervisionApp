using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Supervision.ViewModels.EntityViewModels.AssemblyViewModels
{
    public class ReverseShutterViewModel : BasePropertyChanged
    {
        private readonly DataContext db;

        private IEnumerable<ReverseShutter> shutterReverses;
        private ICollectionView shutterReversesView;
        private ReverseShutter selectedShutterReverse;
        private ICommand addShutterReverse;
        private ICommand removeShutterReverse;
        private string shutterReverseNumber = string.Empty;
        private string shutterReverseDrawing = string.Empty;
        private string shutterReversePID = string.Empty;
        private string shutterReverseStatus = string.Empty;

        public string ShutterReverseNumber
        {
            get => shutterReverseNumber;
            set
            {
                shutterReverseNumber = value;
                RaisePropertyChanged();

            }
        }
        public string ShutterReverseDrawing
        {
            get => shutterReverseDrawing;
            set
            {
                shutterReverseDrawing = value;
                RaisePropertyChanged();

            }
        }
        public string ShutterReversePID
        {
            get => shutterReversePID;
            set
            {
                shutterReversePID = value;
                RaisePropertyChanged();

            }
        }

        public string ShutterReverseStatus
        {
            get => shutterReverseStatus;
            set
            {
                shutterReverseStatus = value;
                RaisePropertyChanged();

            }
        }



        public ICommand AddShutterReverse
        {
            get
            {
                return addShutterReverse ??
                    (
                    addShutterReverse = new DelegateCommand(() =>
                            {
                                ReverseShutter shutterReverse= new ReverseShutter() { };
                                db.ReverseShutters.Add(shutterReverse);
                                db.SaveChanges();
                                SelectedShutterReverse = shutterReverse;
                            })
                    );
            }
        }

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
                                ReverseShutter shutterReverse = SelectedShutterReverse;
                                if (shutterReverse != null)
                                {
                                    db.ReverseShutters.Remove(shutterReverse);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }



        public ReverseShutter SelectedShutterReverse
        {
            get => selectedShutterReverse;
            set
            {
                selectedShutterReverse = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ReverseShutter> ShutterReverses
        {
            get => shutterReverses;
            set
            {
                shutterReverses = value;
                RaisePropertyChanged();
            }
        }

        public ICollectionView ShutterReversesView
        {
            get => shutterReversesView;
            set
            {
                shutterReversesView = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterViewModel()
        {
            db = new DataContext();
            db.ReverseShutters.Load();
            ShutterReverses = db.ReverseShutters.Local.ToObservableCollection();
            //Departments = Inspectors.Select(d => d.Department).Distinct().ToList();
            //Subdivisions = Inspectors.Select(s => s.Subdivision).Distinct().ToList();
            ShutterReversesView = CollectionViewSource.GetDefaultView(ShutterReverses);
        }

    }
}
