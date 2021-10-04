using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Model;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SkillMatrix.Web.Controllers
{
    public class ReportController : Controller
    {
        public IReportService _reportService { get; set; }
        const int pageSize = 10;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        #region SkillMatrix
        public IActionResult Index()
        {
            var report = _reportService.GetSkillMatrixReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult Index(SkillMatrixFilter filter)
        {
            var report = _reportService.GetSkillMatrixReport(filter);
            return PartialView("_FilterAndTable", report);
        }

        [HttpPost]
        public IActionResult Filter(SkillMatrixFilter filter)
        {
            var report = _reportService.GetSkillMatrixReport(filter);
            return PartialView("_Table", report);
        }

        [HttpGet]
        public IActionResult Excel(int year, int quarter, string team, string competency, string tenure)
        {
            var filter = new SkillMatrixFilter
            {
                Year=year,
                Quarter=quarter,
                Team = team,
                CompetencyLevel = competency,
                TenureLevel = tenure,
            };

            var skillReport = _reportService.GetSkillMatrixReport(filter);

            #region Workbook

            using (var workbook = new XLWorkbook())
            {
                var tab = $"Q{filter.Quarter} Competency Matrix";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Arial");
                var currentRow = 1;

                #region Header

                worksheet.Cell(currentRow, 7).Value = "Proficiency Report";
                worksheet.Cell(currentRow, 9).Value = "Time Spent";
                worksheet.Cell(currentRow, 12).Value = "Questions Statistics Report";
                worksheet.Cell(currentRow, 15).Value = "Certification Score";
                worksheet.Cell(currentRow, 17).Value = "CSAT Score";
                worksheet.Cell(currentRow, 19).Value = "QC Score";

                IXLRange range1_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                range1_1_6.Style.Fill.SetBackgroundColor(XLColor.Black);

                IXLRange range1_7_8 = worksheet.Range(worksheet.Cell(currentRow, 7).Address, worksheet.Cell(currentRow, 8).Address);
                range1_7_8.Merge();
                range1_7_8.Style.Font.Bold = true;
                range1_7_8.Style.Font.FontSize = 9;
                range1_7_8.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#f0bf60"));
                range1_7_8.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_9_11 = worksheet.Range(worksheet.Cell(currentRow, 9).Address, worksheet.Cell(currentRow, 11).Address);
                range1_9_11.Merge();
                range1_9_11.Style.Font.Bold = true;
                range1_9_11.Style.Font.FontSize = 9;
                range1_9_11.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#f0bf60"));
                range1_9_11.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_12_14 = worksheet.Range(worksheet.Cell(currentRow, 12).Address, worksheet.Cell(currentRow, 14).Address);
                range1_12_14.Merge();
                range1_12_14.Style.Font.Bold = true;
                range1_12_14.Style.Font.FontSize = 9;
                range1_12_14.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#f0bf60"));
                range1_12_14.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_15_16 = worksheet.Range(worksheet.Cell(currentRow, 15).Address, worksheet.Cell(currentRow, 16).Address);
                range1_15_16.Merge();
                range1_15_16.Style.Font.Bold = true;
                range1_15_16.Style.Font.FontSize = 9;
                range1_15_16.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#f0bf60"));
                range1_15_16.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_17_18 = worksheet.Range(worksheet.Cell(currentRow, 17).Address, worksheet.Cell(currentRow, 18).Address);
                range1_17_18.Merge();
                range1_17_18.Style.Font.Bold = true;
                range1_17_18.Style.Font.FontSize = 9;
                range1_17_18.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#FF944D"));
                range1_17_18.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_19_20 = worksheet.Range(worksheet.Cell(currentRow, 19).Address, worksheet.Cell(currentRow, 20).Address);
                range1_19_20.Merge();
                range1_19_20.Style.Font.Bold = true;
                range1_19_20.Style.Font.FontSize = 9;
                range1_19_20.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#2463E6"));
                range1_19_20.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_21_24 = worksheet.Range(worksheet.Cell(currentRow, 21).Address, worksheet.Cell(currentRow, 24).Address);
                range1_21_24.Style.Fill.SetBackgroundColor(XLColor.Black);

                IXLBorder border1_1_24 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 24).Address).Style.Border;
                border1_1_24.BottomBorder = border1_1_24.TopBorder = border1_1_24.LeftBorder = border1_1_24.RightBorder = XLBorderStyleValues.Thin;

                worksheet.Columns().AdjustToContents();

                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Sr.No.";
                worksheet.Cell(currentRow, 2).Value = "Team";
                worksheet.Cell(currentRow, 3).Value = "Name";
                worksheet.Cell(currentRow, 4).Value = "Date Hired";
                worksheet.Cell(currentRow, 5).Value = "Tenure";
                worksheet.Cell(currentRow, 6).Value = "Date Completed";
                worksheet.Cell(currentRow, 7).Value = "Process Specific";
                worksheet.Cell(currentRow, 8).Value = "STAR & OSvC";
                worksheet.Cell(currentRow, 9).Value = "Process Specific";
                worksheet.Cell(currentRow, 10).Value = "STAR & OSvC";
                worksheet.Cell(currentRow, 11).Value = "Total Time Spent";
                worksheet.Cell(currentRow, 12).Value = "Process Specific";
                worksheet.Cell(currentRow, 13).Value = "STAR & OSvC";
                worksheet.Cell(currentRow, 14).Value = "Overall Average";
                worksheet.Cell(currentRow, 15).Value = "Certification Score";
                worksheet.Cell(currentRow, 16).Value = "Certification Level";
                worksheet.Cell(currentRow, 17).Value = "CSAT Score";
                worksheet.Cell(currentRow, 18).Value = "CSAT Level";
                worksheet.Cell(currentRow, 19).Value = "QC Score";
                worksheet.Cell(currentRow, 20).Value = "QC Level";
                worksheet.Cell(currentRow, 21).Value = "Overall Score";
                worksheet.Cell(currentRow, 22).Value = "Competency Level";
                worksheet.Cell(currentRow, 23).Value = "Tenure + Competency";
                worksheet.Cell(currentRow, 24).Value = "Matched/Unmatched";

                IXLRange range2_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                range2_1_6.Style.Font.Bold = true;
                range2_1_6.Style.Font.FontSize = 9;
                range2_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range2_1_6.Style.Fill.SetBackgroundColor(XLColor.Black);
                range2_1_6.Style.Font.SetFontColor(XLColor.White);

                IXLRange range2_7_16 = worksheet.Range(worksheet.Cell(currentRow, 7).Address, worksheet.Cell(currentRow, 16).Address);
                range2_7_16.Style.Font.Bold = true;
                range2_7_16.Style.Font.FontSize = 9;
                range2_7_16.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range2_7_16.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#f0bf60"));
                range2_7_16.Style.Font.SetFontColor(XLColor.Black);

                IXLRange range2_17_18 = worksheet.Range(worksheet.Cell(currentRow, 17).Address, worksheet.Cell(currentRow, 18).Address);
                range2_17_18.Style.Font.Bold = true;
                range2_17_18.Style.Font.FontSize = 9;
                range2_17_18.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range2_17_18.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#FF944D"));
                range2_17_18.Style.Font.SetFontColor(XLColor.Black);

                IXLRange range2_19_20 = worksheet.Range(worksheet.Cell(currentRow, 19).Address, worksheet.Cell(currentRow, 20).Address);
                range2_19_20.Style.Font.Bold = true;
                range2_19_20.Style.Font.FontSize = 9;
                range2_19_20.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range2_19_20.Style.Fill.SetBackgroundColor(XLColor.FromHtml("#2463E6"));
                range2_19_20.Style.Font.SetFontColor(XLColor.Black);

                IXLRange range2_21_24 = worksheet.Range(worksheet.Cell(currentRow, 21).Address, worksheet.Cell(currentRow, 24).Address);
                range2_21_24.Style.Font.Bold = true;
                range2_21_24.Style.Font.FontSize = 9;
                range2_21_24.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                range2_21_24.Style.Fill.SetBackgroundColor(XLColor.Black);
                range2_21_24.Style.Font.SetFontColor(XLColor.White);

                worksheet.Rows(currentRow, currentRow).Height = 25;

                IXLBorder border2_1_24 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 24).Address).Style.Border;
                border2_1_24.BottomBorder = border2_1_24.TopBorder = border2_1_24.LeftBorder = border2_1_24.RightBorder = XLBorderStyleValues.Thin;

                #endregion

                #region Body

                foreach (var skillMatrix in skillReport.SkillMatrix)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = currentRow - 2;
                    worksheet.Cell(currentRow, 2).Value = skillMatrix.Team;
                    worksheet.Cell(currentRow, 3).Value = skillMatrix.Name;
                    worksheet.Cell(currentRow, 4).Value = skillMatrix.DateHired;
                    worksheet.Cell(currentRow, 5).Value = $"{skillMatrix.TenureYears} years {skillMatrix.TenureMonths} months";
                    worksheet.Cell(currentRow, 6).Value = Convert.ToDateTime(skillMatrix.DateCompleted).Date.ToShortDateString();

                    worksheet.Cell(currentRow, 7).Value = $"{skillMatrix.ProcessSpecific_PR}%";
                    worksheet.Cell(currentRow, 7).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 7).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 8).Value = $"{skillMatrix.StarAndOSvC_PR}%";
                    worksheet.Cell(currentRow, 8).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 8).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 9).Value = skillMatrix.ProcessSpecific_TS;
                    worksheet.Cell(currentRow, 10).Value = skillMatrix.StarAndOSvC_TS;
                    worksheet.Cell(currentRow, 11).Value = skillMatrix.TotalTimeSpent;

                    worksheet.Cell(currentRow, 12).Value = $"{skillMatrix.ProcessSpecific_QSR}%";
                    worksheet.Cell(currentRow, 12).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 12).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 13).Value = $"{skillMatrix.StarAndOSvC_QSR}%";
                    worksheet.Cell(currentRow, 13).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 13).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 14).Value = $"{skillMatrix.AvgQuestionsStatisticsReport}%";
                    worksheet.Cell(currentRow, 14).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 14).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 15).Value = skillMatrix.CertificationScore;
                    worksheet.Cell(currentRow, 16).Value = skillMatrix.CertificationLevel;

                    worksheet.Cell(currentRow, 17).Value = (skillMatrix.CSATScore != 0) ? $"{skillMatrix.CSATScore}%" : string.Empty;
                    worksheet.Cell(currentRow, 17).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 17).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 18).Value = (skillMatrix.CSATScore != 0) ? $"{skillMatrix.CSATLevel}" : string.Empty;

                    worksheet.Cell(currentRow, 19).Value = (skillMatrix.QCScore != 0) ? $"{skillMatrix.QCScore}%" : string.Empty;
                    worksheet.Cell(currentRow, 19).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 19).DataType = XLDataType.Number;

                    worksheet.Cell(currentRow, 20).Value = (skillMatrix.QCScore != 0) ? $"{skillMatrix.QCLevel}" : string.Empty;
                    worksheet.Cell(currentRow, 21).Value = skillMatrix.OverallScore;
                    worksheet.Cell(currentRow, 22).Value = skillMatrix.CompetencyLevel;
                    worksheet.Cell(currentRow, 23).Value = skillMatrix.TenureLevel;
                    worksheet.Cell(currentRow, 24).Value = skillMatrix.TenurePlusCompetency;

                    IXLRange range1_24 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 24).Address);
                    range1_24.Style.Font.FontSize = 9;
                    IXLBorder border1_24 = range1_24.Style.Border;
                    border1_24.BottomBorder = border1_24.TopBorder = border1_24.LeftBorder = border1_24.RightBorder = XLBorderStyleValues.Thin;
                }

                worksheet.Columns().AdjustToContents();
                worksheet.SheetView.FreezeColumns(6);

                #endregion

                var fileName = $"SkillMatrix_{filter.Year}_Q{filter.Quarter}.xlsx";                
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName
                        );
                }
            }

            #endregion
        }

        #endregion

        #region QualityRating

        public IActionResult Quality()
        {
            var report = _reportService.GetQualityReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult Quality(QualityFilter filter)
        {
            var report = _reportService.GetQualityReport(filter);
            return PartialView("_QualityTable", report);
        }

        [HttpGet]
        public IActionResult QualityExcel(DateTime minDate, DateTime maxDate, string department, string reportType, int targetScore)
        {
            var filter = new QualityFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                Department = department,
                ReportType = reportType,
                TargetScore = targetScore
            };

            var qualityReport = _reportService.GetQualityReport(filter);

            #region Workbook

            if(filter.ReportType == ReportType.External.ToString() || filter.ReportType == ReportType.Internal.ToString())
            {
                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Summary";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;

                    #region Header

                    worksheet.Cell(currentRow, 1).Value = "Summary Table";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(currentRow, 1).Style.Font.SetFontColor(XLColor.DarkRed);

                    currentRow++;
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Date Range";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 1).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 2).Value = filter.StartDate;
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 3).Value = "to";
                    worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 3).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 3).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 4).Value = filter.EndDate;
                    worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "Checks by Customer Type and Request Reason";
                    IXLRange range5_1_3 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 3).Address);
                    range5_1_3.Merge();
                    range5_1_3.Style.Font.Bold = true;
                    range5_1_3.Style.Font.FontSize = 14;

                    currentRow++;

                    worksheet.Cell(currentRow, 2).Value = "Target Score";
                    worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 2).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 2).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 3).Value = targetScore;
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    #endregion

                    #region Body

                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "";
                    worksheet.Cell(currentRow, 2).Value = "Tickets Checked";
                    worksheet.Cell(currentRow, 3).Value = "Tickets Passed";
                    worksheet.Cell(currentRow, 4).Value = "Average SPI Score";
                    worksheet.Cell(currentRow, 5).Value = "Average SNCS Score";

                    IXLRange range7_1_5 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 5).Address);
                    range7_1_5.Style.Fill.SetBackgroundColor(XLColor.FromArgb(24,54,66));
                    range7_1_5.Style.Font.SetFontColor(XLColor.FromArgb(206, 219, 224));

                    foreach (var summary in qualityReport.QualitySummary)
                    {
                        currentRow++;

                        worksheet.Cell(currentRow, 1).Value = summary.Category;

                        worksheet.Cell(currentRow, 2).Value = summary.TicketsChecked;
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 3).Value = $"{summary.TicketsPassed}%";
                        worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 3).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 4).Value = $"{summary.AvgSPIScore}%";
                        worksheet.Cell(currentRow, 4).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 4).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 5).Value = $"{summary.AvgSNCSScore}%";
                        worksheet.Cell(currentRow, 5).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 5).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        if (summary.Category == ReportType.Internal.ToString() || summary.Category == ReportType.External.ToString())
                        {
                            IXLRange range1_5 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 5).Address);
                            range1_5.Style.Fill.SetBackgroundColor(XLColor.FromArgb(206, 219, 224));
                            range1_5.Style.Font.Bold = true;

                            IXLBorder border1_5 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 5).Address).Style.Border;
                            border1_5.BottomBorder = XLBorderStyleValues.Thin;
                        }
                    }
                    worksheet.Columns().AdjustToContents();

                    #endregion

                    var fileName = $"QualitySummary_{filter.Department}_{filter.ReportType}.xlsx";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(
                            content,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            fileName
                            );
                    }
                }
            }
            else
            {
                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Summary";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;

                    #region Header

                    worksheet.Cell(currentRow, 1).Value = "Summary Table";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(currentRow, 1).Style.Font.SetFontColor(XLColor.DarkRed);

                    currentRow++;
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = "Date Range";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 1).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 2).Value = filter.StartDate;
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 3).Value = "to";
                    worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 3).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 3).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 4).Value = filter.EndDate;
                    worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "Checks by Ticket Status";
                    IXLRange range5_1_3 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 3).Address);
                    range5_1_3.Merge();
                    range5_1_3.Style.Font.Bold = true;
                    range5_1_3.Style.Font.FontSize = 14;

                    currentRow++;

                    worksheet.Cell(currentRow, 2).Value = "Target Score";
                    worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 2).Style.Font.FontSize = 11;
                    worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.FromArgb(60, 156, 215));
                    worksheet.Cell(currentRow, 2).Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Cell(currentRow, 3).Value = targetScore;
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    #endregion

                    #region Body
                    currentRow++;

                    var colName = string.Empty;
                    if(filter.ReportType == ReportType.TicketStatus.ToString())
                    {
                        colName = "Ticket Status";
                    }
                    else
                    {
                        colName = "Team Location";
                    }
                    worksheet.Cell(currentRow, 1).Value = colName;
                    worksheet.Cell(currentRow, 2).Value = "Tickets Checked";
                    worksheet.Cell(currentRow, 3).Value = "Tickets Passed";
                    worksheet.Cell(currentRow, 4).Value = "Average SPI Score";
                    worksheet.Cell(currentRow, 5).Value = "Average SNCS Score";

                    IXLRange range7_1_5 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 5).Address);
                    range7_1_5.Style.Fill.SetBackgroundColor(XLColor.FromArgb(24, 54, 66));
                    range7_1_5.Style.Font.SetFontColor(XLColor.FromArgb(206, 219, 224));

                    foreach (var summary in qualityReport.QualitySummary)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = summary.Category;
                        worksheet.Cell(currentRow, 2).Value = summary.TicketsChecked;
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 3).Value = $"{summary.TicketsPassed}%";
                        worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 3).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 4).Value = $"{summary.AvgSPIScore}%";
                        worksheet.Cell(currentRow, 4).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 4).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 5).Value = $"{summary.AvgSNCSScore}%";
                        worksheet.Cell(currentRow, 5).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 5).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    }

                    worksheet.Columns().AdjustToContents();                   

                    #endregion

                    var fileName = $"QualitySummary_{filter.Department}_{filter.ReportType}.xlsx";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(
                            content,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            fileName
                            );
                    }
                }
            }
            
            #endregion
        }

        #endregion
    }
}
