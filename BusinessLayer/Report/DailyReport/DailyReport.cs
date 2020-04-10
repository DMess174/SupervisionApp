using DataLayer;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLayer.Report.DailyReport
{
    public class DailyReport
    {
        public DateTime? Date { get; set; }
        public string Point { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Engineer { get; set; }
        public string Remark { get; set; }
        public string RemarkClosed { get; set; }
        public string Comment { get; set; }

        public async void GetReport(DateTime beginDate, DateTime endDate, Inspector inspector, string journal)
        {
            using (DataContext db = new DataContext())
            {
                List<DailyReport> reports = new List<DailyReport>();
                var result = await db.SheetMaterialJournals.Where(i => i.Date >= beginDate && i.Date <= endDate && i.Inspector == inspector && i.JournalNumber == journal).ToListAsync();
                foreach (var i in result)
                {
                    DailyReport reportRecord = new DailyReport
                    {
                        Date = i.Date,
                        Point = i.Point,
                        Name = i.DetailName + i.DetailNumber,
                        Description = i.Description,
                        Status = i.Status,
                        Engineer = i.Inspector.FullName,
                        Remark = i.RemarkIssued,
                        RemarkClosed = i.RemarkClosed,
                        Comment = i.Comment
                    };
                    reports.Add(reportRecord);
                }
                result = null;

                ExcelPackage report = new ExcelPackage();
                var workSheet = report.Workbook.Worksheets.Add("Report");
                int recordIndex = 2;
                foreach (var row in result)
                {
                    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                    workSheet.Cells[recordIndex, 2].Value = row.Point;
                    workSheet.Cells[recordIndex, 3].Value = row.DetailName + " № " + row.DetailNumber;
                    workSheet.Cells[recordIndex, 4].Value = row.Description;
                    workSheet.Cells[recordIndex, 5].Value = row.Status;
                    workSheet.Cells[recordIndex, 6].Value = row.RemarkIssued;
                    workSheet.Cells[recordIndex, 7].Value = row.RemarkClosed;
                    workSheet.Cells[recordIndex, 8].Value = row.Comment;
                    recordIndex++;
                }
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();
                workSheet.Column(6).AutoFit();
                workSheet.Column(7).AutoFit();
                workSheet.Column(8).AutoFit();
                string p_strPath = $@"Reports\.xlsx";

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(p_strPath, report.GetAsByteArray());
            }
            
        }

        


    }
}
