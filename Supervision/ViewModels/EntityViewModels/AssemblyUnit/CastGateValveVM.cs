using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.AssemblyUnit;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class CastGateValveVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<CastGateValve> allInstances;
        private ICollectionView allInstancesView;
        private CastGateValve selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand copyItem;
        private ICommand closeWindow;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";

        #region Filter
        public string Number 
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is CastGateValve item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Drawing
        {
            get => drawing;
            set
            {
                drawing = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is CastGateValve item && item.Drawing != null)
                    {
                        return item.Drawing.ToLower().Contains(Drawing.ToLower());
                    }
                    else return true;
                };
            }
        }
        public string Status
        {
            get => status;
            set
            {
                status = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is CastGateValve item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
                    }
                    else return true;
                };
            }
        }
        #endregion

        #region Commands              
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        w?.Close();
                    }));
            }
        }
        public ICommand EditItem
        {
            get
            {
                return editItem ?? (
                    editItem = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedItem != null)
                        {
                            var wn = new CastGateValveEditView();
                            var vm = new CastGateValveEditVM(SelectedItem.Id, SelectedItem);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand CopyItem
        {
            get
            {
                return copyItem ?? (
                    copyItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            var item = new CastGateValve()
                            {
                                Number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер:"),
                                Drawing = SelectedItem.Drawing,
                                Status = SelectedItem.Status,
                                Name = SelectedItem.Name,
                            };
                            db.Set<CastGateValve>().Add(item);
                            db.SaveChanges();
                            var Journal = db.Set<CastGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id).ToList();
                            var coatingJournal = db.Set<CoatingJournal>().Where(i => i.DetailId == SelectedItem.Id).ToList();
                            foreach (var record in Journal)
                            {
                                var Record = new CastGateValveJournal()
                                {
                                    Date = record.Date,
                                    DetailId = item.Id,
                                    Description = record.Description,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    RemarkIssued = record.RemarkIssued,
                                    RemarkClosed = record.RemarkClosed,
                                    Comment = record.Comment,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber
                                };
                                db.Set<CastGateValveJournal>().Add(Record);
                                db.SaveChanges();
                            }
                            foreach (var record in coatingJournal)
                            {
                                var Record = new CoatingJournal()
                                {
                                    Date = record.Date,
                                    DetailId = item.Id,
                                    Description = record.Description,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    RemarkIssued = record.RemarkIssued,
                                    RemarkClosed = record.RemarkClosed,
                                    Comment = record.Comment,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber
                                };
                                db.Set<CoatingJournal>().Add(Record);
                                db.SaveChanges();
                            }
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand AddItem
        {
            get
            {
                return addItem ?? (
                    addItem = new DelegateCommand<Window>((w) =>
                    {
                        var item = new CastGateValve();
                        db.Set<CastGateValve>().Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.Set<CastGateValveTCP>().ToList();
                        var coatingPoints = db.Set<CoatingTCP>().ToList();
                        var castJournal = new List<CastGateValveJournal>();
                        var coatJournal = new List<CoatingJournal>();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new CastGateValveJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                castJournal.Add(journal);
                            }
                        }
                        db.Set<CastGateValveJournal>().AddRange(castJournal);
                        db.SaveChanges();
                        foreach (var i in coatingPoints)
                        {
                            var journal = new CoatingJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                coatJournal.Add(journal);
                            }
                        }
                        db.Set<CoatingJournal>().AddRange(coatJournal);
                        db.SaveChanges();
                        var wn = new CastGateValveEditView();
                        var vm = new CastGateValveEditVM(SelectedItem.Id, SelectedItem);
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
                    }));
            }
        }
        public ICommand RemoveItem
        {
            get
            {
                return removeItem ?? (
                    removeItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.Set<CastGateValve>().Remove(SelectedItem);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не выбран!", "Ошибка");
                    }));
            }
        }
        #endregion

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public CastGateValve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CastGateValve> AllInstances
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

        public CastGateValveVM()
        {
            db = new DataContext();
            db.Set<CastGateValve>().Load();
            AllInstances = db.Set<CastGateValve>().Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            if (AllInstances.Any())
            {
                Name = AllInstances.First().Name;
            }
        }
    }
}
