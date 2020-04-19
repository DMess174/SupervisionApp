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
            Page page = new MainMenu();
            page.DataContext = this;
            SlowOpacity(page);
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
                    w.DataContext = SpecificationVM.LoadSpecificationVM(new DataContext());
                });
            }
        }
        public ICommand JournalReportOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new JournalReportView
                    {
                        DataContext = JournalReportVM.LoadVM(new DataContext())
                    };
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
                    w.DataContext = CustomerVM.LoadCustomerVM(new DataContext());
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
                    w.DataContext = InspectorVM.LoadVM(new DataContext());
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
                    w.DataContext = ProductTypeViewModel.LoadVM(new DataContext());
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
                    w.DataContext = JournalNumbersViewModel.LoadVM(new DataContext());
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
                    _ = new SheetMaterialView
                    {
                        DataContext = SheetMaterialVM.LoadSheetMaterialVM(new DataContext())
                    };
                });
            }
        }
        public ICommand PipeMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new PipeMaterialView
                    {
                        DataContext = PipeMaterialVM.LoadPipeMaterialVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ForgingMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ForgingMaterialView
                    {
                        DataContext = ForgingMaterialVM.LoadForgingMaterialVM(new DataContext())
                    };
                });
            }
        }
        public ICommand RolledMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new RolledMaterialView
                    {
                        DataContext = RolledMaterialVM.LoadRolledMaterialVM(new DataContext())
                    };
                });
            }
        }

        public ICommand AbrasiveMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new BaseAnticorrosiveCoatingView
                    {
                        DataContext = AbrasiveMaterialVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand UndercoatOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new BaseAnticorrosiveCoatingView
                    {
                        DataContext = UndercoatVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand AbovegroundCoatingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new BaseAnticorrosiveCoatingView
                    {
                        DataContext = AbovegroundCoatingVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand UndergroundCoatingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new BaseAnticorrosiveCoatingView
                    {
                        DataContext = UndergroundCoatingVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand WeldingMaterialOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldingMaterialView
                    {
                        DataContext = WeldingMaterialVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ControlWeldOpen 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ControlWeldView
                    {
                        DataContext = ControlWeldVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand StoresControlOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new StoresControlView
                    {
                        DataContext = StoresControlVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand NDTControlOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new PeriodicalControlView
                    {
                        DataContext = NDTPeriodicalControlVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand WeldingProceduresOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new PeriodicalControlView
                    {
                        DataContext = WeldingPeriodicalControlVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand FactoryInspectionOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new FactoryInspectionView
                    {
                        DataContext = FactoryInspectionVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand DegreasingChemicalCompositionOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new GatePeriodicalView
                    {
                        DataContext = DegreasingChemicalCompositionVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoatingChemicalCompositionOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new GatePeriodicalView
                    {
                        DataContext = CoatingChemicalCompositionVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoatingPlasticityOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new GatePeriodicalView
                    {
                        DataContext = CoatingPlasticityVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoatingProtectivePropertiesOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new GatePeriodicalView
                    {
                        DataContext = CoatingProtectivePropertiesVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoatingPorosityOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CoatingPorosityView
                    {
                        DataContext = CoatingPorosityVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand FrontalSaddleSealingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new FrontalSaddleSealingView
                    {
                        DataContext = FrontalSaddleSealingVM.LoadFrontalSaddleSealingVM(new DataContext())
                    };
                });
            }
        }
        public ICommand AssemblyUnitSealingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new AssemblyUnitSealingView
                    {
                        DataContext = AssemblyUnitSealingVM.LoadVM(new DataContext())
                    };
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
                    _ = new ReverseShutterView
                    {
                        DataContext = ReverseShutterVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CastGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CastGateValveView
                    {
                        DataContext = CastGateValveVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SheetGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new SheetGateValveView
                    {
                        DataContext = SheetGateValveVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CompactGateValveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CompactGateValveView
                    {
                        DataContext = CompactGateValveVM.LoadVM(new DataContext())
                    };
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
                    _ = new BronzeSleeveShutterView
                    {
                        DataContext = BronzeSleeveShutterVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SteelSleeveShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ReverseShutterDetailView
                    {
                        DataContext = SteelSleeveShutterVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoverSleeveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CoverSleeveView
                    {
                        DataContext = CoverSleeveVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand RunningSleeveOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new RunningSleeveView
                    {
                        DataContext = RunningSleeveVM.LoadVM(new DataContext())
                    };
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
                    _ = new ScrewNutView
                    {
                        DataContext = ScrewNutVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand StubShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ReverseShutterDetailView
                    {
                        DataContext = StubShutterVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SlamShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new SlamShutterView
                    {
                        DataContext = SlamShutterVM.LoadVM(new DataContext())
                    };
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
                    _ = new ShutterDiskView
                    {
                        DataContext = ShutterDiskVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ShutterGuideOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ShutterGuideView
                    {
                        DataContext = ShutterGuideVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ShutterOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ShutterView
                    {
                        DataContext = ShutterVM.LoadVM(new DataContext())
                    };
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
                    _ = new BallValveView
                    {
                        DataContext = BallValveVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand NozzleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new NozzleView
                    {
                        DataContext = NozzleVM.LoadVM(new DataContext())
                    };
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
                    _ = new CastingCaseView
                    {
                        DataContext = CastGateValveCaseVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ReverseShutterCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CastingCaseView
                    {
                        DataContext = ReverseShutterCaseVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SheetGateValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldGateValveCaseView
                    {
                        DataContext = SheetGateValveCaseVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CompactGateValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldGateValveCaseView
                    {
                        DataContext = CompactGateValveCaseVM.LoadVM(new DataContext())
                    };
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
                    _ = new CaseBottomView
                    {
                        DataContext = CaseBottomVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CaseFlangeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CaseFlangeView
                    {
                        DataContext = CaseFlangeVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CaseEdgeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CaseEdgeView
                    {
                        DataContext = CaseEdgeVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand FrontWallOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new FrontWallView
                    {
                        DataContext = FrontWallVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SideWallOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new SideWallView
                    {
                        DataContext = SideWallVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand WeldNozzleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldNozzleView
                    {
                        DataContext = WeldNozzleVM.LoadVM(new DataContext())
                    };
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
                    _ = new CastingCoverView
                    {
                        DataContext = CastGateValveCoverVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SheetGateValveCoverOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldGateValveCoverView
                    {
                        DataContext = SheetGateValveCoverVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CompactGateValveCoverOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new WeldGateValveCoverView
                    {
                        DataContext = CompactGateValveCoverVM.LoadVM(new DataContext())
                    };
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
                    _ = new CoverFlangeView
                    {
                        DataContext = CoverFlangeVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand CoverSealingRingOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CoverSealingRingView
                    {
                        DataContext = CoverSealingRingVM.LoadVM(new DataContext())
                    };
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
                    _ = new ReverseShutterDetailView
                    {
                        DataContext = ShaftShutterVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SpringOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new SpringView
                    {
                        DataContext = SpringVM.LoadVM(new DataContext())
                    };
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
                    w.DataContext = SaddleVM.LoadSaddleVM(new DataContext());
                });
            }
        }
        public ICommand CounterFlangeOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new CounterFlangeView
                    {
                        DataContext = CounterFlangeVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand GateOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new GateView
                    {
                        DataContext = GateVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ScrewStudOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ScrewStudView
                    {
                        DataContext = ScrewStudVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand SpindleOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new SpindleView
                    {
                        DataContext = SpindleVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        public ICommand ShearPinOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _ = new ShearPinView
                    {
                        DataContext = ShearPinVM.LoadVM(new DataContext())
                    };
                });
            }
        }
        #endregion

        #region TCP
        private void LoadTCP<T>() where T : BaseTCP, new()
        {
            _ = new TCPView()
            {
                DataContext = TCPViewModel<T>.LoadVM<T>(new DataContext())
            };
        }

        public ICommand PIDTCPOpen
        {
            get
            {
                return new DelegateCommand(() => LoadTCP<PIDTCP>());
            }
        }
        public ICommand CoatingTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoatingTCP>());
        }
        public ICommand ReverseShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ReverseShutterTCP>());
        }
        public ICommand CastGateValveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CastGateValveTCP>());
        }
        public ICommand SheetGateValveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SheetGateValveTCP>());
        }
        public ICommand CompactGateValveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CompactGateValveTCP>());
        }
        public ICommand GateTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<GateTCP>());
        }
        #region Details
        #region Sleeve
        public ICommand BronzeSleeveShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<BronzeSleeveShutterTCP>());
        }
        public ICommand SteelSleeveShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SteelSleeveShutterTCP>());
        }
        public ICommand RunningSleeveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<RunningSleeveTCP>());
        }
        #endregion
        public ICommand ScrewNutTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ScrewNutTCP>());
        }
        public ICommand StubShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<StubShutterTCP>());
        }
        public ICommand SlamShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SlamShutterTCP>());
        }
        #region Shutter
        public ICommand ShutterDiskTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ShutterDiskTCP>());
        }
        public ICommand ShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ShutterTCP>());
        }
        public ICommand ShutterGuideTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ShutterGuideTCP>());
        }
        #endregion
        public ICommand BallValveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<BallValveTCP>());
        }
        public ICommand NozzleTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<NozzleTCP>());
        }
        #region Case
        public ICommand CastGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CastGateValveCaseTCP>());
        }
        public ICommand SheetGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SheetGateValveCaseTCP>());
        }
        public ICommand CompactGateValveCaseTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CompactGateValveCaseTCP>());
        }
        public ICommand ReverseShutterCaseTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ReverseShutterCaseTCP>());
        }
        #region Details
        public ICommand CaseBottomTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CaseBottomTCP>());
        }
        public ICommand WeldNozzleTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<WeldNozzleTCP>());
        }
        public ICommand CaseEdgeTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CaseEdgeTCP>());
        }
        public ICommand SideWallTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SideWallTCP>());
        }
        public ICommand FrontWallTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<FrontWallTCP>());
        }
        public ICommand CaseFlangeTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CaseFlangeTCP>());
        }
        #endregion
        #endregion
        #region Cover
        public ICommand CastGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CastGateValveCoverTCP>());
        }
        public ICommand SheetGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SheetGateValveCoverTCP>());
        }
        public ICommand CompactGateValveCoverTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CompactGateValveCoverTCP>());
        }
        #region Details
        public ICommand CoverFlangeTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoverFlangeTCP>());
        }
        public ICommand CoverSealingRingTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoverSealingRingTCP>());
        }
        public ICommand CoverSleeveTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoverSleeveTCP>());
        }
        #endregion
        #endregion
        public ICommand ShaftShutterTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ShaftShutterTCP>());
        }
        public ICommand SpringTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SpringTCP>());
        }
        public ICommand SaddleTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SaddleTCP>());
        }
        public ICommand CounterFlangeTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CounterFlangeTCP>());
        }
        public ICommand ScrewStudTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ScrewStudTCP>());
        }
        public ICommand SpindleTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<SpindleTCP>());
        }
        public ICommand ShearPinTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ShearPinTCP>());
        }
        #endregion
        #region Materials
        public ICommand AnticorrosiveCoatingTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<AnticorrosiveCoatingTCP>());
        }
        public ICommand MetalMaterialTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<MetalMaterialTCP>());
        }
        public ICommand WeldingMaterialTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<WeldingMaterialTCP>());
        }
        public ICommand FrontalSaddleSealingTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<FrontalSaddleSealingTCP>());
        }
        public ICommand AssemblyUnitSealingTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<AssemblyUnitSealingTCP>());
        }
        #endregion
        public ICommand ControlWeldTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<ControlWeldTCP>());
        }
        public ICommand FactoryInspectionTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<FactoryInspectionTCP>());
        }
        public ICommand StoresControlTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<StoresControlTCP>());
        }
        public ICommand NDTTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<NDTControlTCP>());
        }
        public ICommand WeldingProceduresTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<WeldingProceduresTCP>());
        }
        public ICommand DegreasingChemicalCompositionTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<DegreasingChemicalCompositionTCP>());
        }
        public ICommand CoatingChemicalCompositionTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoatingChemicalCompositionTCP>());
        }
        public ICommand CoatingPlasticityTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoatingPlasticityTCP>());
        }
        public ICommand CoatingProtectivePropertiesTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoatingProtectivePropertiesTCP>());
        }
        public ICommand CoatingPorosityTCPOpen
        {
            get => new DelegateCommand(() => LoadTCP<CoatingPorosityTCP>());
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
            w.Show();
        }

        private ICommand mainMenuOpen;

        public ICommand MainMenuOpen
        {
            get
            {
                return mainMenuOpen ??
                (
                    mainMenuOpen = new DelegateCommand(() =>
                    {
                        Page page = new MainMenu();
                        page.DataContext = this;
                        SlowOpacity(page);
                    })
                );
            }
        }

        private ICommand castGateValveMenuOpen;
        public ICommand CastGateValveMenuOpen
        {
            get
            {
                return castGateValveMenuOpen ??
                (
                    castGateValveMenuOpen = new DelegateCommand(() =>
                    {
                        Page page = new CastGateValveMenu();
                        page.DataContext = this;
                        SlowOpacity(page);
                    })
                );
            }
        }

        private ICommand sheetGateValveMenuOpen;
        public ICommand SheetGateValveMenuOpen
        {
            get
            {
                return sheetGateValveMenuOpen ??
                (
                    sheetGateValveMenuOpen = new DelegateCommand(() =>
                    {
                        Page page = new SheetGateValveMenu();
                        page.DataContext = this;
                        SlowOpacity(page);
                    })
                );
            }
        }

        private ICommand compactGateValveMenuOpen;
        public ICommand CompactGateValveMenuOpen
        {
            get
            {
                return compactGateValveMenuOpen ??
                (
                    compactGateValveMenuOpen = new DelegateCommand(() =>
                    {
                        Page page = new CompactGateValveMenu();
                        page.DataContext = this;
                        SlowOpacity(page);
                    })
                );
            }
        }

        private ICommand reverseShutterMenuOpen;
        public ICommand ReverseShutterMenuOpen
        {
            get
            {
                return reverseShutterMenuOpen ??
                (
                    reverseShutterMenuOpen = new DelegateCommand(() =>
                    {
                        Page page = new ReverseShutterMenu();
                        page.DataContext = this;
                        SlowOpacity(page);
                    })
                );
            }
        }

        private ICommand dailyReportOpen;
        public ICommand DailyReportOpen
        {
            get
            {
                return dailyReportOpen ??
                (
                    dailyReportOpen = new DelegateCommand(() => OpenWindow(new DailyReportView(), new DailyReportVM(new DataContext())))
                );
            }
        }

        private ICommand fOMReportOpen;
        public ICommand FOMReportOpen
        {
            get
            {
                return fOMReportOpen ??
                (
                    fOMReportOpen = new DelegateCommand(() => OpenWindow(new FOMReportView(), new FOMReportVM(new DataContext())))
                );
            }
        }
    }
}