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
        #endregion


        public ICommand CastValveCaseOpen
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
        public ICommand CastValveCoverOpen
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

        #region ReverseShutter
        public ICommand CaseShutterOpen
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
        #endregion

        #region WeldCaseDetails
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
        #endregion

        #region WeldCoverDetails
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
        #endregion

        public ICommand InspectorOpen
        {
            get
            {
                Page inspector = new InspectorView();
                return new DelegateCommand(() => SlowOpacity(inspector));
            }
        }
        public ICommand ProductTypeOpen
        {
            get
            {
                Page product = new ProductTypeView();
                return new DelegateCommand(() => SlowOpacity(product));
            }
        }

        public ICommand JournalNumbersOpen
        {
            get
            {
                Page journal = new JournalNumbersView
                {
                    DataContext = new JournalNumbersViewModel()
                };
                return new DelegateCommand(() => SlowOpacity(journal));
            }
        }

        #region TCP
        public ICommand ShutterReverseTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<ReverseShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand BronzeSleeveShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<BronzeSleeveShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand ShaftShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<ShaftShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand SlamShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<SlamShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand StubShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<StubShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand NozzleTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<NozzleTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand SteelSleeveShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<SteelSleeveShutterTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand CaseShutterTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<ReverseShutterCaseTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
            }
        }
        public ICommand MetalMaterialTCPOpen
        {
            get
            {
                Page tcp = new TCPView
                {
                    DataContext = new TCPViewModel<MetalMaterialTCP>()
                };
                return new DelegateCommand(() => SlowOpacity(tcp));
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
            });
        }
    }
}