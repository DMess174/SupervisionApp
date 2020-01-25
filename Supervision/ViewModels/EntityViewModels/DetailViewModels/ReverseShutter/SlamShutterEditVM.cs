using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class SlamShutterEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<SlamShutterTCP> points;
        private IEnumerable<Inspector> inspectors;
        
        private IEnumerable<SlamShutterJournal> inputControlJournal;
        private IEnumerable<SlamShutterJournal> inputNDTControlJournal;
        private IEnumerable<SlamShutterJournal> mechanicalJournal;
        private IEnumerable<SlamShutterJournal> overlayingJournal;
        private readonly BaseTable parentEntity;
        private SlamShutter selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private SlamShutterTCP selectedTCPPoint;

        public SlamShutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SlamShutterJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterJournal> OverlayingJournal
        {
            get => overlayingJournal;
            set
            {
                overlayingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutterTCP> Points
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
                            db.SlamShutters.Update(SelectedItem);
                            db.SaveChanges();
                            if (InputControlJournal != null)
                            {
                                foreach (var i in InputControlJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.SlamShutterJournals.UpdateRange(InputControlJournal);
                            }
                            if (InputNDTControlJournal != null)
                            {
                                foreach (var i in InputNDTControlJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.SlamShutterJournals.UpdateRange(InputNDTControlJournal);
                            }
                            if (MechanicalJournal != null)
                            {
                                foreach (var i in MechanicalJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.SlamShutterJournals.UpdateRange(MechanicalJournal);
                            }
                            if (OverlayingJournal != null)
                            {
                                foreach (var i in OverlayingJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.SlamShutterJournals.UpdateRange(OverlayingJournal);
                            }
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
                        if (parentEntity is SlamShutter)
                        {
                            var wn = new SlamShutterView();
                            var vm = new SlamShutterVM();
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
                            var item = new SlamShutterJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.SlamShutterJournals.Add(item);
                            db.SaveChanges();
                            InputControlJournal = db.SlamShutterJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль")
                                .OrderBy(x => x.PointId).ToList();
                            InputNDTControlJournal = db.SlamShutterJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)")
                                .OrderBy(x => x.PointId).ToList();
                            MechanicalJournal = db.SlamShutterJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка")
                                .OrderBy(x => x.PointId).ToList();
                            OverlayingJournal = db.SlamShutterJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Наплавка")
                                .OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        public SlamShutterTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
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

        public SlamShutterEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.SlamShutters
                .Include(i => i.ReverseShutter)
                .SingleOrDefault(i => i.Id == id);
            if (SelectedItem != null)
            {
                InputControlJournal = db.SlamShutterJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль")
                    .OrderBy(x => x.PointId).ToList();
                InputNDTControlJournal = db.SlamShutterJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)")
                    .OrderBy(x => x.PointId).ToList();
                MechanicalJournal = db.SlamShutterJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка")
                    .OrderBy(x => x.PointId).ToList();
                OverlayingJournal = db.SlamShutterJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Наплавка")
                    .OrderBy(x => x.PointId).ToList();
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Materials = db.SlamShutters.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.SlamShutters.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.SlamShutterTCPs.ToList();
        }
    }
}
