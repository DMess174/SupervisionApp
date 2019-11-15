using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.TechnicalControlPlans;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace Supervision.ViewModels.TCPViewModels
{
    class ShutterReverseTCPViewModel : BasePropertyChanged
    {
        private DataContext db;

        private ObservableCollection<ShutterReverseTCP> shutterReverseTCPs;
        private ICollectionView shutterReverseTCPsView;
        
        private ShutterReverseTCP selectedPoint;
        private ICommand addPoint;
        private ICommand savePoint;
        private ICommand removePoint;

        public ICommand AddPoint
        {
            get
            {
                return addPoint ??
                    (
                    addPoint = new DelegateCommand
                        (
                            () =>
                            {
                                ShutterReverseTCP shutterReverseTCP = new ShutterReverseTCP();
                                
                                db.ShutterReverseTCPs.Add(shutterReverseTCP);
                                db.SaveChanges();
                            })
                    );
            }
        }

        public ICommand SavePoint
        {
            get
            {
                return savePoint??
                    (
                    savePoint = new DelegateCommand
                        (
                            () =>
                            {
                                ShutterReverseTCP shutterReverseTCP = SelectedPoint;
                                if (shutterReverseTCP != null)
                                {
                                    db.ShutterReverseTCPs.Update(shutterReverseTCP);
                                    db.SaveChanges();
                                    SelectedPoint = shutterReverseTCP;
                                }
                                else
                                {
                                    MessageBox.Show("Объект не выбран!", "Ошибка");
                                }                                  
                            })
                    );
            }
        }

        public ICommand RemovePoint
        {
            get
            {
                return removePoint ??
                    (
                    removePoint = new DelegateCommand
                        (
                            () =>
                            {
                                ShutterReverseTCP shutterReverseTCP = SelectedPoint;
                                if (shutterReverseTCP != null)
                                {
                                    db.ShutterReverseTCPs.Remove(shutterReverseTCP);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");         
                            })
                    );
            }
        }



        public ShutterReverseTCP SelectedPoint
        {
            get { return selectedPoint; }
            set
            {
                selectedPoint = value;
                RaisePropertyChanged("SelectedPoint");
            }
        }

        public ObservableCollection<ShutterReverseTCP> ShutterReverseTCPs
        {
            get { return shutterReverseTCPs; }
            set
            {
                shutterReverseTCPs = value;
                RaisePropertyChanged("ShutterReverseTCPs");
            }
        }

        public ICollectionView ShutterReverseTCPsView
        {
            get { return shutterReverseTCPsView; }
            set
            {
                shutterReverseTCPsView = value;
                RaisePropertyChanged("ShutterReverseTCPsView");
            }
        }

       



        public ShutterReverseTCPViewModel()
        {
            db = new DataContext();
            db.ShutterReverseTCPs.Load();
            ShutterReverseTCPs = db.ShutterReverseTCPs.Local.ToObservableCollection();
            ShutterReverseTCPsView = CollectionViewSource.GetDefaultView(ShutterReverseTCPs);
        }
    }
}
