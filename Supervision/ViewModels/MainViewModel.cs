using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using DevExpress.Mvvm;
using Supervision.Views.TCPViews;
using DataLayer;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews;
using Supervision.ViewModels.EntityViewModels.DetailViewModels;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using Supervision.ViewModels.TCPViewModels;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;
using Supervision.Views.EntityViews.MaterialViews;
using Supervision.ViewModels.EntityViewModels.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve.CastGateValve;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using Supervision.Views.EntityViews.AssemblyUnit;
using Supervision.ViewModels.EntityViewModels.AssemblyUnit;
using DataLayer.TechnicalControlPlans;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;
using Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using Supervision.Views.EntityViews.DetailViews.CompactGateValve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.CompactGateValve;
using Supervision.Views;
using BusinessLayer.Report.DailyReport;
using DataLayer.TechnicalControlPlans.Periodical;
using Supervision.Views.EntityViews.PeriodicalControl;
using DataLayer.Entities.Periodical;
using DataLayer.Journals.Periodical;
using Supervision.ViewModels.EntityViewModels.Periodical;
using Supervision.ViewModels.EntityViewModels.Periodical.Gate;
using Supervision.Views.EntityViews.PeriodicalControl.Gate;

namespace Supervision.ViewModels
{
    public class MainViewModel : BasePropertyChanged
    {
        public MainViewModel()
        {
            var db = new DataContext();
            db.Dispose();
        }
        private Page currentPage;
        public Page CurrentPage
        { 
            get => currentPage;
            set 
            { 
                currentPage = value;
                RaisePropertyChanged();
            } 
        }

        public ICommand GetReport
        {

            get
            {
                return new DelegateCommand(() => DailyReport.GetReport());
            }
        }

        private double frameOpacity;
        public double FrameOpacity
        { 
            get => frameOpacity;
            set 
            { 
                frameOpacity = value; 
                RaisePropertyChanged(); 
            } 
        }

        public ICommand SpecificationOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SpecificationView();
                    var vm = new SpecificationVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CustomerOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CustomerView();
                    var vm = new CustomerVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand InspectorOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new InspectorView();
                    var vm = new InspectorVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ProductTypeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ProductTypeView();
                    var vm = new ProductTypeViewModel();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand JournalNumbersOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new JournalNumbersView();
                    var vm = new JournalNumbersViewModel();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }

