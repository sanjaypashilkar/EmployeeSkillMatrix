using ClosedXML.Excel;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SkillMatrix.Service
{
    public class ReportService : IReportService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }

        public ReportService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public vwSkillReport GetSkillMatrixReport(SkillMatrixFilter filter = null)
        {
            if (filter == null)
            {
                filter = new SkillMatrixFilter();
                int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
                int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
                int currentYear = DateTime.Today.Year;
                int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
                filter.Year = selectedYear;
                filter.Quarter = selectedQuarter;
            }

            vwSkillReport report = new vwSkillReport();
            report.SkillMatrixFilter = filter;
            report.lstYears = mtdGetYears();
            report.lstQuarters = mtdGetQuarters();
            report.lstTeams = mtdGetTeams(filter.Year, filter.Quarter);
            report.lstCompetencyLevel = mtdGetCompetencyLevel();
            report.lstTenureLevel = mtdGetTenureLevel();
            var skillMatrices = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(filter.Year, filter.Quarter).ToList();            
            if(!string.IsNullOrEmpty(filter.Team))
            {
                skillMatrices = skillMatrices.Where(s => s.Team.ToLower() == filter.Team.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.CompetencyLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.CompetencyLevel.ToLower() == filter.CompetencyLevel.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.TenureLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.TenureLevel.ToLower() == filter.TenureLevel.ToLower()).ToList();
            }
            if (skillMatrices.Count > 0)
            {
                report.SkillMatrix = skillMatrices;
            }
            return report;
        }

        public Dictionary<string,string> mtdGetYears()
        {
            var selectList = Enumerable.Range(DateTime.Now.AddYears(-10).Year, 11).Reverse().Select(i => new { key = i.ToString(), value = i.ToString()}).ToDictionary(x=> x.key, x=>x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetQuarters()
        {
            var selectList = Enumerable.Range(1, 4).Select(i => new { key = i.ToString(), value = i.ToString()}).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetTeams(int year, int quarter)
        {
            var skillMatrix = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(year, quarter);
            var teams = skillMatrix.Select(i => i.Team).ToList().Distinct();
            var selectList = teams.Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetCompetencyLevel()
        {
            var selectList = _skillMatrixRepository.GetCompetencyLevelScoring().Select(i => new { key = i.Level.ToString(), value = i.Level.ToString() }).ToDictionary(x => x.key, x => x.value);       
            return selectList;
        }

        public Dictionary<string, string> mtdGetTenureLevel()
        {
            var selectList = _skillMatrixRepository.GetTenureLevel().Select(i => new { key = i.Level.ToString(), value = i.Level.ToString() }).ToDictionary(x => x.key, x => x.value);           
            return selectList;
        }

        public static void GenerateExcel(SkillMatrixFilter filter)
        {
            #region Scrap

            //int rowIndex = 2;
            //ExcelRange cell;
            //ExcelFill fill;
            //Border border;
            //var skillReport = GetSkillMatrixReport(filter);
            //using (var excelPackage = new ExcelPackage())
            //{
            //    excelPackage.Workbook.Properties.Author = "SPI-Global";
            //    excelPackage.Workbook.Properties.Title = "SPI-Global";
            //    var sheet = excelPackage.Workbook.Worksheets.Add("Skill Matrix");
            //    sheet.Name = "Skill Matrix Report";
            //    sheet.Column(2).Width = 10;
            //    sheet.Column(3).Width = 30;
            //    sheet.Column(4).Width = 40;

            //    #region Report Header

            //    sheet.Cells[rowIndex, 2, rowIndex, 4].Merge = true;
            //    cell = sheet.Cells[rowIndex, 2];
            //    cell.Value = "ABC";
            //    cell.Style.Font.Bold = true;
            //    cell.Style.Font.Size = 15;
            //    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    rowIndex = rowIndex + 2;
            //    #endregion

            //    #region Table Header

            //    cell = sheet.Cells[rowIndex, 2];
            //    cell.Value = "Sr.No.";
            //    cell.Style.Font.Bold = true;
            //    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    fill = cell.Style.Fill;
            //    fill.PatternType = ExcelFillStyle.Solid;
            //    fill.BackgroundColor.SetColor(Color.LightGray);
            //    border = cell.Style.Border;
            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            //    cell = sheet.Cells[rowIndex, 3];
            //    cell.Value = "Team";
            //    cell.Style.Font.Bold = true;
            //    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    fill = cell.Style.Fill;
            //    fill.PatternType = ExcelFillStyle.Solid;
            //    fill.BackgroundColor.SetColor(Color.LightGray);
            //    border = cell.Style.Border;
            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            //    cell = sheet.Cells[rowIndex, 4];
            //    cell.Value = "Name";
            //    cell.Style.Font.Bold = true;
            //    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //    fill = cell.Style.Fill;
            //    fill.PatternType = ExcelFillStyle.Solid;
            //    fill.BackgroundColor.SetColor(Color.LightGray);
            //    border = cell.Style.Border;
            //    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            //    rowIndex = rowIndex + 1;

            //    #endregion

            //    #region Table body
            //    int serialNumber = 1;

            //    if(skillReport.SkillMatrix.Count>0)
            //    {
            //        foreach(var skillMatrix in skillReport.SkillMatrix)
            //        {
            //            cell = sheet.Cells[rowIndex, 2];
            //            cell.Value = serialNumber++.ToString();
            //            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //            fill = cell.Style.Fill;
            //            fill.PatternType = ExcelFillStyle.Solid;
            //            fill.BackgroundColor.SetColor(Color.White);
            //            border = cell.Style.Border;
            //            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            //            cell = sheet.Cells[rowIndex, 3];
            //            cell.Value = skillMatrix.Team;
            //            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //            fill = cell.Style.Fill;
            //            fill.PatternType = ExcelFillStyle.Solid;
            //            fill.BackgroundColor.SetColor(Color.White);
            //            border = cell.Style.Border;
            //            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            //            cell = sheet.Cells[rowIndex, 4];
            //            cell.Value = skillMatrix.Name;
            //            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //            fill = cell.Style.Fill;
            //            fill.PatternType = ExcelFillStyle.Solid;
            //            fill.BackgroundColor.SetColor(Color.White);
            //            border = cell.Style.Border;
            //            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            //            rowIndex = rowIndex + 1;
            //        }
            //    }

            //    #endregion

            //    return excelPackage.GetAsByteArray();
            //}

            #endregion

            //var skillReport = GetSkillMatrixReport(filter);

            //using (var workbook = new XLWorkbook())
            //{
            //    var worksheet = workbook.Worksheets.Add("SkillMatrix");
            //    var currentRow = 1;
            //    #region Header

            //    worksheet.Cell(currentRow, 1).Value = "Sr.No.";
            //    worksheet.Cell(currentRow, 2).Value = "Team";
            //    worksheet.Cell(currentRow, 3).Value = "Name";

            //    #endregion

            //    #region Body

            //    foreach(var skillMatrix in skillReport.SkillMatrix)
            //    {
            //        currentRow++;
            //        worksheet.Cell(currentRow, 1).Value = currentRow-1;
            //        worksheet.Cell(currentRow, 2).Value = skillMatrix.Team;
            //        worksheet.Cell(currentRow, 3).Value = skillMatrix.Name;
            //    }

            //    #endregion

            //    using (var stream = new MemoryStream())
            //    {
            //        workbook.SaveAs(stream);
            //        var content = stream.ToArray();
            //        return File(
            //            content,
            //            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            //            "SkillMatrix.xlsx"
            //            );
            //    }
            //}
        }
    }
}
