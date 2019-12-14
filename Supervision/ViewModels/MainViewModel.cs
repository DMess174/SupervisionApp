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
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using Supervision.ViewModels.TCPViewModels;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;

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
                RaisePropertyChanged("CurrentPage");
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
        public ICommand ValveCaseOpen
        {
            get
            {
                return new DelegateCommand(() =>
                            {
                                var w = new CastingCaseView();
                                var vm = new CastingCaseVM<CastGateValveCase, CastGateValveCaseTCP, CastGateValveCaseJournal>();
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
                                var w = new ReverseShutterDetailView();
                                var vm = new ReverseShutterDetailVM<SlamShutter, SlamShutterTCP, SlamShutterJournal>();
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