        #region Materials
        public ICommand SheetMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SheetMaterialView();
                    var vm = new SheetMaterialVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand PipeMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new PipeMaterialView();
                    var vm = new PipeMaterialVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ForgingMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ForgingMaterialView();
                    var vm = new ForgingMaterialVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand RolledMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new RolledMaterialView();
                    var vm = new RolledMaterialVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }

        public ICommand AbrasiveMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new BaseAnticorrosiveCoatingView();
                    var vm = new BaseAnticorrosiveCoatingVM<AbrasiveMaterial, AnticorrosiveCoatingTCP, AbrasiveMaterialJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand UndercoatOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new BaseAnticorrosiveCoatingView();
                    var vm = new BaseAnticorrosiveCoatingVM<Undercoat, AnticorrosiveCoatingTCP, UndercoatJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand AbovegroundCoatingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new BaseAnticorrosiveCoatingView();
                    var vm = new BaseAnticorrosiveCoatingVM<AbovegroundCoating, AnticorrosiveCoatingTCP, AbovegroundCoatingJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand UndergroundCoatingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new BaseAnticorrosiveCoatingView();
                    var vm = new BaseAnticorrosiveCoatingVM<UndergroundCoating, AnticorrosiveCoatingTCP, UndergroundCoatingJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand WeldingMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldingMaterialView();
                    var vm = new WeldingMaterialVM<WeldingMaterial, WeldingMaterialTCP, WeldingMaterialJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ControlWeldOpen 
        { 
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ControlWeldView();
                    var vm = new ControlWeldVM<ControlWeld, ControlWeldTCP, ControlWeldJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand StoresControlOpen
        {
            get
            {
                return new DelegateCommand(() => OpenWindow(new StoresControlView(), new StoresControlVM()));
            }
        }
        public ICommand NDTControlOpen
        {
            get
            {
                return new DelegateCommand(() => OpenWindow(new PeriodicalControlView(), new PeriodicalControlVM<NDTControl, NDTControlTCP, NDTControlJournal >()));
            }
        }
        public ICommand WeldingProceduresOpen
        {
            get
            {
                return new DelegateCommand(() => OpenWindow(new PeriodicalControlView(), new PeriodicalControlVM<WeldingProcedures, WeldingProceduresTCP, WeldingProceduresJournal>()));
            }
        }
        public ICommand FactoryInspectionOpen
        {
            get
            {
                return new DelegateCommand(() => OpenWindow(new FactoryInspectionView(), new FactoryInspectionVM()));
            }
        }
        public ICommand DegreasingChemicalCompositionOpen
        {
            get => new DelegateCommand(() => OpenWindow(new GatePeriodicalView(), new DegreasingChemicalCompositionVM()));
        }
        public ICommand CoatingChemicalCompositionOpen
        {
            get => new DelegateCommand(() => OpenWindow(new GatePeriodicalView(), new CoatingChemicalCompositionVM()));
        }
        public ICommand CoatingPlasticityOpen
        {
            get => new DelegateCommand(() => OpenWindow(new GatePeriodicalView(), new CoatingPlasticityVM()));
        }
        public ICommand CoatingProtectivePropertiesOpen
        {
            get => new DelegateCommand(() => OpenWindow(new GatePeriodicalView(), new CoatingProtectivePropertiesVM()));
        }
        public ICommand CoatingPorosityOpen
        {
            get => new DelegateCommand(() => OpenWindow(new CoatingPorosityView(), new CoatingPorosityVM()));
        }
        public ICommand FrontalSaddleSealingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new FrontalSaddleSealingView();
                    var vm = new FrontalSaddleSealingVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand AssemblyUnitSealingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new AssemblyUnitSealingView();
                    var vm = new AssemblyUnitSealingVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion

        #region Assembly
        public ICommand ReverseShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ReverseShutterView();
                    var vm = new ReverseShutterVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CastGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CastGateValveView();
                    var vm = new CastGateValveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SheetGateValveView();
                    var vm = new SheetGateValveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CompactGateValveView();
                    var vm = new CompactGateValveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion

        #region Details
        #region Sleeve
        public ICommand BronzeSleeveShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ReverseShutterDetailView();
                    var vm = new ReverseShutterDetailVM<BronzeSleeveShutter, BronzeSleeveShutterTCP, BronzeSleeveShutterJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SteelSleeveShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ReverseShutterDetailView();
                    var vm = new ReverseShutterDetailVM<SteelSleeveShutter, SteelSleeveShutterTCP, SteelSleeveShutterJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CoverSleeveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CoverSleeveView();
                    var vm = new CoverSleeveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand RunningSleeveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new RunningSleeveView();
                    var vm = new RunningSleeveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }

        #endregion
        public ICommand ScrewNutOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ScrewNutView();
                    var vm = new ScrewNutVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand StubShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ReverseShutterDetailView();
                    var vm = new ReverseShutterDetailVM<StubShutter, StubShutterTCP, StubShutterJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SlamShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SlamShutterView();
                    var vm = new SlamShutterVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Shutter
        public ICommand ShutterDiskOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ShutterDiskView();
                    var vm = new ShutterDiskVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ShutterGuideOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ShutterGuideView();
                    var vm = new ShutterGuideVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ShutterView();
                    var vm = new ShutterVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        public ICommand BallValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new BallValveView();
                    var vm = new BallValveVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand NozzleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new NozzleView();
                    var vm = new NozzleVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Case
        public ICommand CastGateValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CastingCaseView();
                    var vm = new CastGateValveCaseVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ReverseShutterCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CastingCaseView();
                    var vm = new ReverseShutterCaseVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldGateValveCaseView();
                    var vm = new WeldGateValveCaseVM<SheetGateValveCase, SheetGateValveCaseTCP, SheetGateValveCaseJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldGateValveCaseView();
                    var vm = new WeldGateValveCaseVM<CompactGateValveCase, CompactGateValveCaseTCP, CompactGateValveCaseJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region CaseDetail
        public ICommand CaseBottomOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CaseBottomView();
                    var vm = new CaseBottomVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CaseFlangeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CaseFlangeView();
                    var vm = new CaseFlangeVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CaseEdgeOpen
        {
            get => new DelegateCommand(() => OpenWindow(new CaseEdgeView(), new CaseEdgeVM()));
        }
        public ICommand FrontWallOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new FrontWallView();
                    var vm = new FrontWallVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SideWallOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SideWallView();
                    var vm = new SideWallVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand WeldNozzleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldNozzleView();
                    var vm = new WeldNozzleVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        #endregion
        #region Cover
        public ICommand CastGateValveCoverOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CastingCoverView();
                    var vm = new CastGateValveCoverVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveCoverOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldGateValveCoverView();
                    var vm = new WeldGateValveCoverVM<SheetGateValveCover, SheetGateValveCoverTCP, SheetGateValveCoverJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveCoverOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new WeldGateValveCoverView();
                    var vm = new WeldGateValveCoverVM<CompactGateValveCover, CompactGateValveCoverTCP, CompactGateValveCoverJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region CoverDetial
        public ICommand CoverFlangeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CoverFlangeView();
                    var vm = new CoverFlangeVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CoverSealingRingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CoverSealingRingView();
                    var vm = new CoverSealingRingVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        #endregion
        public ICommand ShaftShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ReverseShutterDetailView();
                    var vm = new ReverseShutterDetailVM<ShaftShutter, ShaftShutterTCP, ShaftShutterJournal>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SpringOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SpringView();
                    var vm = new SpringVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SaddleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SaddleView();
                    var vm = new SaddleVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CounterFlangeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new CounterFlangeView();
                    var vm = new CounterFlangeVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand GateOpen
        {
            get => new DelegateCommand(() => OpenWindow(new GateView(), new GateVM()));
        }
        public ICommand ScrewStudOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new ScrewStudView();
                    var vm = new ScrewStudVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SpindleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new SpindleView();
                    var vm = new SpindleVM();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ShearPinOpen
        {
            get => new DelegateCommand(() => OpenWindow(new ShearPinView(), new ShearPinVM()));
        }
        #endregion

        #region TCP
        public ICommand PIDTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<PIDTCP>()));
        }
        public ICommand CoatingTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoatingTCP>()));
        }
        public ICommand ReverseShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ReverseShutterTCP>()));
        }
        public ICommand CastGateValveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CastGateValveTCP>()));
        }
        public ICommand SheetGateValveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SheetGateValveTCP>()));
        }
        public ICommand CompactGateValveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CompactGateValveTCP>()));
        }
        public ICommand GateTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<GateTCP>()));
        }
        #region Details
        #region Sleeve
        public ICommand BronzeSleeveShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<BronzeSleeveShutterTCP>()));
        }
        public ICommand SteelSleeveShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SteelSleeveShutterTCP>()));
        }
        public ICommand RunningSleeveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<RunningSleeveTCP>()));
        }
        #endregion
        public ICommand ScrewNutTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ScrewNutTCP>()));
        }
        public ICommand StubShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<StubShutterTCP>()));
        }
        public ICommand SlamShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SlamShutterTCP>()));
        }
        #region Shutter
        public ICommand ShutterDiskTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ShutterDiskTCP>()));
        }
        public ICommand ShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ShutterTCP>()));
        }
        public ICommand ShutterGuideTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ShutterGuideTCP>()));
        }
        #endregion
        public ICommand BallValveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<BallValveTCP>()));
        }
        public ICommand NozzleTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<NozzleTCP>()));
        }
        #region Case
        public ICommand CastGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CastGateValveCaseTCP>()));
        }
        public ICommand SheetGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SheetGateValveCaseTCP>()));
        }
        public ICommand CompactGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CompactGateValveCaseTCP>()));
        }
        public ICommand ReverseShutterCaseTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ReverseShutterCaseTCP>()));
        }
        #region Details
        public ICommand CaseBottomTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CaseBottomTCP>()));
        }
        public ICommand WeldNozzleTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<WeldNozzleTCP>()));
        }
        public ICommand CaseEdgeTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CaseEdgeTCP>()));
        }
        public ICommand SideWallTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SideWallTCP>()));
        }
        public ICommand FrontWallTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<FrontWallTCP>()));
        }
        public ICommand CaseFlangeTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CaseFlangeTCP>()));
        }
        #endregion
        #endregion
        #region Cover
        public ICommand CastGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CastGateValveCoverTCP>()));
        }
        public ICommand SheetGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SheetGateValveCoverTCP>()));
        }
        public ICommand CompactGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CompactGateValveCoverTCP>()));
        }
        #region Details
        public ICommand CoverFlangeTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoverFlangeTCP>()));
        }
        public ICommand CoverSealingRingTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoverSealingRingTCP>()));
        }
        public ICommand CoverSleeveTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoverSleeveTCP>()));
        }
        #endregion
        #endregion
        public ICommand ShaftShutterTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ShaftShutterTCP>()));
        }
        public ICommand SpringTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SpringTCP>()));
        }
        public ICommand SaddleTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SaddleTCP>()));
        }
        public ICommand CounterFlangeTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CounterFlangeTCP>()));
        }
        public ICommand ScrewStudTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ScrewStudTCP>()));
        }
        public ICommand SpindleTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<SpindleTCP>()));
        }
        public ICommand ShearPinTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ShearPinTCP>()));
        }
        #endregion
        #region Materials
        public ICommand AnticorrosiveCoatingTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<AnticorrosiveCoatingTCP>()));
        }
        public ICommand MetalMaterialTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<MetalMaterialTCP>()));
        }
        public ICommand WeldingMaterialTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<WeldingMaterialTCP>()));
        }
        public ICommand FrontalSaddleSealingTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<FrontalSaddleSealingTCP>()));
        }
        public ICommand AssemblyUnitSealingTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<AssemblyUnitSealingTCP>()));
        }
        #endregion
        public ICommand ControlWeldTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<ControlWeldTCP>()));
        }
        public ICommand FactoryInspectionTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<FactoryInspectionTCP>()));
        }
        public ICommand StoresControlTCPOpen
        {
                get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<StoresControlTCP>()));
        }
        public ICommand NDTTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<NDTControlTCP>()));
        }
        public ICommand WeldingProceduresTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<WeldingProceduresTCP>()));
        }
        public ICommand DegreasingChemicalCompositionTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<DegreasingChemicalCompositionTCP>()));
        }
        public ICommand CoatingChemicalCompositionTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoatingChemicalCompositionTCP>()));
        }
        public ICommand CoatingPlasticityTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoatingPlasticityTCP>()));
        }
        public ICommand CoatingProtectivePropertiesTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoatingProtectivePropertiesTCP>()));
        }
        public ICommand CoatingPorosityTCPOpen
        {
            get => new DelegateCommand(() => OpenWindow(new TCPView(), new TCPViewModel<CoatingPorosityTCP>()));
        }
        #endregion

        public ICommand AppExit
        {
            get
            {
                return new DelegateCommand<CancelEventArgs>((args) => 
                    {
                        Application.Current.Shutdown();
                    });
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.25)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.25)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            }).ConfigureAwait(false);
        }

        private void OpenWindow(Window w, BasePropertyChanged vm)
        {
            w.DataContext = vm;
            w.ShowDialog();
        }
        
        public ICommand MainMenuOpen
        {
            get
            {
                    Page page = new MainMenu();
                    return new DelegateCommand(() => SlowOpacity(page));
            }
        }
    }
}