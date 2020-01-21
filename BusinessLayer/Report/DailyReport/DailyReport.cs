using DataLayer;
using DataLayer.Journals;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLayer.Report.DailyReport
{
    public static class DailyReport
    {
        public static void GetReport()
        {
            using (DataContext db = new DataContext())
            {
                var result = db.SheetMaterialJournals.ToList();
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
                string p_strPath = "C:\\report.xlsx";

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
