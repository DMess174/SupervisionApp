using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DevExpress.Mvvm;
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
    public class FOMReportVM : BasePropertyChanged
    {
        private DataContext db;
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


        private IList<FOMReport> castGateValves;
        public IList<FOMReport> CastGateValves
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
        private IList<FOMReport> sheetGateValves;
        public IList<FOMReport> SheetGateValves
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
        private IList<FOMReport> compactGateValves;
        public IList<FOMReport> CompactGateValves
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
        private IList<FOMReport> reverseShutters;
        public IList<FOMReport> ReverseShutters
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

        private DateTime? startDate;
        private DateTime? endDate;

        public DateTime? StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                RaisePropertyChanged();
            }
        }
        private async Task<IEnumerable<CastGateValve>> GetAllCastGateValveData()
        {
            return await db.CastGateValves.Include(i => i.CastGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.CastGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка")).ToListAsync();
        }

        private async Task<IEnumerable<SheetGateValve>> GetAllSheetGateValveData()
        {
            return await db.SheetGateValves.Include(i => i.SheetGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.SheetGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка")).ToListAsync();
        }

        private async Task<IEnumerable<CompactGateValve>> GetAllCompactGateValveData()
        {
            return await db.CompactGateValves.Include(i => i.CompactGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.CompactGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка")).ToListAsync();
        }

        private async Task<IEnumerable<ReverseShutter>> GetAllReverseShutterData()
        {
            return await db.ReverseShutters.Include(i => i.ReverseShutterJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.ReverseShutterJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка")).ToListAsync();
        }


        public IAsyncCommand GetReportCommand { get; private set; }
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
                        CastGateValves = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
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
                        SheetGateValves = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
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
                        CompactGateValves = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
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
                        CompactGateValves = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
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
                        ReverseShutters = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
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

        public ICommand CloseWindowCommand { get; set; }
        private void CloseWindow(object obj)
        {
            Window w = obj as Window;
            w?.Close();
        }


        public FOMReportVM(DataContext context)
        {
            db = context;
            GetReportCommand = new Commands.AsyncCommand(Report);
            CloseWindowCommand = new Command(o => CloseWindow(o));
        }
    }

    public class FOMReport
    {
        public string CustomerName { get; set; }
        public string AutoNumber { get; set; }
        public string StringShippingDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string Consignee { get; set; }
        public string ProductType { get; set; } = "Запорная арматура с антикоррозионным покрытием";
        public string ProductDescription { get; set; }
        public string SpecificationNumber { get; set; }
        public string PIDNumber { get; set; }
        public string DesignationNumber { get; set; }
        public string STD { get; set; }
        public string CertificateNumber { get; set; }
        public int Amount { get; set; } = 1;
        public int? Weight { get; set; }

        public FOMReport() {}

        public FOMReport(CastGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.ShortName;
            AutoNumber = valve.AutoNumber;
            ShippingDate = valve.CastGateValveJournals?.Where(e => e.EntityTCP?.OperationType?.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            Consignee = valve.PID?.Consignee;
            ProductDescription = valve.PID?.Description;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            DesignationNumber = valve.PID?.Designation + " №" + valve.Number;
            STD = valve.PID?.STD1 + $"\n" + valve.PID?.STD2;
            CertificateNumber = valve.Number;
            Weight = valve.PID?.Weight;
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public FOMReport(SheetGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.ShortName;
            AutoNumber = valve.AutoNumber;
            ShippingDate = valve.SheetGateValveJournals?.Where(e => e.EntityTCP?.OperationType?.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            Consignee = valve.PID?.Consignee;
            ProductDescription = valve.PID?.Description;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            DesignationNumber = valve.PID?.Designation + " №" + valve.Number;
            STD = valve.PID?.STD1 + $"\n" + valve.PID?.STD2;
            CertificateNumber = valve.Number;
            Weight = valve.PID?.Weight;
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public FOMReport(CompactGateValve valve)
        {
            CustomerName = valve.PID?.Specification?.Customer?.ShortName;
            AutoNumber = valve.AutoNumber;
            ShippingDate = valve.CompactGateValveJournals?.Where(e => e.EntityTCP?.OperationType?.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            Consignee = valve.PID?.Consignee;
            ProductDescription = valve.PID?.Description;
            SpecificationNumber = valve.PID?.Specification?.Number;
            PIDNumber = valve.PID?.Number;
            DesignationNumber = valve.PID?.Designation + " №" + valve.Number;
            STD = valve.PID?.STD1 + $"\n" + valve.PID?.STD2;
            CertificateNumber = valve.Number;
            Weight = valve.PID?.Weight;
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }

        public FOMReport(ReverseShutter shutter)
        {
            CustomerName = shutter.PID?.Specification?.Customer?.ShortName;
            AutoNumber = shutter.AutoNumber;
            ShippingDate = shutter.ReverseShutterJournals?.Where(e => e.EntityTCP?.OperationType?.Name == "Отгрузка").Select(a => a.Date).Max().GetValueOrDefault().Date;
            Consignee = shutter.PID?.Consignee;
            ProductDescription = shutter.PID?.Description;
            SpecificationNumber = shutter.PID?.Specification?.Number;
            PIDNumber = shutter.PID?.Number;
            DesignationNumber = shutter.PID?.Designation + " №" + shutter.Number;
            STD = shutter.PID?.STD1 + $"\n" + shutter.PID?.STD2;
            CertificateNumber = shutter.Number;
            Weight = shutter.PID?.Weight;
            StringShippingDate = ShippingDate.Value.ToShortDateString();
        }
    }
}
