using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter;
using Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.AssemblyUnit;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class ReverseShutterEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<BronzeSleeveShutter> bronzeSleeves;
        private IEnumerable<SteelSleeveShutter> steelSleeves;
        private IEnumerable<StubShutter> stubs;
        private BronzeSleeveShutter selectedBronzeSleeve;
        private BronzeSleeveShutter selectedBronzeSleeveFromList;
        private StubShutter selectedStub;
        private StubShutter selectedStubFromList;
        private ICommand editBronzeSleeve;
        private ICommand addBronzeSleeveToShutter;
        private ICommand deleteBronzeSleeveFromShutter;
        private IEnumerable<BaseAnticorrosiveCoating> anticorrosiveMaterials;
        private SteelSleeveShutter selectedSteelSleeve;
        private SteelSleeveShutter selectedSteelSleeveFromList;
        private ICommand editSteelSleeve;
        private ICommand addSteelSleeveToShutter;
        private ICommand deleteSteelSleeveFromShutter;
        private IEnumerable<string> drawings;
        private IEnumerable<ReverseShutterTCP> points;
        private IEnumerable<ReverseShutterCase> cases;
        private IEnumerable<SlamShutter> slams;
        private IEnumerable<ShaftShutter> shafts;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<ReverseShutterJournal> assemblyJournal;
        private readonly BaseTable parentEntity;
        private ReverseShutter selectedItem;
        private ReverseShutterTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editCase;
        private ICommand editSlam;
        private ICommand editShaft;
        private IEnumerable<ReverseShutterJournal> testJournal;
        private IEnumerable<ReverseShutterJournal> aftertestJournal;
        private IEnumerable<ReverseShutterJournal> documentationJournal;
        private IEnumerable<ReverseShutterJournal> shippingJournal;
        private IEnumerable<CoatingJournal> coatingJournal;
        private ICommand addStubToShutter;
        private ICommand editStub;
        private ICommand deleteStubFromShutter;
        private ICommand editPID;
        private IEnumerable<PID> pIDs;
        private CoatingTCP selectedCoatingTCPPoint;
        private IEnumerable<CoatingTCP> coatingPoints;
        private ICommand addCoatingOperation;
        private BaseAnticorrosiveCoating selectedMaterial;
        private ReverseShutterWithCoating selectedMaterialFromList;
        private ICommand addMaterialToShutter;
        private ICommand editMaterial;
        private ICommand deleteMaterialFromShutter;

        public ReverseShutter SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ReverseShutterJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> TestJournal
        {
            get => testJournal;
            set
            {
                testJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> AfterTestJournal
        {
            get => aftertestJournal;
            set
            {
                aftertestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> DocumentationJournal
        {
            get => documentationJournal;
            set
            {
                documentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterJournal> ShippingJournal
        {
            get => shippingJournal;
            set
            {
                shippingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingJournal> CoatingJournal
        {
            get => coatingJournal;
            set
            {
                coatingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingTCP> CoatingPoints
        {
            get => coatingPoints;
            set
            {
                coatingPoints = value;
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
                            if (SelectedItem.ReverseShutterCaseId != null)
                            {
                                var detail = db.ReverseShutterCases.Include(i => i.ReverseShutter).SingleOrDefault(i => i.Id == SelectedItem.ReverseShutterCaseId);
                                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Корпус применен в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.SlamShutterId != null)
                            {
                                var detail = db.SlamShutters.Include(i => i.ReverseShutter).SingleOrDefault(i => i.Id == SelectedItem.SlamShutterId);
                                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Захлопка применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.ShaftShutterId != null)
                            {
                                var detail = db.ShaftShutters.Include(i => i.ReverseShutter).SingleOrDefault(i => i.Id == SelectedItem.ShaftShutterId);
                                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Ось применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                                    return;
                                }
                            }
                            db.Set<ReverseShutter>().Update(SelectedItem);
                            db.SaveChanges();
                            foreach (var i in AssemblyJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ReverseShutterJournal>().UpdateRange(AssemblyJournal);
                            db.SaveChanges();
                            foreach (var i in AfterTestJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ReverseShutterJournal>().UpdateRange(AfterTestJournal);
                            db.SaveChanges();
                            foreach (var i in CoatingJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<CoatingJournal>().UpdateRange(CoatingJournal);
                            db.SaveChanges();
                            foreach (var i in TestJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ReverseShutterJournal>().UpdateRange(TestJournal);
                            db.SaveChanges();
                            foreach (var i in DocumentationJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ReverseShutterJournal>().UpdateRange(DocumentationJournal);
                            db.SaveChanges();
                            foreach (var i in ShippingJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<ReverseShutterJournal>().UpdateRange(ShippingJournal);
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
                        if (parentEntity is ReverseShutter)
                        {
                            var wn = new ReverseShutterView();
                            var vm = new ReverseShutterVM();
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
                                   var item = new ReverseShutterJournal()
                                   {
                                       DetailDrawing = SelectedItem.Drawing,
                                       DetailNumber = SelectedItem.Number,
                                       DetailName = SelectedItem.Name,
                                       DetailId = SelectedItem.Id,
                                       Point = SelectedTCPPoint.Point,
                                       Description = SelectedTCPPoint.Description,
                                       PointId = SelectedTCPPoint.Id,
                                   };
                                   db.Set<ReverseShutterJournal>().Add(item);
                                   db.SaveChanges();
                                   AssemblyJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
                                   TestJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
                                   AfterTestJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId).ToList();
                                   DocumentationJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
                                   ShippingJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        public ICommand AddCoatingOperation
        {
            get
            {
                return addCoatingOperation ?? (
                           addCoatingOperation = new DelegateCommand(() =>
                           {
                               if (SelectedCoatingTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                               else
                               {
                                   var item = new CoatingJournal()
                                   {
                                       DetailDrawing = SelectedItem.Drawing,
                                       DetailNumber = SelectedItem.Number,
                                       DetailName = SelectedItem.Name,
                                       DetailId = SelectedItem.Id,
                                       Point = SelectedCoatingTCPPoint.Point,
                                       Description = SelectedCoatingTCPPoint.Description,
                                       PointId = SelectedCoatingTCPPoint.Id,
                                   };
                                   db.Set<CoatingJournal>().Add(item);
                                   db.SaveChanges();
                                   CoatingJournal = db.Set<CoatingJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        public BronzeSleeveShutter SelectedBronzeSleeve
        {
            get => selectedBronzeSleeve;
            set
            {
                selectedBronzeSleeve = value;
                RaisePropertyChanged();
            }
        }

        public BronzeSleeveShutter SelectedBronzeSleeveFromList
        {
            get => selectedBronzeSleeveFromList;
            set
            {
                selectedBronzeSleeveFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddBronzeSleeveToShutter
        {
            get
            {
                return addBronzeSleeveToShutter ?? (
                           addBronzeSleeveToShutter = new DelegateCommand(() =>
                           {
                                if (SelectedItem.BronzeSleeveShutters.Count() < 2)
                                {
                                    if (SelectedBronzeSleeve != null)
                                    {
                                        var item = SelectedBronzeSleeve;
                                        item.ReverseShutterId = SelectedItem.Id;
                                        db.BronzeSleeveShutters.Update(item);
                                        db.SaveChanges();
                                        BronzeSleeves = null;
                                        BronzeSleeves = db.BronzeSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                                    }
                                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                                }
                                else MessageBox.Show("Невозможно привязать более 2 втулок!", "Ошибка");
                           }));
            }
        }
        public ICommand EditBronzeSleeve
        {
            get
            {
                return editBronzeSleeve ?? (
                           editBronzeSleeve = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedBronzeSleeveFromList != null)
                               {
                                   var wn = new ReverseShutterDetailEditView();
                                   var vm = new ReverseShutterDetailEditVM<BronzeSleeveShutter, BronzeSleeveShutterTCP, BronzeSleeveShutterJournal>(SelectedBronzeSleeveFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteBronzeSleeveFromShutter
        {
            get
            {
                return deleteBronzeSleeveFromShutter ?? (
                    deleteBronzeSleeveFromShutter = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedBronzeSleeveFromList != null)
                        {
                            var item = SelectedBronzeSleeveFromList;
                            item.ReverseShutterId = null;
                            item.ReverseShutter = null;
                            db.BronzeSleeveShutters.Update(item);
                            db.SaveChanges();
                            BronzeSleeves = null;
                            BronzeSleeves = db.BronzeSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }
        public SteelSleeveShutter SelectedSteelSleeve
        {
            get => selectedSteelSleeve;
            set
            {
                selectedSteelSleeve = value;
                RaisePropertyChanged();
            }
        }

        public SteelSleeveShutter SelectedSteelSleeveFromList
        {
            get => selectedSteelSleeveFromList;
            set
            {
                selectedSteelSleeveFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddSteelSleeveToShutter
        {
            get
            {
                return addSteelSleeveToShutter ?? (
                           addSteelSleeveToShutter = new DelegateCommand(() =>
                           {
                               if (SelectedItem.SteelSleeveShutters.Count() < 2)
                               {
                                   if (SelectedSteelSleeve != null)
                                   {
                                       var item = SelectedSteelSleeve;
                                       item.ReverseShutterId = SelectedItem.Id;
                                       db.SteelSleeveShutters.Update(item);
                                       db.SaveChanges();
                                       SteelSleeves = null;
                                       SteelSleeves = db.SteelSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
                           }));
            }
        }
        public ICommand EditSteelSleeve
        {
            get
            {
                return editSteelSleeve ?? (
                           editSteelSleeve = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedSteelSleeveFromList != null)
                               {
                                   var wn = new ReverseShutterDetailEditView();
                                   var vm = new ReverseShutterDetailEditVM<SteelSleeveShutter, SteelSleeveShutterTCP, SteelSleeveShutterJournal>(SelectedSteelSleeveFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteSteelSleeveFromShutter
        {
            get
            {
                return deleteSteelSleeveFromShutter ?? (
                           deleteSteelSleeveFromShutter = new DelegateCommand(() =>
                           {
                               if (SelectedSteelSleeveFromList != null)
                               {
                                   var item = SelectedSteelSleeveFromList;
                                   item.ReverseShutterId = null;
                                   db.SteelSleeveShutters.Update(item);
                                   db.SaveChanges();
                                   SteelSleeves = null;
                                   SteelSleeves = db.SteelSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public StubShutter SelectedStub
        {
            get => selectedStub;
            set
            {
                selectedStub = value;
                RaisePropertyChanged();
            }
        }

        public StubShutter SelectedStubFromList
        {
            get => selectedStubFromList;
            set
            {
                selectedStubFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddStubToShutter
        {
            get
            {
                return addStubToShutter ?? (
                           addStubToShutter = new DelegateCommand(() =>
                           {
                               if (SelectedItem.StubShutters.Count() < 2)
                               {
                                   if (SelectedStub != null)
                                   {
                                       var item = SelectedStub;
                                       item.ReverseShutterId = SelectedItem.Id;
                                       db.StubShutters.Update(item);
                                       db.SaveChanges();
                                       Stubs = null;
                                       Stubs = db.StubShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 стенок!", "Ошибка");
                           }));
            }
        }
        public ICommand EditStub
        {
            get
            {
                return editStub ?? (
                           editStub = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedStubFromList != null)
                               {
                                   var wn = new ReverseShutterDetailEditView();
                                   var vm = new ReverseShutterDetailEditVM<StubShutter, StubShutterTCP, StubShutterJournal>(SelectedStubFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteStubFromShutter
        {
            get
            {
                return deleteStubFromShutter ?? (
                           deleteStubFromShutter = new DelegateCommand(() =>
                           {
                               if (SelectedStubFromList != null)
                               {
                                   var item = SelectedStubFromList;
                                   item.ReverseShutterId = null;
                                   db.StubShutters.Update(item);
                                   db.SaveChanges();
                                   Stubs = null;
                                   Stubs = db.StubShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public BaseAnticorrosiveCoating SelectedMaterial
        {
            get => selectedMaterial;
            set
            {
                selectedMaterial = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterWithCoating SelectedMaterialFromList
        {
            get => selectedMaterialFromList;
            set
            {
                selectedMaterialFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddMaterialToShutter
        {
            get
            {
                return addMaterialToShutter ?? (
                           addMaterialToShutter = new DelegateCommand(() =>
                           {
                               if (SelectedMaterial != null)
                               {
                                   var item = new ReverseShutterWithCoating()
                                   {
                                       ReverseShutterId = SelectedItem.Id,
                                       BaseAnticorrosiveCoatingId = SelectedMaterial.Id
                                   };
                                   db.ReverseShutterWithCoatings.Add(item);
                                   db.SaveChanges();
                               }
                               else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditMaterial
        {
            get
            {
                return editMaterial ?? (
                           editMaterial = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedMaterialFromList != null)
                               {
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is Undercoat)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<Undercoat, AnticorrosiveCoatingTCP, UndercoatJournal>(SelectedMaterialFromList.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbovegroundCoating)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<AbovegroundCoating, AnticorrosiveCoatingTCP, AbovegroundCoatingJournal>(SelectedMaterialFromList.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is UndergroundCoating)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<UndergroundCoating, AnticorrosiveCoatingTCP, UndergroundCoatingJournal>(SelectedMaterialFromList.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbrasiveMaterial)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<AbrasiveMaterial, AnticorrosiveCoatingTCP, AbrasiveMaterialJournal>(SelectedMaterialFromList.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteMaterialFromShutter
        {
            get
            {
                return deleteMaterialFromShutter ?? (
                           deleteMaterialFromShutter = new DelegateCommand(() =>
                           {
                               if (SelectedMaterialFromList != null)
                               {
                                   var item = db.ReverseShutterWithCoatings.SingleOrDefault(i => i.ReverseShutterId == SelectedItem.Id && i.BaseAnticorrosiveCoatingId == SelectedMaterialFromList.Id);
                                   db.ReverseShutterWithCoatings.Remove(item);
                                   db.SaveChanges();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand EditCase
        {
            get
            {
                return editCase ?? (
                           editCase = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.ReverseShutterCase != null)
                               {
                                   var wn = new ReverseShutterCaseEditView();
                                   var vm = new ReverseShutterCaseEditVM(SelectedItem.ReverseShutterCase.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditSlam
        {
            get
            {
                return editSlam ?? (
                           editSlam = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.SlamShutter != null)
                               {
                                   var wn = new SlamShutterEditView();
                                   var vm = new SlamShutterEditVM(SelectedItem.SlamShutter.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditShaft
        {
            get
            {
                return editShaft ?? (
                           editShaft = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.ShaftShutter != null)
                               {
                                   var wn = new ReverseShutterDetailEditView();
                                   var vm = new ReverseShutterDetailEditVM<ShaftShutter, ShaftShutterTCP, ShaftShutterJournal>(SelectedItem.ShaftShutter.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public ICommand EditPID
        {
            get
            {
                return editPID ?? (
                           editPID = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.PIDId != null)
                               {
                                   var wn = new PIDEditView();
                                   var vm = new PIDEditVM(SelectedItem.PID.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }

        public IEnumerable<PID> PIDs
        {
            get => pIDs;
            set
            {
                pIDs = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ReverseShutterCase> Cases
        {
            get => cases;
            set
            {
                cases = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SlamShutter> Slams
        {
            get => slams;
            set
            {
                slams = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ShaftShutter> Shafts
        {
            get => shafts;
            set
            {
                shafts = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<BronzeSleeveShutter> BronzeSleeves
        {
            get => bronzeSleeves;
            set
            {
                bronzeSleeves = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SteelSleeveShutter> SteelSleeves
        {
            get => steelSleeves;
            set
            {
                steelSleeves = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<StubShutter> Stubs
        {
            get => stubs;
            set
            {
                stubs = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<BaseAnticorrosiveCoating> AnticorrosiveMaterials
        {
            get => anticorrosiveMaterials;
            set
            {
                anticorrosiveMaterials = value;
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

        public ReverseShutterTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }
        public CoatingTCP SelectedCoatingTCPPoint
        {
            get => selectedCoatingTCPPoint;
            set
            {
                selectedCoatingTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public ReverseShutterEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<ReverseShutter>().SingleOrDefault(i => i.Id == id);
            PIDs = db.PIDs.Include(i => i.Specification).ToList();
            AssemblyJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
            TestJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
            AfterTestJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId).ToList();
            CoatingJournal = db.Set<CoatingJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            DocumentationJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
            ShippingJournal = db.Set<ReverseShutterJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<ReverseShutter>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            db.BronzeSleeveShutters.Load();
            SelectedItem.BronzeSleeveShutters = db.BronzeSleeveShutters.Local.Where(i => i.ReverseShutterId == SelectedItem.Id).ToObservableCollection();
            db.SteelSleeveShutters.Load();
            SelectedItem.SteelSleeveShutters = db.SteelSleeveShutters.Local.Where(i => i.ReverseShutterId == SelectedItem.Id).ToObservableCollection();
            db.StubShutters.Load();
            SelectedItem.StubShutters = db.StubShutters.Local.Where(i => i.ReverseShutterId == SelectedItem.Id).ToObservableCollection();
            db.ReverseShutterWithCoatings.Load();
            SelectedItem.ReverseShutterWithCoatings = db.ReverseShutterWithCoatings.Local.Where(i => i.ReverseShutterId == SelectedItem.Id).ToObservableCollection();
            Cases = db.ReverseShutterCases.ToList();
            Slams = db.SlamShutters.ToList();
            Shafts = db.ShaftShutters.ToList();
            BronzeSleeves = db.BronzeSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
            SteelSleeves = db.SteelSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
            Stubs = db.StubShutters.Local.Where(i => i.ReverseShutterId == null).ToObservableCollection();
            db.BaseAnticorrosiveCoatings.Load();
            AnticorrosiveMaterials = db.BaseAnticorrosiveCoatings.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<ReverseShutterTCP>().ToList();
            CoatingPoints = db.CoatingTCPs.ToList();
        }
    }
}
