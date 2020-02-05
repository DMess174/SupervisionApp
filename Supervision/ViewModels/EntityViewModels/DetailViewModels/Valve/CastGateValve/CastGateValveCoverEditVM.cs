using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class CastGateValveCoverEditVM : BasePropertyChanged
    {

        private readonly DataContext db;
        private readonly BaseTable parentEntity;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<CastGateValveCoverTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CastGateValveCoverJournal> assemblyWeldingJournal;
        private IEnumerable<CastGateValveCoverJournal> inputControlJournal;
        private IEnumerable<CastGateValveCoverJournal> inputNDTControlJournal;
        private IEnumerable<CastGateValveCoverJournal> mechanicalJournal;
        private IEnumerable<CastGateValveCoverJournal> assemblyJournal;
        private IEnumerable<CastGateValveCoverJournal> nDTJournal;

        private CastGateValveCover selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private CastGateValveCoverTCP selectedTCPPoint;
        private IEnumerable<CoverSealingRing> coverSealingRings;
        private IEnumerable<RunningSleeve> runningSleeves;
        private IEnumerable<Spindle> spindles;
        private ICommand editSpindle;
        private ICommand editRunningSleeve;
        private ICommand editCoverSealingRing;

        public CastGateValveCover SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CastGateValveCoverJournal> AssemblyWeldingJournal
        {
            get => assemblyWeldingJournal;
            set
            {
                assemblyWeldingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> InputControlJournal
        {
            get => inputControlJournal;
            set
            {
                inputControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> InputNDTControlJournal
        {
            get => inputNDTControlJournal;
            set
            {
                inputNDTControlJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CastGateValveCoverTCP> Points
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
                            if (SelectedItem.CoverSealingRingId != null)
                            {
                                var detail = db.CoverSealingRings.Include(i => i.CastGateValveCover).Include(i => i.CoverSleeve).SingleOrDefault(i => i.Id == SelectedItem.CoverSealingRingId);
                                if (detail?.CastGateValveCover != null && detail.CastGateValveCover.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Уплотнительное кольцо применено в {detail.CastGateValveCover.Name} № {detail.CastGateValveCover.Number}", "Ошибка");
                                    return;
                                }
                                if (detail?.CoverSleeve != null)
                                {
                                    MessageBox.Show($"Уплотнительное кольцо применено в {detail.CoverSleeve.Name} № {detail.CoverSleeve.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.SpindleId != null)
                            {
                                var detail = db.Spindles.Include(i => i.BaseValveCover).SingleOrDefault(i => i.Id == SelectedItem.SpindleId);
                                if (detail?.BaseValveCover != null && detail.BaseValveCover.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Шпиндель применен в {detail.BaseValveCover.Name} № {detail.BaseValveCover.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.RunningSleeveId != null)
                            {
                                var detail = db.RunningSleeves.Include(i => i.BaseValveCover).SingleOrDefault(i => i.Id == SelectedItem.RunningSleeveId);
                                if (detail?.BaseValveCover != null && detail.BaseValveCover.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Втулка ходовая применена в {detail.BaseValveCover.Name} № {detail.BaseValveCover.Number}", "Ошибка");
                                    return;
                                }
                            }
                            db.Set<CastGateValveCover>().Update(SelectedItem);
                            db.SaveChanges();
                            db.CastGateValveCoverJournals.UpdateRange(InputControlJournal);
                            db.CastGateValveCoverJournals.UpdateRange(InputNDTControlJournal);
                            db.CastGateValveCoverJournals.UpdateRange(MechanicalJournal);
                            db.CastGateValveCoverJournals.UpdateRange(AssemblyJournal);
                            db.CastGateValveCoverJournals.UpdateRange(AssemblyWeldingJournal);
                            db.CastGateValveCoverJournals.UpdateRange(NDTJournal);
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
                        if (parentEntity is CastGateValveCover)
                        {
                            var wn = new CastingCoverView();
                            var vm = new CastGateValveCoverVM();
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
                            var item = new CastGateValveCoverJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.CastGateValveCoverJournals.Add(item);
                            db.SaveChanges();
                            InputControlJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
                            InputNDTControlJournal = db.CastGateValveCoverJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)")
                                .OrderBy(x => x.PointId).ToList();
                            MechanicalJournal = db.CastGateValveCoverJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка")
                                .OrderBy(x => x.PointId).ToList();
                            AssemblyWeldingJournal = db.CastGateValveCoverJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка")
                                .OrderBy(x => x.PointId).ToList();
                            AssemblyJournal = db.CastGateValveCoverJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка")
                                .OrderBy(x => x.PointId).ToList();
                            NDTJournal = db.CastGateValveCoverJournals
                                .Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль")
                                .OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }
        public ICommand EditCoverSealingRing
        {
            get
            {
                return editCoverSealingRing ?? (
                           editCoverSealingRing = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CoverSealingRing != null)
                               {
                                   var wn = new CoverSealingRingEditView();
                                   var vm = new CoverSealingRingEditVM(SelectedItem.CoverSealingRing.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditSpindle
        {
            get
            {
                return editSpindle ?? (
                           editSpindle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.Spindle != null)
                               {
                                   var wn = new SpindleEditView();
                                   var vm = new SpindleEditVM(SelectedItem.Spindle.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditRunningSleeve
        {
            get
            {
                return editRunningSleeve ?? (
                           editRunningSleeve = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.RunningSleeve != null)
                               {
                                   var wn = new RunningSleeveEditView();
                                   var vm = new RunningSleeveEditVM(SelectedItem.RunningSleeve.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }

        public CastGateValveCoverTCP SelectedTCPPoint
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
        public IEnumerable<CoverSealingRing> CoverSealingRings
        {
            get => coverSealingRings;
            set
            {
                coverSealingRings = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<Spindle> Spindles
        {
            get => spindles;
            set
            {
                spindles = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<RunningSleeve> RunningSleeves
        {
            get => runningSleeves;
            set
            {
                runningSleeves = value;
                RaisePropertyChanged();
            }
        }

        public CastGateValveCoverEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.CastGateValveCovers.Include(i => i.CastGateValve).SingleOrDefault(i => i.Id == id);
            InputControlJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль").OrderBy(x => x.PointId).ToList();
            InputNDTControlJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Входной контроль (НК)").OrderBy(x => x.PointId).ToList();
            MechanicalJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId).ToList();
            AssemblyWeldingJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId).ToList();
            AssemblyJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
            NDTJournal = db.CastGateValveCoverJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Materials = db.CastGateValveCovers.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.CastGateValveCovers.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            CoverSealingRings = db.CoverSealingRings.ToList();
            Spindles = db.Spindles.ToList();
            RunningSleeves = db.RunningSleeves.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.CastGateValveCoverTCPs.ToList();
        }
    }
}
