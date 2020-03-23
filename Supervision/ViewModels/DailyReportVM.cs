using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Supervision.ViewModels
{
    public class DailyReportVM : BasePropertyChanged
    {
        private DataContext db;
        private IEnumerable<ProductType> productTypes;
        public IEnumerable<ProductType> ProductTypes
        {
            get => productTypes;
            set
            {
                productTypes = value;
                RaisePropertyChanged();
            }
        }
        private ProductType selectedProductType;
        public ProductType SelectedProductType
        {
            get => selectedProductType;
            set
            {
                selectedProductType = value;
                RaisePropertyChanged();
            }
        }
        private IList<DailyReport> castGateValves;
        public IList<DailyReport> CastGateValves
        {
            get => castGateValves;
            set
            {
                castGateValves = value;
                RaisePropertyChanged();
            }
        }
        private ICollectionView castGateValvesView;
        public ICollectionView CastGateValvesView
        {
            get => castGateValvesView;
            set
            {
                castGateValvesView = value;
                RaisePropertyChanged();
            }
        }
        private IList<DailyReport> sheetGateValves;
        public IList<DailyReport> SheetGateValves
        {
            get => sheetGateValves;
            set
            {
                sheetGateValves = value;
                RaisePropertyChanged();
            }
        }
        private ICollectionView sheetGateValvesView;
        public ICollectionView SheetGateValvesView
        {
            get => sheetGateValvesView;
            set
            {
                sheetGateValvesView = value;
                RaisePropertyChanged();
            }
        }
        private IList<DailyReport> compactGateValves;
        public IList<DailyReport> CompactGateValves
        {
            get => compactGateValves;
            set
            {
                compactGateValves = value;
                RaisePropertyChanged();
            }
        }
        private ICollectionView compactGateValvesView;
        public ICollectionView CompactGateValvesView
        {
            get => compactGateValvesView;
            set
            {
                compactGateValvesView = value;
                RaisePropertyChanged();
            }
        }
        private IList<DailyReport> reverseShutters;
        public IList<DailyReport> ReverseShutters
        {
            get => reverseShutters;
            set
            {
                reverseShutters = value;
                RaisePropertyChanged();
            }
        }
        private ICollectionView reverseShuttersView;
        public ICollectionView ReverseShuttersView
        {
            get => reverseShuttersView;
            set
            {
                reverseShuttersView = value;
                RaisePropertyChanged();
            }
        }
        private IList<DailyReport> gates;
        public IList<DailyReport> Gates
        {
            get => gates;
            set
            {
                gates = value;
                RaisePropertyChanged();
            }
        }

        private ICommand getReport;
        public ICommand GetReport
        {
            get
            {
                return getReport ??
                    (
                    getReport = new DelegateCommand(() =>
                    {
                        GetAllCastGateValveData().ContinueWith(task =>
                        {
                            if (task.Exception == null)
                            {
                                var result = task.Result;
                                CastGateValves = new List<DailyReport>();
                                foreach (var i in result)
                                {
                                    var record = new DailyReport
                                    {
                                        CustomerName = i.PID?.Specification?.Customer?.Name,
                                        SpecificationNumber = i.PID?.Specification?.Number,
                                        PIDNumber = i.PID?.Number,
                                        Facility = i.PID?.Specification?.Facility,
                                        Designation = i.PID?.Designation,
                                        UnitNumber = i.Number,
                                        GateNumber = i.Gate?.Number,
                                        AssemblyDate = i.CastGateValveJournals?.Where(e => e.Point == "6.4").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        TestDate = i.CastGateValveJournals?.Where(e => e.Point == "7.17").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        CoatingDate = i.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        ShippingDate = i.CastGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                    };
                                    record.StringAssemblyDate = record.AssemblyDate.Value.ToShortDateString();
                                    record.StringTestDate = record.TestDate.Value.ToShortDateString();
                                    record.StringCoatingDate = record.CoatingDate.Value.ToShortDateString();
                                    record.StringShippingDate = record.ShippingDate.Value.ToShortDateString();
                                    CastGateValves.Add(record);
                                }
                                CastGateValvesView = CollectionViewSource.GetDefaultView(CastGateValves);
                            }
                        });
                        GetAllSheetGateValveData().ContinueWith(task =>
                        {
                            if (task.Exception == null)
                            {
                                var result = task.Result;
                                SheetGateValves = new List<DailyReport>();
                                foreach (var i in result)
                                {
                                    var record = new DailyReport
                                    {
                                        CustomerName = i.PID?.Specification?.Customer?.Name,
                                        SpecificationNumber = i.PID?.Specification?.Number,
                                        PIDNumber = i.PID?.Number,
                                        Facility = i.PID?.Specification?.Facility,
                                        Designation = i.PID?.Designation,
                                        UnitNumber = i.Number,
                                        GateNumber = i.Gate?.Number,
                                        AssemblyDate = i.SheetGateValveJournals?.Where(e => e.Point == "5.4").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        TestDate = i.SheetGateValveJournals?.Where(e => e.Point == "6.17").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        CoatingDate = i.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        ShippingDate = i.SheetGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                    };
                                    record.StringAssemblyDate = record.AssemblyDate.Value.ToShortDateString();
                                    record.StringTestDate = record.TestDate.Value.ToShortDateString();
                                    record.StringCoatingDate = record.CoatingDate.Value.ToShortDateString();
                                    record.StringShippingDate = record.ShippingDate.Value.ToShortDateString();
                                    SheetGateValves.Add(record);
                                }
                                SheetGateValvesView = CollectionViewSource.GetDefaultView(SheetGateValves);
                            }
                        });
                        GetAllCompactGateValveData().ContinueWith(task =>
                        {
                            if (task.Exception == null)
                            {
                                var result = task.Result;
                                CompactGateValves = new List<DailyReport>();
                                foreach (var i in result)
                                {
                                    var record = new DailyReport
                                    {
                                        CustomerName = i.PID?.Specification?.Customer?.Name,
                                        SpecificationNumber = i.PID?.Specification?.Number,
                                        PIDNumber = i.PID?.Number,
                                        Facility = i.PID?.Specification?.Facility,
                                        Designation = i.PID?.Designation,
                                        UnitNumber = i.Number,
                                        AssemblyDate = i.CompactGateValveJournals?.Where(e => e.Point == "5.4").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        TestDate = i.CompactGateValveJournals?.Where(e => e.Point == "6.17").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        CoatingDate = i.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        ShippingDate = i.CompactGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                    };
                                    record.StringAssemblyDate = record.AssemblyDate.Value.ToShortDateString();
                                    record.StringTestDate = record.TestDate.Value.ToShortDateString();
                                    record.StringCoatingDate = record.CoatingDate.Value.ToShortDateString();
                                    record.StringShippingDate = record.ShippingDate.Value.ToShortDateString();
                                    CompactGateValves.Add(record);
                                }
                                CompactGateValvesView = CollectionViewSource.GetDefaultView(CompactGateValves);
                            }
                        });
                        GetAllReverseShutterData().ContinueWith(task =>
                        {
                            if (task.Exception == null)
                            {
                                var result = task.Result;
                                ReverseShutters = new List<DailyReport>();
                                foreach (var i in result)
                                {
                                    var record = new DailyReport
                                    {
                                        CustomerName = i.PID?.Specification?.Customer?.Name,
                                        SpecificationNumber = i.PID?.Specification?.Number,
                                        PIDNumber = i.PID?.Number,
                                        Facility = i.PID?.Specification?.Facility,
                                        Designation = i.PID?.Designation,
                                        UnitNumber = i.Number,
                                        AssemblyDate = i.ReverseShutterJournals?.Where(e => e.Point == "7.1" && e.Description.Contains("сбор")).Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        TestDate = i.ReverseShutterJournals?.Where(e => e.Point == "7.6").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        CoatingDate = i.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date,
                                        ShippingDate = i.ReverseShutterJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date,
                                    };
                                    record.StringAssemblyDate = record.AssemblyDate.Value.ToShortDateString();
                                    record.StringTestDate = record.TestDate.Value.ToShortDateString();
                                    record.StringCoatingDate = record.CoatingDate.Value.ToShortDateString();
                                    record.StringShippingDate = record.ShippingDate.Value.ToShortDateString();
                                    ReverseShutters.Add(record);
                                }
                                ReverseShuttersView = CollectionViewSource.GetDefaultView(ReverseShutters);
                            }
                        });
                    }));
            }
        }

        private ICommand closeWindow;
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        w?.Close();
                    }));
            }
        }

        private async Task<IEnumerable<CastGateValve>> GetAllCastGateValveData()
        {
            return await db.CastGateValves.Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Include(i => i.Gate)
                .Include(i => i.CastGateValveJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType).ToListAsync();
        }
        private async Task<IEnumerable<SheetGateValve>> GetAllSheetGateValveData()
        {
            return await db.SheetGateValves.Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Include(i => i.Gate)
                .Include(i => i.SheetGateValveJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType).ToListAsync();
        }
        private async Task<IEnumerable<CompactGateValve>> GetAllCompactGateValveData()
        {
            return await db.CompactGateValves.Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Include(i => i.CompactGateValveJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType).ToListAsync();
        }
        private async Task<IEnumerable<ReverseShutter>> GetAllReverseShutterData()
        {
            return await db.ReverseShutters.Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Include(i => i.ReverseShutterJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                .ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType).ToListAsync();
        }
        //private async Task<IEnumerable<Gate>> GetAllGateData()
        //{

        //}

        public DailyReportVM()
        {
            db = new DataContext();
            ProductTypes = db.ProductTypes.ToList();
        }
    }

    public class DailyReport
    {
        public string CustomerName { get; set; }
        public string SpecificationNumber { get; set; }
        public string PIDNumber { get; set; }
        public string Facility { get; set; }
        public string Designation { get; set; }
        public string GateNumber { get; set; }
        public string UnitNumber { get; set; }
        public DateTime? AssemblyDate { get; set; }
        public string StringAssemblyDate { get; set; }
        public DateTime? TestDate { get; set; }
        public string StringTestDate { get; set; }
        public DateTime? CoatingDate { get; set; }
        public string StringCoatingDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string StringShippingDate { get; set; }
        public string Remark { get; set; }
        public string RemarkClosed { get; set; }
    }
}
