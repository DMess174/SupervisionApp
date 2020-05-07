using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Supervision.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private string filePath;
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

        private IEnumerable<ConsolidatedFOMReport> consolidatedReport;
        public IEnumerable<ConsolidatedFOMReport> ConsolidatedReport
        {
            get => consolidatedReport;
            set
            {
                consolidatedReport = value;
                RaisePropertyChanged();
            }
        }
        private IList<FOMReport> allItems;
        public IList<FOMReport> AllItems
        {
            get => allItems;
            set
            {
                allItems = value;
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
        private DateTime? newPeriod;

        public DateTime? StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? NewPeriod
        {
            get => newPeriod;
            set
            {
                newPeriod = value;
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

        private void CreateFile(object obj)
        {
            IEnumerable<ConsolidatedFOMReport> Reports = obj as IEnumerable<ConsolidatedFOMReport>;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            // Create Excel EPPlus Package
            using (ExcelPackage package = new ExcelPackage())
            {
                foreach (var i in Reports)
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add(i.CustomerName + " " + i.Program);
                    sheet.PrinterSettings.PaperSize = ePaperSize.A4;
                    sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                    sheet.Cells["A1:M1"].Merge = true;
                    sheet.Column(1).Width = 5.5;
                    sheet.Column(1).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(1).Style.Font.Size = 12;
                    sheet.Column(1).Style.WrapText = true;
                    sheet.Column(2).Width = 16;
                    sheet.Column(2).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(2).Style.Font.Size = 12;
                    sheet.Column(2).Style.WrapText = true;
                    sheet.Column(3).Width = 15;
                    sheet.Column(3).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(3).Style.Font.Size = 12;
                    sheet.Column(3).Style.WrapText = true;
                    sheet.Column(4).Width = 47;
                    sheet.Column(4).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(4).Style.Font.Size = 12;
                    sheet.Column(4).Style.WrapText = true;
                    sheet.Column(5).Width = 24;
                    sheet.Column(5).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(5).Style.Font.Size = 12;
                    sheet.Column(5).Style.WrapText = true;
                    sheet.Column(6).Width = 63;
                    sheet.Column(6).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(6).Style.Font.Size = 12;
                    sheet.Column(6).Style.WrapText = true;
                    sheet.Column(7).Width = 25;
                    sheet.Column(7).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(7).Style.Font.Size = 12;
                    sheet.Column(7).Style.WrapText = true;
                    sheet.Column(8).Width = 12;
                    sheet.Column(8).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(8).Style.Font.Size = 12;
                    sheet.Column(8).Style.WrapText = true;
                    sheet.Column(9).Width = 24;
                    sheet.Column(9).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(9).Style.Font.Size = 12;
                    sheet.Column(9).Style.WrapText = true;
                    sheet.Column(10).Width = 30;
                    sheet.Column(10).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(10).Style.Font.Size = 12;
                    sheet.Column(10).Style.WrapText = true;
                    sheet.Column(11).Width = 16;
                    sheet.Column(11).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(11).Style.Font.Size = 12;
                    sheet.Column(11).Style.WrapText = true;
                    sheet.Column(12).Width = 5.3;
                    sheet.Column(12).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(12).Style.Font.Size = 12;
                    sheet.Column(12).Style.WrapText = true;
                    sheet.Column(13).Width = 13.3;
                    sheet.Column(13).Style.Font.Name = "Franklin Gothic Book";
                    sheet.Column(13).Style.Font.Size = 12;
                    sheet.Column(13).Style.WrapText = true;

                    sheet.Row(1).Style.Font.Bold = true;
                    sheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                    sheet.Row(1).CustomHeight = true;
                    sheet.Row(1).Height = 66.75;

                    sheet.Row(2).Style.Font.Bold = true;
                    sheet.Row(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sheet.Row(2).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sheet.Row(2).CustomHeight = true;
                    sheet.Row(2).Height = 108;

                    sheet.Row(3).Style.Font.Bold = true;
                    sheet.Row(3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sheet.Row(3).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sheet.Row(3).CustomHeight = true;
                    sheet.Row(3).Height = 16.5;
                    sheet.Cells["A1"].Value = $"Отчет № _______\n по продукции, прошедшей технический надзор на ООО \"Корнет\"\n и отгруженной в адрес " + i.CustomerFullName +", по программе " + i.Program + " за " + StartDate.Value.ToString("d") + " - " + EndDate.Value.ToString("d") + " г.";
                    sheet.Cells["A2"].Value = "№ п/п";
                    sheet.Cells["B2"].Value = "Номер транспортного средства";
                    sheet.Cells["C2"].Value = "Дата отгрузки";
                    sheet.Cells["D2"].Value = "Станция назначения, Грузополучатель";
                    sheet.Cells["E2"].Value = "Тип продукции";
                    sheet.Cells["F2"].Value = "Наименование изделий (элементов) продукции";
                    sheet.Cells["G2"].Value = "Номер спецификации";
                    sheet.Cells["H2"].Value = "Идентификационный номер (PID)";
                    sheet.Cells["I2"].Value = "Монтажная маркировка (номер заводского заказа) условно";
                    sheet.Cells["J2"].Value = "ТУ, ГОСТ";
                    sheet.Cells["K2"].Value = "№ протокола качества (сертификат) на продукцию";
                    sheet.Cells["L2"].Value = "Кол-во шт.";
                    sheet.Cells["M2"].Value = "Вес, кг.";
                    sheet.Cells["A3"].Value = "1";
                    sheet.Cells["B3"].Value = "2";
                    sheet.Cells["C3"].Value = "3";
                    sheet.Cells["D3"].Value = "4";
                    sheet.Cells["E3"].Value = "5";
                    sheet.Cells["F3"].Value = "6";
                    sheet.Cells["G3"].Value = "7";
                    sheet.Cells["H3"].Value = "8";
                    sheet.Cells["I3"].Value = "9";
                    sheet.Cells["J3"].Value = "10";
                    sheet.Cells["K3"].Value = "11";
                    sheet.Cells["L3"].Value = "12";
                    sheet.Cells["M3"].Value = "13";
                    
                    int recordIndex = 4;
                    foreach (var row in i.FOMReports)
                    {
                        
                        sheet.Row(recordIndex).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Row(recordIndex).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        sheet.Row(recordIndex).CustomHeight = false;
                        if (NewPeriod != null && row.ShippingDate >= NewPeriod)
                        {
                            sheet.Cells[recordIndex, 1, recordIndex, 13].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            sheet.Cells[recordIndex, 1, recordIndex, 13].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                        }
                        sheet.Cells[recordIndex, 1].Value = (recordIndex - 3).ToString();
                        sheet.Cells[recordIndex, 2].Value = row.AutoNumber;
                        sheet.Cells[recordIndex, 3].Value = row.StringShippingDate;
                        sheet.Cells[recordIndex, 4].Value = row.Consignee;
                        sheet.Cells[recordIndex, 5].Value = row.ProductType;
                        sheet.Cells[recordIndex, 6].Value = row.ProductDescription;
                        sheet.Cells[recordIndex, 7].Value = row.SpecificationNumber;
                        sheet.Cells[recordIndex, 8].Value = row.PIDNumber;
                        sheet.Cells[recordIndex, 9].Value = row.DesignationNumber;
                        sheet.Cells[recordIndex, 10].Value = row.STD;
                        sheet.Cells[recordIndex, 11].Value = row.CertificateNumber;
                        sheet.Cells[recordIndex, 12].Value = row.Amount;
                        sheet.Cells[recordIndex, 13].Value = row.Weight;
                        recordIndex++;
                        
                    }
                    sheet.Cells[recordIndex, 1, recordIndex, 11].Merge = true;
                    sheet.Row(recordIndex).Style.Font.Bold = true;
                    sheet.Row(recordIndex).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                    sheet.Row(recordIndex).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sheet.Row(recordIndex).CustomHeight = true;
                    sheet.Row(recordIndex).Height = 16.5;

                    sheet.Cells[recordIndex, 1].Value = "Итог";
                    sheet.Cells[recordIndex, 12].Formula = "=SUM(" + sheet.Cells[4, 12].Address + ":" + sheet.Cells[recordIndex - 1, 12].Address + ")";
                    sheet.Cells[recordIndex, 13].Formula = "=SUM(" + sheet.Cells[4, 13].Address + ":" + sheet.Cells[recordIndex - 1, 13].Address + ")";
                    sheet.Cells[recordIndex, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sheet.Cells[recordIndex, 13].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, recordIndex, 13];
                    sheet.PrinterSettings.FitToPage = true;
                    sheet.PrinterSettings.FitToWidth = 1;
                    sheet.PrinterSettings.FitToHeight = 0;
                    sheet.Cells[2, 1, recordIndex, 13].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex, 13].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex, 13].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex, 13].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.View.ZoomScale = 70;
                    sheet.View.PageBreakView = true;
                }
                byte[] bin = package.GetAsByteArray();
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\FOM.xlsx";
                if (File.Exists(filePath))
                    File.Delete(filePath);
                File.WriteAllBytes(filePath, bin);
                FileInfo fi = new FileInfo(filePath);
            }
        }

        public ICommand OpenExcelReportCommand { get; private set; }
        private void OpenExcelReport()
        {
            if (filePath != null & File.Exists(filePath))
                Process.Start(filePath);
        }

        private async Task<IEnumerable<CastGateValve>> GetAllCastGateValveData()
        {
            return await db.CastGateValves.Include(i => i.CastGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.CastGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка") && i.AutoNumber != null).ToListAsync();
        }

        private async Task<IEnumerable<SheetGateValve>> GetAllSheetGateValveData()
        {
            return await db.SheetGateValves.Include(i => i.SheetGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.SheetGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка") && i.AutoNumber != null).ToListAsync();
        }

        private async Task<IEnumerable<CompactGateValve>> GetAllCompactGateValveData()
        {
            return await db.CompactGateValves.Include(i => i.CompactGateValveJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.CompactGateValveJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка") && i.AutoNumber != null).ToListAsync();
        }

        private async Task<IEnumerable<ReverseShutter>> GetAllReverseShutterData()
        {
            return await db.ReverseShutters.Include(i => i.ReverseShutterJournals).ThenInclude(i => i.EntityTCP)
                .ThenInclude(i => i.OperationType)
                .Include(i => i.PID)
                .ThenInclude(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .Where(i => i.ReverseShutterJournals.Any(e => e.Date >= StartDate && e.Date <= EndDate && e.EntityTCP.OperationType.Name == "Отгрузка") && i.AutoNumber != null).ToListAsync();
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
                        AllItems = new List<FOMReport>();
                        CastGateValves = new List<FOMReport>();
                        foreach (var i in result)
                        {
                            var record = new FOMReport(i);
                            CastGateValves.Add(record);
                            AllItems.Add(record);
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
                            AllItems.Add(record);
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
                            AllItems.Add(record);
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
                            AllItems.Add(record);
                        }
                        ReverseShuttersView = CollectionViewSource.GetDefaultView(ReverseShutters);
                    }
                }));
                var t = AllItems.GroupBy(c => new
                {
                    c.CustomerFullName,
                    c.CustomerName,
                    c.Program,
                })
                .Select(gcs => new ConsolidatedFOMReport()
                {
                    CustomerName = gcs.Key.CustomerName,
                    CustomerFullName = gcs.Key.CustomerFullName,
                    Program = gcs.Key.Program,
                    FOMReports = gcs.OrderBy(i => i.ShippingDate).ToList(),
                });
                ConsolidatedReport = t;
                if (ConsolidatedReport != null) CreateFile(ConsolidatedReport);
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
            OpenExcelReportCommand = new Command(o => OpenExcelReport());
        }
    }

    public class ConsolidatedFOMReport
    {
        public string CustomerFullName { get; set; }
        public string CustomerName { get; set; }
        public string Program { get; set; }
        public IList<FOMReport> FOMReports { get; set; }
    }

    public class FOMReport
    {
        public string CustomerFullName { get; set; }
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
        public string Program { get; set; }

        public FOMReport() {}

        public FOMReport(CastGateValve valve)
        {
            CustomerFullName = valve.PID?.Specification?.Customer?.Name;
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
            Program = valve.PID?.Specification?.Program;
        }

        public FOMReport(SheetGateValve valve)
        {
            CustomerFullName = valve.PID?.Specification?.Customer?.Name;
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
            Program = valve.PID?.Specification?.Program;
        }

        public FOMReport(CompactGateValve valve)
        {
            CustomerFullName = valve.PID?.Specification?.Customer?.Name;
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
            Program = valve.PID?.Specification?.Program;
        }

        public FOMReport(ReverseShutter shutter)
        {
            CustomerFullName = shutter.PID?.Specification?.Customer?.Name;
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
            Program = shutter.PID?.Specification?.Program;
        }
    }
}
