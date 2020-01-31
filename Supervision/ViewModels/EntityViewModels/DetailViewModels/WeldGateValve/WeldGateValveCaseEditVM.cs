using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class WeldGateValveCaseEditVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : WeldGateValveCase, new()
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<CaseFlange> caseFlanges;
        private IEnumerable<CaseBottom> caseBottoms;
        private IEnumerable<FrontWall> frontWalls;
        private IEnumerable<WeldNozzle> weldNozzles;
        private IEnumerable<CaseEdge> caseEdges;
        private FrontWall selectedFrontWall;
        private FrontWall selectedFrontWallFromList;
        private CaseEdge selectedEdge;
        private CaseEdge selectedEdgeFromList;
        private WeldNozzle selectedWeldNozzleFromList;
        private ICommand editWeldNozzle;
        private ICommand editEdge;
        private ICommand addEdgeToCase;
        private ICommand deleteEdgeFromCase;
        private ICommand editFrontWall;
        private ICommand addFrontWallToCase;
        private ICommand deleteFrontWallFromCase;
        private IEnumerable<SideWall> sideWalls;
        private SideWall selectedSideWall;
        private SideWall selectedSideWallFromList;
        private ICommand editSideWall;
        private ICommand addSideWallToCase;
        private ICommand deleteSideWallFromCase;
        private IEnumerable<string> drawings;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<TEntityJournal> assemblyJournal;
        private IEnumerable<TEntityJournal> mechanicalJournal;
        private IEnumerable<TEntityJournal> nDTJournal;
        private readonly BaseTable parentEntity;
        private TEntity selectedItem;
        private TEntityTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editCaseFlange;
        private ICommand editCaseBottom;

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
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
                            if (SelectedItem.CaseFlangeId != null)
                            {
                                var detail = db.CaseFlanges.Include(i => i.WeldGateValveCase).SingleOrDefault(i => i.Id == SelectedItem.CaseFlangeId);
                                if (detail?.WeldGateValveCase != null && detail.WeldGateValveCase.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Фланец применен в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.CaseBottomId != null)
                            {
                                var detail = db.CaseBottoms.Include(i => i.WeldGateValveCase).SingleOrDefault(i => i.Id == SelectedItem.CaseBottomId);
                                if (detail?.WeldGateValveCase != null && detail.WeldGateValveCase.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Днище применено в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                                    return;
                                }
                            }
                            db.Set<TEntity>().Update(SelectedItem);
                            db.SaveChanges();
                            foreach (var i in AssemblyJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<TEntityJournal>().UpdateRange(AssemblyJournal);
                            db.SaveChanges();
                            foreach (var i in MechanicalJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<TEntityJournal>().UpdateRange(MechanicalJournal);
                            db.SaveChanges(); foreach (var i in NDTJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<TEntityJournal>().UpdateRange(NDTJournal);
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
                            var wn = new WeldGateValveCaseView();
                            var vm = new WeldGateValveCaseVM<TEntity, TEntityTCP, TEntityJournal>();
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
                                   AssemblyJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId).ToList();
                                   MechanicalJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId).ToList();
                                   NDTJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        public FrontWall SelectedFrontWall
        {
            get => selectedFrontWall;
            set
            {
                selectedFrontWall	= value;
                RaisePropertyChanged();
            }
        }

        public FrontWall SelectedFrontWallFromList
        {
            get => selectedFrontWallFromList;
            set
            {
                selectedFrontWallFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddFrontWallToCase
        {
            get
            {
                return addFrontWallToCase	 ?? (
                           addFrontWallToCase	 = new DelegateCommand(() =>
                           {
                               if (SelectedItem.FrontWalls.Count() < 2)
                               {
                                   if (SelectedFrontWall != null)
                                   {
                                       var item = SelectedFrontWall;
                                       item.WeldGateValveCaseId = SelectedItem.Id;
                                       db.FrontWalls.Update(item);
                                       db.SaveChanges();
                                       FrontWalls = null;
                                       FrontWalls = db.FrontWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
                           }));
            }
        }
        public ICommand EditFrontWall
        {
            get
            {
                return editFrontWall	 ?? (
                           editFrontWall	 = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedFrontWallFromList != null)
                               { 
                                   var wn = new FrontWallEditView(); 
                                   var vm = new FrontWallEditVM(SelectedFrontWallFromList.Id, SelectedItem); 
                                   wn.DataContext = vm; 
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteFrontWallFromCase
        {
            get
            {
                return deleteFrontWallFromCase	 ?? (
                           deleteFrontWallFromCase	 = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedFrontWallFromList != null)
                               {
                                   var item = SelectedFrontWallFromList;
                                   item.WeldGateValveCaseId = null;
                                   db.FrontWalls.Update(item);
                                   db.SaveChanges();
                                   FrontWalls = null;
                                   FrontWalls = db.FrontWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public CaseEdge SelectedEdge
        {
            get => selectedEdge;
            set
            {
                selectedEdge = value;
                RaisePropertyChanged();
            }
        }

        public CaseEdge SelectedEdgeFromList
        {
            get => selectedEdgeFromList;
            set
            {
                selectedEdgeFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddEdgeToCase
        {
            get
            {
                return addEdgeToCase ?? (
                           addEdgeToCase = new DelegateCommand(() =>
                           {
                                if (SelectedEdge != null)
                                {
                                    var item = SelectedEdge;
                                    item.WeldGateValveCaseId = SelectedItem.Id;
                                    db.CaseEdges.Update(item);
                                    db.SaveChanges();
                                    CaseEdges = null;
                                    CaseEdges = db.CaseEdges.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                                }
                                else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditEdge
        {
            get
            {
                return editEdge ?? (
                           editEdge = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedEdgeFromList != null)
                               {
                                   var wn = new CaseEdgeEditView();
                                   var vm = new CaseEdgeEditVM(SelectedEdgeFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteEdgeFromCase
        {
            get
            {
                return deleteEdgeFromCase ?? (
                           deleteEdgeFromCase = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedEdgeFromList != null)
                               {
                                   var item = SelectedEdgeFromList;
                                   item.WeldGateValveCaseId = null;
                                   db.CaseEdges.Update(item);
                                   db.SaveChanges();
                                   CaseEdges = null;
                                   CaseEdges = db.CaseEdges.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public SideWall SelectedSideWall
        {
            get => selectedSideWall;
            set
            {
                selectedSideWall = value;
                RaisePropertyChanged();
            }
        }

        public SideWall SelectedSideWallFromList
        {
            get => selectedSideWallFromList	;
            set
            {
                selectedSideWallFromList	 = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddSideWallToCase
        {
            get
            {
                return addSideWallToCase ?? (
                           addSideWallToCase = new DelegateCommand(() =>
                           {
                               if (SelectedItem.SideWalls.Count() < 2)
                               {
                                   if (SelectedSideWall != null)
                                   {
                                       var item = SelectedSideWall;
                                       item.WeldGateValveCaseId = SelectedItem.Id;
                                       db.SideWalls.Update(item);
                                       db.SaveChanges();
                                       SideWalls = null;
                                       SideWalls = db.SideWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
                           }));
            }
        }
        public ICommand EditSideWall
        {
            get
            {
                return editSideWall ?? (
                           editSideWall = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedSideWallFromList != null)
                               {
                                   var wn = new SideWallEditView();
                                   var vm = new SideWallEditVM(SelectedSideWallFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteSideWallFromCase
        {
            get
            {
                return deleteSideWallFromCase ?? (
                           deleteSideWallFromCase = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedSideWallFromList != null)
                               {
                                   var item = SelectedSideWallFromList;
                                   item.WeldGateValveCaseId = null;
                                   db.SideWalls.Update(item);
                                   db.SaveChanges();
                                   SideWalls = null;
                                   SideWalls = db.SideWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand EditCaseFlange
        {
            get
            {
                return editCaseFlange ?? (
                           editCaseFlange = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CaseFlange != null)
                               {
                                   var wn = new CaseFlangeEditView();
                                   var vm = new CaseFlangeEditVM(SelectedItem.CaseFlange.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditCaseBottom
        {
            get
            {
                return editCaseBottom ?? (
                           editCaseBottom = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.CaseBottom != null)
                               {
                                   var wn = new CaseBottomEditView();
                                   var vm = new CaseBottomEditVM(SelectedItem.CaseBottom.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public WeldNozzle SelectedWeldNozzleFromList
        {
            get => selectedWeldNozzleFromList;
            set
            {
                selectedWeldNozzleFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand EditWeldNozzle
        {
            get
            {
                return editWeldNozzle ?? (
                           editWeldNozzle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedWeldNozzleFromList != null)
                               {
                                   var wn = new WeldNozzleEditView();
                                   var vm = new WeldNozzleEditVM(SelectedWeldNozzleFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<CaseFlange> CaseFlanges
        {
            get => caseFlanges;
            set
            {
                caseFlanges = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CaseBottom> CaseBottoms
        {
            get => caseBottoms;
            set
            {
                caseBottoms = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<FrontWall> FrontWalls
        {
            get => frontWalls;
            set
            {
                frontWalls = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SideWall> SideWalls
        {
            get => sideWalls;
            set
            {
                sideWalls = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<WeldNozzle> WeldNozzles
        {
            get => weldNozzles;
            set
            {
                weldNozzles = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CaseEdge> CaseEdges
        {
            get => caseEdges;
            set
            {
                caseEdges = value;
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

        public WeldGateValveCaseEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<TEntity>()
                .Include(i => i.BaseWeldValve)
                .SingleOrDefault(i => i.Id == id);
            db.FrontWalls.Include(i => i.WeldNozzle).Load();
            SelectedItem.FrontWalls = db.FrontWalls.Local.Where(i => i.WeldGateValveCaseId == SelectedItem.Id).ToObservableCollection();
            db.SideWalls.Load();
            SelectedItem.SideWalls = db.SideWalls.Local.Where(i => i.WeldGateValveCaseId == SelectedItem.Id).ToObservableCollection();
            db.CaseEdges.Load();
            SelectedItem.CaseEdges = db.CaseEdges.Local.Where(i => i.WeldGateValveCaseId == SelectedItem.Id).ToObservableCollection();
            AssemblyJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка/Сварка").OrderBy(x => x.PointId).ToList();
            MechanicalJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Механическая обработка").OrderBy(x => x.PointId).ToList();
            NDTJournal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Неразрушающий контроль").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            CaseFlanges = db.CaseFlanges.ToList();
            CaseBottoms = db.CaseBottoms.ToList();
            CaseEdges = db.CaseEdges.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
            FrontWalls = db.FrontWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
            SideWalls = db.SideWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToObservableCollection();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
        }
    }
}
