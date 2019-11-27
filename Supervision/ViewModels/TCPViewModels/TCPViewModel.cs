using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans;
using System.Linq;

namespace Supervision.ViewModels.TCPViewModels
{
    class TCPViewModel<TEntityTCP> : BasePropertyChanged
        where TEntityTCP : BaseTCP, new()
    {
        private readonly DataContext db;

        private IEnumerable<TEntityTCP> tCPs;
        private ICollectionView tCPsView;
        private TEntityTCP selectedPoint;
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
                    if (obj is TEntityTCP item)
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
                    if (obj is TEntityTCP item)
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
                    if (obj is TEntityTCP item)
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
                                TEntityTCP point = new TEntityTCP();
                                db.Set<TEntityTCP>().Add(point);
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
                                TEntityTCP point = SelectedPoint;
                                if (point != null)
                                {
                                    db.Set<TEntityTCP>().Update(point);
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
                                TEntityTCP point = SelectedPoint;
                                if (point != null)
                                {
                                    db.Set<TEntityTCP>().Remove(point);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }

        public TEntityTCP SelectedPoint
        {
            get { return selectedPoint; }
            set
            {
                selectedPoint = value;
                RaisePropertyChanged("SelectedPoint");
            }
        }

        public IEnumerable<TEntityTCP> TCPs
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

        public TCPViewModel()
        {
            db = new DataContext();
            db.Set<TEntityTCP>().Load();
            TCPs = db.Set<TEntityTCP>().Local.ToObservableCollection();
            TCPsView = CollectionViewSource.GetDefaultView(TCPs);
        }
    }
}
