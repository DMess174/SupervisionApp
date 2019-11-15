using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.TechnicalControlPlans;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Detailing;

namespace Supervision.ViewModels.TCPViewModels
{
    class ShaftShutterTCPViewModel : BasePropertyChanged
    {
        private readonly DataContext db;

        private ObservableCollection<ShaftShutterTCP> tCPs;
        private ICollectionView tCPsView;
        private ShaftShutterTCP selectedPoint;
        private ICommand addPoint;
        private ICommand savePoint;
        private ICommand removePoint;
        private string pointTCP = string.Empty;
        private string operationNameTCP = string.Empty;
        private string descriptionTCP = string.Empty;


        public string PointTCP
        {
            get { return pointTCP; }
            set
            {
                pointTCP = value;
                TCPsView.Filter = (obj) =>
                {
                    if (obj is ShaftShutterTCP item)
                    {
                        if (item.Point != null)
                        {
                            return item.Point.ToLower().Contains(PointTCP.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                TCPsView.Refresh();
            }
        }
        public string OperationNameTCP
        {
            get { return operationNameTCP; }
            set
            {
                operationNameTCP = value;
                TCPsView.Filter = (obj) =>
                {
                    if (obj is ShaftShutterTCP item)
                    {
                        if (item.OperationName != null)
                        {
                            return item.OperationName.ToLower().Contains(OperationNameTCP.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                TCPsView.Refresh();
            }
        }
        public string DescriptionTCP
        {
            get { return descriptionTCP; }
            set
            {
                descriptionTCP = value;
                TCPsView.Filter = (obj) =>
                {
                    if (obj is ShaftShutterTCP item)
                    {
                        if (item.Description != null)
                        {
                            return item.Description.ToLower().Contains(DescriptionTCP.ToLower());
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return false;
                };
                TCPsView.Refresh();
            }
        }


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
                                ShaftShutterTCP point = new ShaftShutterTCP();
                                db.ShaftShutterTCPs.Add(point);
                                db.SaveChanges();
                                SelectedPoint = point;

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
                                ShaftShutterTCP point = SelectedPoint;
                                if (point != null)
                                {
                                    db.ShaftShutterTCPs.Update(point);
                                    db.SaveChanges();
                                    SelectedPoint = point;
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
                                ShaftShutterTCP point = SelectedPoint;
                                if (point != null)
                                {
                                    db.ShaftShutterTCPs.Remove(point);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }



        public ShaftShutterTCP SelectedPoint
        {
            get { return selectedPoint; }
            set
            {
                selectedPoint = value;
                RaisePropertyChanged("SelectedPoint");
            }
        }

        public ObservableCollection<ShaftShutterTCP> TCPs
        {
            get { return tCPs; }
            set
            {
                tCPs = value;
                RaisePropertyChanged("TCPs");
            }
        }

        public ICollectionView TCPsView
        {
            get { return tCPsView; }
            set
            {
                tCPsView = value;
                RaisePropertyChanged("TCPsView");
            }
        }

        public ShaftShutterTCPViewModel()
        {
            db = new DataContext();
            db.ShaftShutterTCPs.Load();
            TCPs = db.ShaftShutterTCPs.Local.ToObservableCollection();
            TCPsView = CollectionViewSource.GetDefaultView(TCPs);
        }
    }
}
