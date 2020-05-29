using BusinessLayer.Repository.Implementations.Entities;
using DataLayer;
using DataLayer.Journals;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Materials;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Periodical;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Supervision.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels
{
    public class JournalReportVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private IList<Inspector> inspectors;
        private IEnumerable<string> journalNumbers;
        private string journalNumber;
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
        public IList<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
            }
        }
        public string JournalNumber
        {
            get => journalNumber;
            set
            {
                journalNumber = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<JournalReport> journal;
        public ObservableCollection<JournalReport> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged();
            }
        }

        private DateTime? date;
        private Inspector inspector;

        public Inspector Inspector
        {
            get => inspector;
            set
            {
                inspector = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? Date
        {
            get => date;
            set
            {
                date = value;
                RaisePropertyChanged();
            }
        }

        private string filePath;


        private void CreateFile(object obj)
        {
            IEnumerable<JournalReport> journalReport = obj as IEnumerable<JournalReport>;

            // Read Template
            using (FileStream templateDocumentStream = File.OpenRead("BaseJournalReport.xlsx"))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Create Excel EPPlus Package based on template stream
                using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                {
                    // Grab the sheet with the template, sheet name is "Report".
                    ExcelWorksheet sheet = package.Workbook.Worksheets["Report"];
                    int recordIndex = 4;
                    sheet.Cells[1, 9].Value = JournalNumber;
                    foreach (var row in journalReport)
                    {
                        sheet.Cells[recordIndex, 1].Value = (recordIndex - 3).ToString();
                        sheet.Cells[recordIndex, 2].Value = row.StringDate;
                        sheet.Cells[recordIndex, 3].Value = row.Point;
                        sheet.Cells[recordIndex, 4].Value = row.Name;
                        sheet.Cells[recordIndex, 5].Value = row.Description;
                        sheet.Cells[recordIndex, 5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                        sheet.Cells[recordIndex, 6].Value = row.Status;
                        sheet.Cells[recordIndex, 7].Value = !String.IsNullOrWhiteSpace(row.Remark) ? row.Remark : "-";
                        sheet.Cells[recordIndex, 8].Value = !String.IsNullOrWhiteSpace(row.RemarkClosed) ? row.RemarkClosed : "-";
                        sheet.Cells[recordIndex, 9].Value = row.Engineer;
                        sheet.Cells[recordIndex, 10].Value = !String.IsNullOrWhiteSpace(row.Comment) ? row.Comment : "-";
                        recordIndex++;
                    }
                    sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, recordIndex - 1, 10];
                    sheet.Cells[2, 1, recordIndex - 1, 10].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex - 1, 10].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex - 1, 10].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    sheet.Cells[2, 1, recordIndex - 1, 10].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    byte[] bin = package.GetAsByteArray();
                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Report.xlsx";
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    File.WriteAllBytes(filePath, bin);
                    FileInfo fi = new FileInfo(filePath);
                }
            }
        }

        public ICommand OpenExcelReportCommand { get; private set; }
        private void OpenExcelReport()
        {
            if (filePath != null & File.Exists(filePath))
                Process.Start(filePath);
        }

        public ICommand PrintReportCommand { get; private set; }
        private void PrintReport()
        {
            if (filePath != null & File.Exists(filePath))
            {
                //TODO: Реализовать печать без открытия Excel файла

            }
        }

        
                    

        public IAsyncCommand CreateReportFileCommand { get; private set; }
        private async Task CreateReportFile()
        {
            try
            {
                IsBusy = true;
                var report = new ObservableCollection<JournalReport>();
                if (Inspector != null && JournalNumber != null && Date != null)
                {
                    var insp = await Task.Run(() => GetInspectorRecordsAsync(Inspector.Id));

                    foreach (var i in insp.CastGateValveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoatingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CompactGateValveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ReverseShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SheetGateValveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CastGateValveCaseJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CastGateValveCoverJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ShutterDiskJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ShutterGuideJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.BronzeSleeveShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ReverseShutterCaseJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ShaftShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SlamShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SteelSleeveShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.StubShutterJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CaseBottomJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CaseEdgeJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CaseFlangeJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CompactGateValveCaseJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CompactGateValveCoverJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoverFlangeJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoverSleeveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.FrontWallJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SheetGateValveCaseJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SheetGateValveCoverJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SideWallJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.WeldNozzleJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.AssemblyUnitSealingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.BallValveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CounterFlangeJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoverSealingRingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.FrontalSaddleSealingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.GateJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.NozzleJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.RunningSleeveJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SaddleJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ScrewNutJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ScrewStudJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ShearPinJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SpindleJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SpringJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.AbovegroundCoatingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.AbrasiveMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.UndercoatJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.UndergroundCoatingJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ControlWeldJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.ForgingMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.PipeMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.RolledMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.SheetMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.StoresControlJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.WeldingMaterialJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoatingChemicalCompositionJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoatingPlasticityJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoatingPorosityJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.CoatingProtectivePropertiesJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.DegreasingChemicalCompositionJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.NDTControls.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.WeldingProceduresJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.FactoryInspectionJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    foreach (var i in insp.PIDJournals.Where(i => i.Date == Date && i.JournalNumber == JournalNumber && i.DetailId != null))
                    {
                        var temp = new JournalReport(i);
                        report.Add(temp);
                    }
                    Journal = report;
                }

                if (Journal != null) CreateFile(Journal);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<Inspector> GetInspectorRecordsAsync(int id)
        {
            using (DataContext context = new DataContext())
            {
                var result = await context.Inspectors
                    .Include(i => i.PIDJournals).ThenInclude(e => e.Entity).ThenInclude(e => e.Specification)
                    .Include(i => i.CastGateValveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CompactGateValveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SheetGateValveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ReverseShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CoatingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CastGateValveCaseJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CastGateValveCoverJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ShutterDiskJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ShutterGuideJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.BronzeSleeveShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ReverseShutterCaseJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ShaftShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SlamShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SteelSleeveShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.StubShutterJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CaseBottomJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CaseEdgeJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CaseFlangeJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CompactGateValveCaseJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CompactGateValveCoverJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CoverFlangeJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CoverSleeveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.FrontWallJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SheetGateValveCaseJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SheetGateValveCoverJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SideWallJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.WeldNozzleJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.AssemblyUnitSealingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.BallValveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CounterFlangeJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CoverSealingRingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.FrontalSaddleSealingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.GateJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.NozzleJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.RunningSleeveJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SaddleJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ScrewNutJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ScrewStudJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ShearPinJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SpindleJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SpringJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.AbovegroundCoatingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.AbrasiveMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.UndercoatJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.UndergroundCoatingJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ControlWeldJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.ForgingMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.PipeMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.RolledMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.SheetMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.StoresControlJournals)
                    .Include(i => i.WeldingMaterialJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.CoatingChemicalCompositionJournals)
                    .Include(i => i.CoatingPlasticityJournals)
                    .Include(i => i.CoatingPorosityJournals)
                    .Include(i => i.CoatingProtectivePropertiesJournals)
                    .Include(i => i.DegreasingChemicalCompositionJournals)
                    .Include(i => i.NDTControls).ThenInclude(e => e.Entity)
                    .Include(i => i.WeldingProceduresJournals).ThenInclude(e => e.Entity)
                    .Include(i => i.FactoryInspectionJournals)
                    .FirstOrDefaultAsync(i => i.Id == id);
                return result;
            }
        }

        public ICommand CloseWindowCommand { get; set; }
        private void CloseWindow(object obj)
        {
            Window w = obj as Window;
            w?.Close();
        }

        public Commands.IAsyncCommand LoadItemCommand { get; private set; }
        public async Task Load()
        {
            try
            {
                IsBusy = true;
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
            }
            finally
            {
                IsBusy = false;
            }
        }

        public static JournalReportVM LoadVM(DataContext context)
        {
            JournalReportVM vm = new JournalReportVM(context);
            vm.LoadItemCommand.ExecuteAsync();
            return vm;
        }

        public JournalReportVM(DataContext context)
        {
            db = context;
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            CreateReportFileCommand = new Commands.AsyncCommand(CreateReportFile);
            CloseWindowCommand = new Command(o => CloseWindow(o));
            OpenExcelReportCommand = new Command(o => OpenExcelReport());
            PrintReportCommand = new Command(o => PrintReport());
            LoadItemCommand = new Commands.AsyncCommand(Load);
        }
    }

    public class JournalReport
    {
        public DateTime? Date { get; set; }
        public string StringDate { get; set; }
        public string Point { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Engineer { get; set; }
        public string Remark { get; set; }
        public string RemarkClosed { get; set; }
        public string Comment { get; set; }

        #region Constructors

        public JournalReport() {}

        public JournalReport(CastGateValveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoatingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CompactGateValveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ReverseShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SheetGateValveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CastGateValveCaseJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CastGateValveCoverJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ShutterDiskJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ShutterGuideJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(BronzeSleeveShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ReverseShutterCaseJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ShaftShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SlamShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SteelSleeveShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(StubShutterJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CaseBottomJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CaseEdgeJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CaseFlangeJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CompactGateValveCaseJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CompactGateValveCoverJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoverFlangeJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoverSleeveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(FrontWallJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SheetGateValveCaseJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SheetGateValveCoverJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SideWallJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(WeldNozzleJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(AssemblyUnitSealingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " партия № " + journal.Entity.Batch + ", серия № " + journal.Entity.Series + " - " + journal.Entity.Amount + " шт.";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(BallValveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " " + journal.Entity.Designation + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CounterFlangeJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoverSealingRingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(FrontalSaddleSealingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " партия № " + journal.Entity.Batch + ", серия № " + journal.Entity.Series + " - " + journal.Entity.Amount + " шт.";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(GateJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(NozzleJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(RunningSleeveJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SaddleJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ScrewNutJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " " + journal.Entity.Thread + " № " + journal.Entity.Number + " - " + journal.Entity.Amount + " шт.";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ScrewStudJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " " + journal.Entity.Thread + " № " + journal.Entity.Number + " - " + journal.Entity.Amount + " шт.";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ShearPinJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SpindleJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SpringJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number + " - " + journal.Entity.Amount + " шт.";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(AbovegroundCoatingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Batch;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }
        public JournalReport(AbrasiveMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Batch;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(UndercoatJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Batch;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }
        public JournalReport(UndergroundCoatingJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Batch;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ControlWeldJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(SheetMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(PipeMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(RolledMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(ForgingMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(StoresControlJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = "Хранение и складирование материалов";
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(WeldingMaterialJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name + " № " + journal.Entity.Batch + " - " + journal.Entity.Amount;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoatingChemicalCompositionJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoatingPlasticityJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoatingPorosityJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(CoatingProtectivePropertiesJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(DegreasingChemicalCompositionJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(NDTControlJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(WeldingProceduresJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = journal.Entity.Name;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(FactoryInspectionJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        public JournalReport(PIDJournal journal)
        {
            Date = journal.Date;
            StringDate = Date.Value.ToShortDateString();
            Point = journal.Point;
            Name = "PID № " + journal.Entity.Number + ";\nСпецификация № " + journal.Entity.Specification.Number;
            Description = journal.Description;
            Status = journal.Status;
            Engineer = journal.Inspector.FullName;
            Remark = journal.RemarkIssued;
            RemarkClosed = journal.RemarkClosed;
            Comment = journal.Comment;
        }

        #endregion

    }
}
