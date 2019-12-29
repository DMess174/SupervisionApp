﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;
using DataLayer.Journals;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using Supervision.Views.EntityViews.MaterialViews;

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
        private IEnumerable<TEntityJournal> journal;
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
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntityJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<TEntityTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged("Inspectors");
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
                                if (detail.WeldGateValveCover != null)
                                    MessageBox.Show($"Фланец применен в крышке № {detail.WeldGateValveCover.Number}", "Ошибка");
                                return;
                            }
                            if (SelectedItem.CoverSleeveId != null)
                            {
                                var detail = db.CoverSleeves.Include(i => i.WeldGateValveCover).SingleOrDefault(i => i.Id == SelectedItem.CoverSleeveId);
                                if (detail.WeldGateValveCover != null)
                                    MessageBox.Show($"Втулка применена в крышке № {detail.WeldGateValveCover.Number}", "Ошибка");
                                return;
                            }
                            if (SelectedItem.SpindleId != null)
                            {
                                var detail = db.Spindles.Include(i => i.BaseValveCover).SingleOrDefault(i => i.Id == SelectedItem.SpindleId);
                                if (detail.BaseValveCover != null)
                                    MessageBox.Show($"Шпиндель применен в крышке № {detail.BaseValveCover.Number}", "Ошибка");
                                return;
                            }
                            if (SelectedItem.RunningSleeveId != null)
                            {
                                var detail = db.RunningSleeves.Include(i => i.BaseValveCover).SingleOrDefault(i => i.Id == SelectedItem.RunningSleeveId);
                                if (detail.BaseValveCover != null)
                                    MessageBox.Show($"Втулка ходовая применена в крышке № {detail.BaseValveCover.Number}", "Ошибка");
                                return;
                            }
                        db.Set<TEntity>().Update(SelectedItem);
                        db.SaveChanges();
                        foreach (var i in Journal)
                        {
                            i.DetailNumber = SelectedItem.Number;
                            i.DetailDrawing = SelectedItem.Drawing;
                        }
                        db.Set<TEntityJournal>().UpdateRange(Journal);
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
                            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
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
                               if (SelectedItem.CoverFlange is CoverFlange)
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
                               if (SelectedItem.CoverSleeve is CoverSleeve)
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
                               if (SelectedItem.Spindle is Spindle)
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
                               if (SelectedItem.RunningSleeve is RunningSleeve)
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
                RaisePropertyChanged("CoverFlanges");
            }
        }
        public IEnumerable<CoverSleeve> CoverSleeves
        {
            get => coverSleeves;
            set
            {
                coverSleeves = value;
                RaisePropertyChanged("CoverSleeves");
            }
        }
        public IEnumerable<Spindle> Spindles
        {
            get => spindles;
            set
            {
                spindles = value;
                RaisePropertyChanged("Spindles");
            }
        }
        public IEnumerable<RunningSleeve> RunningSleeves
        {
            get => runningSleeves;
            set
            {
                runningSleeves = value;
                RaisePropertyChanged("RunningSleeves");
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged("Drawings");
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged("JournalNumbers");
            }
        }

        public TEntityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public WeldGateValveCoverEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Include(i => i.CoverFlange)
                .Include(i => i.CoverSleeve)
                .Include(i => i.Spindle)
                .Include(i => i.RunningSleeve)
                .SingleOrDefault(i => i.Id == id);
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
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
