using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using Microsoft.EntityFrameworkCore;
using Supervision.Commands;
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
        private readonly DataContext db;
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

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

        private async Task Report()
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => GetAllCastGateValveData().ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        var result = task.Result;
                        CastGateValves = new List<DailyReport>();
                        foreach (var i in result)
                        {
                            var record = new DailyReport(i);
                            CastGateValves.Add(record);
                        }
                        CastGateValvesView = CollectionViewSource.GetDefaultView(CastGateValves);
                    }
                }));
                await Task.Run(() => GetAllSheetGateValveData().ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        var result = task.Result;
                        SheetGateValves = new List<DailyReport>();
                        foreach (var i in result)
                        {
                            var record = new DailyReport(i);
                            SheetGateValves.Add(record);
                        }
                        SheetGateValvesView = CollectionViewSource.GetDefaultView(SheetGateValves);
                    }
                }));
                await Task.Run(() => GetAllCompactGateValveData().ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        var result = task.Result;
                        CompactGateValves = new List<DailyReport>();
                        foreach (var i in result)
                        {
                            var record = new DailyReport(i);
                            CompactGateValves.Add(record);
                        }
                        CompactGateValvesView = CollectionViewSource.GetDefaultView(CompactGateValves);
                    }
                }));
                await Task.Run(() => GetAllCompactGateValveData().ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        var result = task.Result;
                        CompactGateValves = new List<DailyReport>();
                        foreach (var i in result)
                        {
                            var record = new DailyReport(i);
                            CompactGateValves.Add(record);
                        }
                        CompactGateValvesView = CollectionViewSource.GetDefaultView(CompactGateValves);
                    }
                }));
                await Task.Run(() => GetAllReverseShutterData().ContinueWith(task =>
                {
                    if (task.Exception == null)
                    {
                        var result = task.Result;
                        ReverseShutters = new List<DailyReport>();
                        foreach (var i in result)
                        {
                            var record = new DailyReport(i);
                            ReverseShutters.Add(record);
                        }
                        ReverseShuttersView = CollectionViewSource.GetDefaultView(ReverseShutters);
                    }
                }));
            }
            finally
            {
                IsBusy = false;
            }
        }
        public IAsyncCommand GetReportCommand { get; private set; }

        public ICommand CloseWindowCommand { get; set; }
        private void CloseWindow(object obj)
        {
            Window w = obj as Window;
            w?.Close();
        }

        public DailyReportVM(DataContext context)
        {
            db = context;
            GetReportCommand = new AsyncCommand(Report);
            CloseWindowCommand = new Command(o => CloseWindow(o));
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

        public DailyReport()
        {

        }

        public DailyReport(CastGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.Name;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            Facility = valve.PID?.Specification?.Facility;
            Designation = valve.PID?.Designation;
            UnitNumber = valve.Number;
            GateNumber = valve.Gate?.Number;
            AssemblyDate = valve.CastGateValveJournals?.Where(e => e.Point == "6.4").Select(a => a.Date).Max().GetValueOrDefault().Date;
            TestDate = valve.CastGateValveJournals?.Where(e => e.Point == "7.17").Select(a => a.Date).Max().GetValueOrDefault().Date;
            CoatingDate = valve.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date;
            ShippingDate = valve.CastGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            StringAssemblyDate = AssemblyDate.Value.ToShortDateString();
            StringTestDate = TestDate.Value.ToShortDateString();
            StringCoatingDate = CoatingDate.Value.ToShortDateString();
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public DailyReport(SheetGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.Name;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            Facility = valve.PID?.Specification?.Facility;
            Designation = valve.PID?.Designation;
            UnitNumber = valve.Number;
            GateNumber = valve.Gate?.Number;
            AssemblyDate = valve.SheetGateValveJournals?.Where(e => e.Point == "5.4").Select(a => a.Date).Max().GetValueOrDefault().Date;
            TestDate = valve.SheetGateValveJournals?.Where(e => e.Point == "6.17").Select(a => a.Date).Max().GetValueOrDefault().Date;
            CoatingDate = valve.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date;
            ShippingDate = valve.SheetGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            StringAssemblyDate = AssemblyDate.Value.ToShortDateString();
            StringTestDate = TestDate.Value.ToShortDateString();
            StringCoatingDate = CoatingDate.Value.ToShortDateString();
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public DailyReport(CompactGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.Name;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            Facility = valve.PID?.Specification?.Facility;
            Designation = valve.PID?.Designation;
            UnitNumber = valve.Number;
            AssemblyDate = valve.CompactGateValveJournals?.Where(e => e.Point == "5.4").Select(a => a.Date).Max().GetValueOrDefault().Date;
            TestDate = valve.CompactGateValveJournals?.Where(e => e.Point == "6.17").Select(a => a.Date).Max().GetValueOrDefault().Date;
            CoatingDate = valve.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date;
            ShippingDate = valve.CompactGateValveJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            StringAssemblyDate = AssemblyDate.Value.ToShortDateString();
            StringTestDate = TestDate.Value.ToShortDateString();
            StringCoatingDate = CoatingDate.Value.ToShortDateString();
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public DailyReport(ReverseShutter shutter)
        {
            CustomerName = shutter.PID?.Specification?.Customer?.Name;
            SpecificationNumber = shutter.PID?.Specification?.Number;
            PIDNumber = shutter.PID?.Number;
            Facility = shutter.PID?.Specification?.Facility;
            Designation = shutter.PID?.Designation;
            UnitNumber = shutter.Number;
            AssemblyDate = shutter.ReverseShutterJournals?.Where(e => e.Point == "7.1" && e.Description.Contains("сбор")).Select(a => a.Date).Max().GetValueOrDefault().Date;
            TestDate = shutter.ReverseShutterJournals?.Where(e => e.Point == "7.6").Select(a => a.Date).Max().GetValueOrDefault().Date;
            CoatingDate = shutter.CoatingJournals?.Where(e => e.Point == "9 (АКП)" && e.Description.Contains("адгез")).Select(a => a.Date).Max().GetValueOrDefault().Date;
            ShippingDate = shutter.ReverseShutterJournals?.Where(e => e.EntityTCP.OperationType.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            StringAssemblyDate = AssemblyDate.Value.ToShortDateString();
            StringTestDate = TestDate.Value.ToShortDateString();
            StringCoatingDate = CoatingDate.Value.ToShortDateString();
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }
    }
}
