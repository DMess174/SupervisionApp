using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews.CompactGateValve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.CompactGateValve
{
    public class ShutterEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<ShutterDisk> shutterDisks;
        private IEnumerable<ShutterGuide> shutterGuides;
        private ShutterDisk selectedShutterDisk;
        private ShutterDisk selectedShutterDiskFromList;
        private ICommand editShutterDisk;
        private ICommand addShutterDiskToShutter;
        private ICommand deleteShutterDiskFromShutter;
        private ShutterGuide selectedShutterGuide;
        private ShutterGuide selectedShutterGuideFromList;
        private ICommand editShutterGuide;
        private ICommand addShutterGuideToShutter;
        private ICommand deleteShutterGuideFromShutter;
        private IEnumerable<string> drawings;
        private IEnumerable<ShutterTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ShutterJournal> journal;
        private readonly BaseTable parentEntity;
        private Shutter selectedItem;
        private ShutterTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public Shutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ShutterJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShutterTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SaveItem
        {
            get
            {
                return saveItem ?? (
                    saveItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.Set<Shutter>().Update(SelectedItem);
                            db.SaveChanges();
                            foreach (var i in Journal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ShutterJournal>().UpdateRange(Journal);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не найден!", "Ошибка");
                    }));
            }
        }
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        if (parentEntity is Shutter)
                        {
                            var wn = new ShutterView();
                            var vm = new ShutterVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else w?.Close();
                    }));
            }
        }
        public ICommand AddOperation
        {
            get
            {
                return addOperation ?? (
                           addOperation = new DelegateCommand(() =>
                           {
                               if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                               else
                               {
                                   var item = new ShutterJournal()
                                   {
                                       DetailDrawing = SelectedItem.Drawing,
                                       DetailNumber = SelectedItem.Number,
                                       DetailName = SelectedItem.Name,
                                       DetailId = SelectedItem.Id,
                                       Point = SelectedTCPPoint.Point,
                                       Description = SelectedTCPPoint.Description,
                                       PointId = SelectedTCPPoint.Id,
                                   };
                                   db.Set<ShutterJournal>().Add(item);
                                   db.SaveChanges();
                                   Journal = db.Set<ShutterJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        public ShutterDisk SelectedShutterDisk
        {
            get => selectedShutterDisk;
            set
            {
                selectedShutterDisk = value;
                RaisePropertyChanged();
            }
        }

        public ShutterDisk SelectedShutterDiskFromList
        {
            get => selectedShutterDiskFromList;
            set
            {
                selectedShutterDiskFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddShutterDiskToShutter
        {
            get
            {
                return addShutterDiskToShutter	 ?? (
                           addShutterDiskToShutter	 = new DelegateCommand(() =>
                           {
                               if (SelectedItem.ShutterDisks.Count() < 2)
                               {
                                   if (SelectedShutterDisk != null)
                                   {
                                       var item = SelectedShutterDisk;
                                       item.ShutterId = SelectedItem.Id;
                                       db.ShutterDisks.Update(item);
                                       db.SaveChanges();
                                       ShutterDisks = null;
                                       ShutterDisks = db.ShutterDisks.Local.Where(i => i.ShutterId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 дисков!", "Ошибка");
                           }));
            }
        }
        public ICommand EditShutterDisk
        {
            get
            {
                return editShutterDisk	 ?? (
                           editShutterDisk	 = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedShutterDiskFromList != null)
                               { 
                                   var wn = new ShutterDiskEditView(); 
                                   var vm = new ShutterDiskEditVM(SelectedShutterDiskFromList.Id, SelectedItem); 
                                   wn.DataContext = vm; 
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteShutterDiskFromShutter
        {
            get
            {
                return deleteShutterDiskFromShutter	 ?? (
                           deleteShutterDiskFromShutter	 = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedShutterDiskFromList != null)
                               {
                                   var item = SelectedShutterDiskFromList;
                                   item.ShutterId = null;
                                   db.ShutterDisks.Update(item);
                                   db.SaveChanges();
                                   ShutterDisks = null;
                                   ShutterDisks = db.ShutterDisks.Local.Where(i => i.ShutterId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ShutterGuide SelectedShutterGuide
        {
            get => selectedShutterGuide;
            set
            {
                selectedShutterGuide = value;
                RaisePropertyChanged();
            }
        }

        public ShutterGuide SelectedShutterGuideFromList
        {
            get => selectedShutterGuideFromList;
            set
            {
                selectedShutterGuideFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddShutterGuideToShutter
        {
            get
            {
                return addShutterGuideToShutter ?? (
                           addShutterGuideToShutter = new DelegateCommand(() =>
                           {
                               if (SelectedItem.ShutterGuides.Count() < 2)
                               {
                                   if (SelectedShutterGuide != null)
                                   {
                                       var item = SelectedShutterGuide;
                                       item.ShutterId = SelectedItem.Id;
                                       db.ShutterGuides.Update(item);
                                       db.SaveChanges();
                                       ShutterGuides = null;
                                       ShutterGuides = db.ShutterGuides.Local.Where(i => i.ShutterId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 направляющих!", "Ошибка");
                           }));
            }
        }
        public ICommand EditShutterGuide
        {
            get
            {
                return editShutterGuide ?? (
                           editShutterGuide = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedShutterGuideFromList != null)
                               {
                                   var wn = new ShutterGuideEditView();
                                   var vm = new ShutterGuideEditVM(SelectedShutterGuideFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteShutterGuideFromShutter
        {
            get
            {
                return deleteShutterGuideFromShutter ?? (
                           deleteShutterGuideFromShutter = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedShutterGuideFromList != null)
                               {
                                   var item = SelectedShutterGuideFromList;
                                   item.ShutterId = null;
                                   db.ShutterGuides.Update(item);
                                   db.SaveChanges();
                                   ShutterGuides = null;
                                   ShutterGuides = db.ShutterGuides.Local.Where(i => i.ShutterId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
     
        public IEnumerable<ShutterDisk> ShutterDisks
        {
            get => shutterDisks;
            set
            {
                shutterDisks = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShutterGuide> ShutterGuides
        {
            get => shutterGuides;
            set
            {
                shutterGuides = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }

        public ShutterTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public ShutterEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<Shutter>()
                .Include(i => i.ShutterDisks)
                .Include(i => i.ShutterGuides)
                .Include(i => i.BaseValve)
                .SingleOrDefault(i => i.Id == id);
            Journal = db.Set<ShutterJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<Shutter>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            ShutterDisks = db.ShutterDisks.Where(i => i.ShutterId == null).ToList();
            ShutterGuides = db.ShutterGuides.Where(i => i.ShutterId == null).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<ShutterTCP>().ToList();
        }
    }
}
