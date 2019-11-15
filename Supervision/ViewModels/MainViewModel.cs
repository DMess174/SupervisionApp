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
using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing;

namespace Supervision.ViewModels
{
    public class MainViewModel : BasePropertyChanged
    {
        //private Page Customer;
        private Page Inspector;
        //private Page ProductType;
        //private Page Specification;


        private Page ShutterReverseTCP;

        private Page BronzeSleeveShutterTCP;
        private Page ShaftShutterTCP;

        private Page currentPage;
        public Page CurrentPage
        { 
            get { return currentPage; } 
            set 
            { 
                currentPage = value; 
                RaisePropertyChanged("CurrentPage"); 
            } 
        }

        private double frameOpacity;
        public double FrameOpacity
        { get { return frameOpacity; } set { frameOpacity = value; RaisePropertyChanged(); } }

        public MainViewModel() { }

        public ICommand BronzeSleeveShutterOpen
        {
            get
            {
                return new DelegateCommand
                        (
                            () =>
                            {
                                var w = new BaseDetailView();
                                var vm = new BaseDetailVM<BronzeSleeveShutter, BronzeSleeveShutterTCP, BronzeSleeveShutterJournal>();
                                w.DataContext = vm;
                                w.ShowDialog();
                            });
            }
        }
        //public ICommand CaseShutterOpen
        //{
        //    get
        //    {
        //        return new DelegateCommand
        //                (
        //                    () =>
        //                    {
        //                        var w = new CaseShutterView();
        //                        var vm = new CaseShutterViewModel();
        //                        w.DataContext = vm;
        //                        w.ShowDialog();
        //                    });
        //    }
        //}
        //public ICommand NozzleOpen
        //{
        //    get
        //    {
        //        return new DelegateCommand
        //                (
        //                    () =>
        //                    {
        //                        var w = new NozzleView();
        //                        var vm = new NozzleViewModel();
        //                        w.DataContext = vm;
        //                        w.ShowDialog();
        //                    });
        //    }
        //}
        public ICommand ShaftShutterOpen
        {
            get
            {
                return new DelegateCommand
                        (
                            () =>
                            {
                                var w = new BaseDetailView();
                                var vm = new BaseDetailVM<ShaftShutter, ShaftShutterTCP, ShaftShutterJournal>();
                                w.DataContext = vm;
                                w.ShowDialog();
                            });
            }
        }
        public ICommand SlamShutterOpen
        {
            get
            {
                return new DelegateCommand
                        (
                            () =>
                            {
                                var w = new BaseDetailView();
                                var vm = new BaseDetailVM<SlamShutter, SlamShutterTCP, SlamShutterJournal>();
                                w.DataContext = vm;
                                w.ShowDialog();
                            });
            }
        }
        public ICommand SteelSleeveShutterOpen
        {
            get
            {
                return new DelegateCommand
                        (
                            () =>
                            {
                                var w = new BaseDetailView();
                                var vm = new BaseDetailVM<SteelSleeveShutter, SteelSleeveShutterTCP, SteelSleeveShutterJournal>();
                                w.DataContext = vm;
                                w.ShowDialog();
                            });
            }
        }
        public ICommand StubShutterOpen
        {
            get
            {
                return new DelegateCommand
                        (
                            () =>
                            {
                                var w = new BaseDetailView();
                                var vm = new BaseDetailVM<StubShutter, StubShutterTCP, StubShutterJournal>();
                                w.DataContext = vm;
                                w.ShowDialog();
                            });
            }
        }

        public ICommand InspectorOpen
        {
            get
            {
                Inspector = new InspectorView();
                return new DelegateCommand(() => SlowOpacity(Inspector));
            }
        }

        public ICommand ShutterReverseTCPOpen
        {
            get
            {
                ShutterReverseTCP = new ShutterReverseTCPView();
                return new DelegateCommand(() => SlowOpacity(ShutterReverseTCP));
            }
        }
        public ICommand BronzeSleeveShutterTCPOpen
        {
            get
            {
                BronzeSleeveShutterTCP = new BronzeSleeveShutterTCPView();
                return new DelegateCommand(() => SlowOpacity(BronzeSleeveShutterTCP));
            }
        }
        public ICommand ShaftShutterTCPOpen
        {
            get
            {
                ShaftShutterTCP = new ShaftShutterTCPView();
                return new DelegateCommand(() => SlowOpacity(ShaftShutterTCP));
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