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

namespace Supervision.ViewModels
{
    public class MainViewModel : BasePropertyChanged
    {
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
            get
            {
                return new DelegateCommand(() =>
                {
                    //var w = new GateView();
                    //var vm = new GateVM();
                    //w.DataContext = vm;
                    //w.ShowDialog();
                });
            }
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
        #endregion

        #region TCP
        public ICommand PIDTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<PIDTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CoatingTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CoatingTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ReverseShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ReverseShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CastGateValveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CastGateValveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SheetGateValveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CompactGateValveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand GateTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<GateTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Details
        #region Sleeve
        public ICommand BronzeSleeveShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<BronzeSleeveShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SteelSleeveShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SteelSleeveShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand RunningSleeveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<RunningSleeveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        public ICommand ScrewNutTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ScrewNutTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand StubShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<StubShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SlamShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SlamShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Shutter
        public ICommand ShutterDiskTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ShutterDiskTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ShutterGuideTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ShutterGuideTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        public ICommand BallValveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<BallValveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand NozzleTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<NozzleTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Case
        public ICommand CastGateValveCaseTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CastGateValveCaseTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveCaseTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SheetGateValveCaseTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveCaseTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CompactGateValveCaseTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ReverseShutterCaseTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ReverseShutterCaseTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Details
        public ICommand CaseBottomTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CaseBottomTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand WeldNozzleTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<WeldNozzleTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SideWallTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SideWallTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand FrontWallTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<FrontWallTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CaseFlangeTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CaseFlangeTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        #endregion
        #region Cover
        public ICommand CastGateValveCoverTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CastGateValveCoverTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SheetGateValveCoverTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SheetGateValveCoverTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CompactGateValveCoverTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CompactGateValveCoverTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #region Details
        public ICommand CoverFlangeTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CoverFlangeTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CoverSealingRingTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CoverSealingRingTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CoverSleeveTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CoverSleeveTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        #endregion
        public ICommand ShaftShutterTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ShaftShutterTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SpringTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SpringTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SaddleTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SaddleTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand CounterFlangeTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<CounterFlangeTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand ScrewStudTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ScrewStudTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand SpindleTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<SpindleTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        #region Materials
        public ICommand AnticorrosiveCoatingTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<AnticorrosiveCoatingTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand MetalMaterialTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<MetalMaterialTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand WeldingMaterialTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<WeldingMaterialTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand FrontalSaddleSealingTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<FrontalSaddleSealingTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand AssemblyUnitSealingTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<AssemblyUnitSealingTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        #endregion
        public ICommand ControlWeldTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<ControlWeldTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand FactoryInspectionTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var w = new TCPView();
                    var vm = new TCPViewModel<FactoryInspectionTCP>();
                    w.DataContext = vm;
                    w.ShowDialog();
                });
            }
        }
        public ICommand StoresControlTCPOpen
        {
            get
            {
                return new DelegateCommand(() =>
                {
            var w = new TCPView();
            var vm = new TCPViewModel<StoresControlTCP>();
            w.DataContext = vm;
            w.ShowDialog();
        });
            }
}
#endregion

public ICommand AppExit
        {
            get
            {
                return new DelegateCommand<CancelEventArgs>(
                    (args) => {
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