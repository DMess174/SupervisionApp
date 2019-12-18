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
using DataLayer.Journals;

namespace Supervision.ViewModels.TCPViewModels
{
    public class JournalNumbersViewModel : BasePropertyChanged
    {
        private readonly DataContext db;

        private IEnumerable<JournalNumber> allInstances;
        private ICollectionView allInstancesView;
        private JournalNumber selectedPoint;
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
                                JournalNumber point = new JournalNumber();
                                db.Set<JournalNumber>().Add(point);
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
                                if (AllInstances != null)
                                {
                                    db.Set<JournalNumber>().UpdateRange(AllInstances);
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
                                JournalNumber point = SelectedPoint;
                                if (point != null)
                                {
                                    db.Set<JournalNumber>().Remove(point);
                                    db.SaveChanges();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                            })
                    );
            }
        }

        public JournalNumber SelectedPoint
        {
            get => selectedPoint;
            set
            {
                selectedPoint = value;
                RaisePropertyChanged("SelectedPoint");
            }
        }

        public IEnumerable<JournalNumber> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged("TCPs");
            }
        }

        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged("TCPsView");
            }
        }

        public JournalNumbersViewModel()
        {
            db = new DataContext();
            db.Set<JournalNumber>().Load();
            AllInstances = db.Set<JournalNumber>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
        }
    }
}
