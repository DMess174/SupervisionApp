using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class WeldGateValveCoverEditVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : WeldGateValveCover, new()
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CoverFlange> coverFlanges;
        private IEnumerable<CoverSleeve> coverSleeves;
        private IEnumerable<Spindle> spindles;
        private IEnumerable<RunningSleeve> runningSleeves;
        private IEnumerable<string> drawings;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<TEntityJournal> assemblyJournal;
        private IEnumerable<TEntityJournal> assemblyWeldingJournal;
        private IEnumerable<TEntityJournal> mechanicalJournal;
        private IEnumerable<TEntityJournal> nDTJournal;
        private readonly BaseTable parentEntity;
        private TEntity selectedItem;
        private TEntityTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editCoverFlange;
        private ICommand editCoverSleeve;
        private ICommand editSpindle;
        private ICommand editRunningSleeve;

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<TEntityJournal> AssemblyWeldingJournal
        {
            get => assemblyWeldingJournal;
            set
            {
                assemblyWeldingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityJournal> MechanicalJournal
        {
            get => mechanicalJournal;
            set
            {
                mechanicalJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityJournal> NDTJournal
        {
            get => nDTJournal;
            set
            {
                nDTJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<TEntityTCP> Points
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
                            if (SelectedItem.CoverFlangeId != null)
                            {
                                var detail = db.CoverFlanges.Include(i => i.WeldGateValveCover).SingleOrDefault(i => i.Id == SelectedItem.CoverFlangeId);
                                if (detail?.WeldGateValveCover != null && detail.WeldGateValveCover.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Фланец применен в {detail.WeldGateValveCover.Name} № {detail.WeldGateValveCover.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.CoverSleeveId != null)
                            {
                                var detail = db.CoverSleeves.Include(i => i.WeldGateValveCover).SingleOrDefault(i => i.Id == SelectedItem.CoverSleeveId);
                                if (detail?.WeldGateValveCover != null && detail.WeldGateValveCover.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Втулка применена в {detail.WeldGateValveCover.Name} № {detail.WeldGateValveCover.Number}", "Ошибка");
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
                            db.Set<TEntity>().Update(SelectedItem);
                            db.SaveChanges();
                            db.Set<TEntityJournal>().UpdateRange(AssemblyWeldingJournal);
                            db.Set<TEntityJournal>().UpdateRange(MechanicalJournal);
                            db.Set<TEntityJournal>().UpdateRange(NDTJournal);
                            db.Set<TEntityJournal>().UpdateRange(AssemblyJournal);
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
                        if (parentEntity is TEntity)
                        {
                            var wn = new WeldGateValveCoverView();
                            var vm = new WeldGateValveCoverVM<TEntity, TEntityTCP, TEntityJournal>();
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
                            var item = new TEntityJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<TEntityJournal>().Add(item);
                            db.SaveChanges();
                            AssemblyWeldingJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId).ToList();
                            MechanicalJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId).ToList();
                            NDTJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId).ToList();
                            AssemblyJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }
        public ICommand EditCoverFlange
        {
            get
            {
                return editCoverFlange ?? (
                           editCoverFlange = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CoverFlange != null)
                               {
                                   var wn = new CoverFlangeEditView();
                                   var vm = new CoverFlangeEditVM(SelectedItem.CoverFlange.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditCoverSleeve
        {
            get
            {
                return editCoverSleeve ?? (
                           editCoverSleeve = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CoverSleeve != null)
                               {
                                   var wn = new CoverSleeveEditView();
                                   var vm = new CoverSleeveEditVM(SelectedItem.CoverSleeve.Id, SelectedItem);
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

        public IEnumerable<CoverFlange> CoverFlanges
        {
            get => coverFlanges;
            set
            {
                coverFlanges = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoverSleeve> CoverSleeves
        {
            get => coverSleeves;
            set
            {
                coverSleeves = value;
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

        public TEntityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public WeldGateValveCoverEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Include(i => i.BaseWeldValve).SingleOrDefault(i => i.Id == id);
            AssemblyWeldingJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId).ToList();
            MechanicalJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId).ToList();
            NDTJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId).ToList();
            AssemblyJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            CoverFlanges = db.CoverFlanges.ToList();
            CoverSleeves = db.CoverSleeves.ToList();
            Spindles = db.Spindles.ToList();
            RunningSleeves = db.RunningSleeves.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
        }
    }
}
