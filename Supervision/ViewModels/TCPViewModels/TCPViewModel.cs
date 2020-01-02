using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans;
using System.Linq;

namespace Supervision.ViewModels.TCPViewModels
{
    class TCPViewModel<TEntityTCP> : BasePropertyChanged
        where TEntityTCP : BaseTCP, new()
    {
        private readonly DataContext db;

        private IEnumerable<OperationType> operationTypes;
        private IEnumerable<TEntityTCP> tCPs;
        private ICollectionView tCPsView;
        private TEntityTCP selectedPoint;
        private ICommand addPoint;
        private ICommand savePoint;
        private ICommand removePoint;

        public ICommand AddPoint
        {
            get
            {
                return addPoint ??
                    (
                    addPoint = new DelegateCommand(() =>
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
                    savePoint = new DelegateCommand(() =>
                            {
                                if (TCPs != null)
                                {
                                    db.Set<TEntityTCP>().UpdateRange(TCPs);
                                    db.SaveChanges();
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
                    removePoint = new DelegateCommand(() =>
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
            get => selectedPoint;
            set
            {
                selectedPoint = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<TEntityTCP> TCPs
        {
            get => tCPs;
            set
            {
                tCPs = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<OperationType> OperationTypes
        {
            get => operationTypes;
            set
            {
                operationTypes = value;
                RaisePropertyChanged();
            }
        }

        public ICollectionView TCPsView
        {
            get => tCPsView;
            set
            {
                tCPsView = value;
                RaisePropertyChanged();
            }
        }

        public TCPViewModel()
        {
            db = new DataContext();
            db.Set<TEntityTCP>().Include(i => i.OperationType).Load();
            TCPs = db.Set<TEntityTCP>().Local.ToObservableCollection();
            TCPsView = CollectionViewSource.GetDefaultView(TCPs);
            OperationTypes = db.OperationTypes.ToList();
        }
    }
}
