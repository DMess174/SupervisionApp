using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class ReverseShutterCaseEditVM : BasePropertyChanged
    {
        private readonly BaseTable parentEntity;
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<ReverseShutterCaseTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ReverseShutterCaseJournal> inputControlJournal;
        private IEnumerable<ReverseShutterCaseJournal> inputNDTControlJournal;
        private IEnumerable<ReverseShutterCaseJournal> mechanicalJournal;
        private IEnumerable<ReverseShutterCaseJournal> overlayingJournal;
        private IEnumerable<ReverseShutterCaseJournal> assemblyJournal;
        private IEnumerable<ReverseShutterCaseJournal> nDTJournal;

        private ReverseShutterCase selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private IEnumerable<Nozzle> nozzles;
        private Nozzle selectedNozzle; 
        private Nozzle selectedNozzleFromList;
        private ICommand editNozzle;
        private ICommand addNozzleToCase;
        private ICommand deleteNozzleFromCase;
        private ReverseShutterCaseTCP selectedTCPPoint;

        public ReverseShutterCase SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ReverseShutterCaseJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseJournal> OverlayingJournal
        {
            get => overlayingJournal;
            set
            {
                overlayingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCaseTCP> Points
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

        public Nozzle SelectedNozzle
        {
            get => selectedNozzle;
            set
            {
                selectedNozzle = value;
                RaisePropertyChanged();
            }
        }

        public Nozzle SelectedNozzleFromList
        {
            get => selectedNozzleFromList;
            set
            {
                selectedNozzleFromList = value;
                RaisePropertyChanged();
            }
        }

        public ICommand EditNozzle
        {
            get
            {
                return editNozzle ?? (
                    editNozzle = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedNozzleFromList != null)
                        {
                            var wn = new NozzleEditView();
                            var vm = new NozzleEditVM(SelectedNozzleFromList.Id, SelectedItem);
                            wn.DataContext = vm;
                            wn.Show();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand DeleteNozzleFromCase
        {
            get
            {
                return deleteNozzleFromCase ?? (
                    deleteNozzleFromCase = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedNozzleFromList != null)
                        {
                            var item = SelectedNozzleFromList;
                            item.CastingCaseId = null;
                            db.Nozzles.Update(item);
                            db.SaveChanges();
                            Nozzles = null;
                            Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
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
                            db.ReverseShutterCases.Update(SelectedItem);
                            db.SaveChanges();
                            if (InputControlJournal != null)
                            {
                                foreach (var i in InputControlJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(InputControlJournal);
                            }
                            if (InputNDTControlJournal != null)
                            {
                                foreach (var i in InputNDTControlJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(InputNDTControlJournal);
                            }
                            if (MechanicalJournal != null)
                            {
                                foreach (var i in MechanicalJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(MechanicalJournal);
                            }
                            if (AssemblyJournal != null)
                            {
                                foreach (var i in AssemblyJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(AssemblyJournal);
                            }
                            if (NDTJournal != null)
                            {
                                foreach (var i in NDTJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(NDTJournal);
                            }
                            if (OverlayingJournal != null)
                            {
                                foreach (var i in OverlayingJournal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }
                                db.ReverseShutterCaseJournals.UpdateRange(OverlayingJournal);
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Объект не найден!", "Ошибка");
                        }

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
                        if (parentEntity is ReverseShutterCase)
                        {
                            var wn = new CastingCaseView();
                            var vm = new ReverseShutterCaseVM();
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
                            var item = new ReverseShutterCaseJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.ReverseShutterCaseJournals.Add(item);
                            db.SaveChanges();
                            InputControlJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль")
                                .OrderBy(x => x.PointId).ToList();
                            InputNDTControlJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)")
                                .OrderBy(x => x.PointId).ToList();
                            MechanicalJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка")
                                .OrderBy(x => x.PointId).ToList();
                            AssemblyJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка")
                                .OrderBy(x => x.PointId).ToList();
                            NDTJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль")
                                .OrderBy(x => x.PointId).ToList();
                            OverlayingJournal = db.ReverseShutterCaseJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Наплавка")
                                .OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        public ReverseShutterCaseTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddNozzleToCase
        {
            get
            {
                return addNozzleToCase ?? (
                    addNozzleToCase = new DelegateCommand(() =>
                    {
                        if (SelectedItem.Nozzles.Count() < 2)
                        {
                            if (SelectedNozzle != null)
                            {
                                var item = SelectedNozzle;
                                item.CastingCaseId = SelectedItem.Id;
                                db.Nozzles.Update(item);
                                db.SaveChanges();
                                Nozzles = null;
                                Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();
                            }
                            else MessageBox.Show("Объект не выбран!", "Ошибка");
                        }
                        else MessageBox.Show("Невозможно привязать более 2 катушек!", "Ошибка");
                    }));
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

        public IEnumerable<Nozzle> Nozzles
        {
            get => nozzles;
            set
            {
                nozzles = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterCaseEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.ReverseShutterCases
                .Include(i => i.ReverseShutter)
                .SingleOrDefault(i => i.Id == id);
            if (SelectedItem != null)
            {
                db.Nozzles.Include(i => i.MetalMaterial).Load();
                SelectedItem.Nozzles = db.Nozzles.Local
                    .Where(i => i.CastingCaseId == SelectedItem.Id)
                    .ToObservableCollection();
                InputControlJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль")
                    .OrderBy(x => x.PointId).ToList();
                InputNDTControlJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)")
                    .OrderBy(x => x.PointId).ToList();
                MechanicalJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка")
                    .OrderBy(x => x.PointId).ToList();
                AssemblyJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка")
                    .OrderBy(x => x.PointId).ToList();
                NDTJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль")
                    .OrderBy(x => x.PointId).ToList();
                OverlayingJournal = db.ReverseShutterCaseJournals
                    .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Наплавка")
                    .OrderBy(x => x.PointId).ToList();
            }
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Materials = db.ReverseShutterCases.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.ReverseShutterCases.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.ReverseShutterCaseTCPs.ToList();
            Nozzles = db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToObservableCollection();
        }
    }
}
