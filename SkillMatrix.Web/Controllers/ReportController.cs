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

        #region SKILL MATRIX
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

        #region QUALITY RATING

        public IActionResult Quality()
        {
            var report = _reportService.GetQualityReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult Quality(QualityFilter filter)
        {
            vwQualityReport report = new vwQualityReport();
            if(filter.AccountType == AccountType.Elsevier.ToString())
            {
                if(filter.ReportType == QCReportType3.AgentSummary.ToString())
                {
                    report = _reportService.GetQualityReport3(filter);
                    return PartialView("_QualityTable5", report);
                }
                else
                {
                    report = _reportService.GetQualityReport3(filter);
                    return PartialView("_QualityTable4", report);
                }                
            }
            if(filter.Department == Department.CompCopy.ToString() || filter.Department == Department.OrderManagement.ToString())
            {
                if (filter.ReportType == QCReportType2.WeeklyLevelSummary.ToString())
                {
                    report = _reportService.GetQualityReport2(filter);
                    return PartialView("_QualityTable2", report);
                }
                else
                {
                    report = _reportService.GetQualityReport2(filter);
                    return PartialView("_QualityTable3", report);
                }
            }
            else
            {
                report = _reportService.GetQualityReport(filter);
                return PartialView("_QualityTable", report);
            }            
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

            if(filter.ReportType == QCReportType1.External.ToString() || filter.ReportType == QCReportType1.Internal.ToString())
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

                        if (summary.Category == QCReportType1.Internal.ToString() || summary.Category == QCReportType1.External.ToString())
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
                    if(filter.ReportType == QCReportType1.TicketStatus.ToString())
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

        [HttpGet]
        public IActionResult QualityExcel2(DateTime minDate, DateTime maxDate, string department, string reportType)
        {
            var filter = new QualityFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                Department = department,
                ReportType = reportType
            };

            var qualityReport = _reportService.GetQualityReport2(filter);

            #region Workbook

            using (var workbook = new XLWorkbook())
            {
                var tab = $"Summary";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Calibri");
                var currentRow = 1;

                #region Header

                int counter = 1;
                if (qualityReport.WeeklyQualityReport.Count > 0)
                {                    
                    worksheet.Cell(currentRow, counter).Value = "#";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "Agent Name";
                    counter++;
                    foreach (var weeklyAccuracy in qualityReport.WeeklyQualityReport[0].WeeklyAccuracy)
                    {
                        worksheet.Cell(currentRow, counter).Value = weeklyAccuracy.Week;
                        counter++;
                    }
                    worksheet.Cell(currentRow, counter).Value = "Avg MTD";

                    IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address);
                    range1_1_n.Style.Font.Bold = true;
                    range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(255, 102, 0));
                    range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range1_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    range1_1_n.Style.Font.FontSize = 11;

                    IXLBorder border_1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_1_1_n.BottomBorder = border_1_1_n.TopBorder = border_1_1_n.LeftBorder = border_1_1_n.RightBorder = XLBorderStyleValues.Thin;
                }                

                #endregion

                #region Body

                currentRow++;

                foreach (var weeklyReport in qualityReport.WeeklyQualityReport)
                {
                    counter = 1;
                    worksheet.Cell(currentRow, counter).Value = currentRow-1;
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = weeklyReport.AgentName;
                    counter++;

                    foreach (var accuracy in weeklyReport.WeeklyAccuracy)
                    {
                        if(accuracy.AccuracyRate>0)
                        {
                            worksheet.Cell(currentRow, counter).Value = $"{accuracy.AccuracyRate}%";
                        }                        
                        worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        counter++;
                    }

                    if (weeklyReport.AverageMTD > 0)
                    {
                        worksheet.Cell(currentRow, counter).Value = $"{weeklyReport.AverageMTD}%";
                    }                    
                    worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLBorder border_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_1_n.BottomBorder = border_1_n.TopBorder = border_1_n.LeftBorder = border_1_n.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;
                }

                if (qualityReport.WeeklyQualityReport.Count > 0)
                {
                    counter = 1;
                    worksheet.Cell(currentRow, counter).Value = "";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "Avg MTD";
                    counter++;
                    foreach (var weeklyAccuracy in qualityReport.WeeklyQualityReport[0].WeeklyAccuracy)
                    {
                        worksheet.Cell(currentRow, counter).Value = $"{weeklyAccuracy.AverageMTD}%";
                        worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        counter++;
                    }
                    worksheet.Cell(currentRow, counter).Value = $"{qualityReport.WeeklyQualityReport[0].AvgOfAvgMTD}%";
                    worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address);
                    range_n_1_n.Style.Font.Bold = true;
                    range_n_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(255, 102, 0));
                    range_n_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range_n_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    range_n_1_n.Style.Font.FontSize = 11;

                    IXLBorder border_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;
                }

                worksheet.Columns().AdjustToContents();

                #endregion

                var fileName = $"WeeklyLevelSummary_{filter.Department}_{filter.ReportType}.xlsx";
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

        [HttpGet]
        public IActionResult QualityExcel3(DateTime minDate, DateTime maxDate, string department, string reportType)
        {
            var filter = new QualityFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                Department = department,
                ReportType = reportType
            };

            var qualityReport = _reportService.GetQualityReport2(filter);

            #region Workbook

            using (var workbook = new XLWorkbook())
            {
                var tab = $"Summary";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Calibri");
                var currentRow = 1;

                #region Header

                int counter = 1;
                if (qualityReport.DailyQualityReport.Count > 0)
                {
                    worksheet.Cell(currentRow, counter).Value = "#";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "Team Lead";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "Agent Name";
                    counter++;
                    foreach (var dailySample in qualityReport.DailyQualityReport[0].DailySampling)
                    {
                        worksheet.Cell(currentRow, counter).Value = dailySample.Date.ToString("dd-MMM-yy");
                        worksheet.Cell(currentRow, counter).Style.DateFormat.Format = "dd-MMM-yy";
                        worksheet.Cell(currentRow, counter).DataType = XLDataType.DateTime;
                        counter++;
                    }
                    worksheet.Cell(currentRow, counter).Value = "Grand Total";

                    IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address);
                    range1_1_n.Style.Font.Bold = true;
                    range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(255, 102, 0));
                    range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range1_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    range1_1_n.Style.Font.FontSize = 11;

                    IXLBorder border_1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_1_1_n.BottomBorder = border_1_1_n.TopBorder = border_1_1_n.LeftBorder = border_1_1_n.RightBorder = XLBorderStyleValues.Thin;
                }

                #endregion

                #region Body

                currentRow++;

                foreach (var dailyReport in qualityReport.DailyQualityReport)
                {
                    counter = 1;
                    worksheet.Cell(currentRow, counter).Value = currentRow - 1;
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = dailyReport.TeamLead;
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = dailyReport.AgentName;
                    counter++;

                    foreach (var sample in dailyReport.DailySampling)
                    {
                        if (sample.SamplePercentage > 0)
                        {
                            worksheet.Cell(currentRow, counter).Value = $"{sample.SamplePercentage}%";
                            worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;                            
                        }
                        worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        counter++;
                    }

                    if (dailyReport.AvgSampling > 0)
                    {
                        worksheet.Cell(currentRow, counter).Value = $"{dailyReport.AvgSampling}%";
                    }
                    worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLBorder border_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_1_n.BottomBorder = border_1_n.TopBorder = border_1_n.LeftBorder = border_1_n.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;
                }

                if (qualityReport.DailyQualityReport.Count > 0)
                {
                    counter = 1;
                    worksheet.Cell(currentRow, counter).Value = "";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "Grand Total";
                    counter++;
                    worksheet.Cell(currentRow, counter).Value = "";
                    counter++;                    
                    foreach (var dailySample in qualityReport.DailyQualityReport[0].DailySampling)
                    {
                        if(dailySample.AvgSamplePercentage>0)
                        {
                            worksheet.Cell(currentRow, counter).Value = $"{dailySample.AvgSamplePercentage}%";
                            worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                        }                        
                        worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        counter++;
                    }
                    if(qualityReport.DailyQualityReport[0].AvgOfAvgSampling>0)
                    {
                        worksheet.Cell(currentRow, counter).Value = $"{qualityReport.DailyQualityReport[0].AvgOfAvgSampling}%";
                        worksheet.Cell(currentRow, counter).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, counter).DataType = XLDataType.Number;
                    }                    
                    worksheet.Cell(currentRow, counter).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address);
                    range_n_1_n.Style.Font.Bold = true;
                    range_n_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(255, 102, 0));
                    range_n_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range_n_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    range_n_1_n.Style.Font.FontSize = 11;

                    IXLBorder border_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, counter).Address).Style.Border;
                    border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;
                }

                if(qualityReport.DailyQualityReport.Count>0)
                {
                    if(string.IsNullOrEmpty(qualityReport.DailyQualityReport[0].AgentName))
                    {
                        worksheet.Column(3).Hide();
                    }
                }
                worksheet.Columns().AdjustToContents();

                #endregion

                var fileName = $"DailySamplingPercentage_{filter.Department}_{filter.ReportType}.xlsx";
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

        public IActionResult QualityExcel4(DateTime minDate, DateTime maxDate, string reportType)
        {
            var filter = new QualityFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                ReportType = reportType
            };

            var qualityReport = _reportService.GetQualityReport3(filter);

            #region Workbook

            using (var workbook = new XLWorkbook())
            {
                var tab = $"Summary";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Calibri");
                var currentRow = 1;

                #region Header

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;

                if(reportType == QCReportType3.CategorySummary.ToString())
                {
                    worksheet.Cell(currentRow, 2).Value = "Category";
                }
                else
                {
                    worksheet.Cell(currentRow, 2).Value = "Code";
                }
                
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 3).Value = "Details";
                worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 3).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 4).Value = "Defination";
                worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 4).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 5).Value = "Points Earned";
                worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 5).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 6).Value = "Total Points";
                worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 6).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 7).Value = "Percentage";
                worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 7).Style.Font.FontSize = 12;

                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
                worksheet.Cell(currentRow, 1).Style.Font.SetFontColor(XLColor.DarkRed);

                IXLRange range1_7 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 7).Address);
                range1_7.Style.Fill.SetBackgroundColor(XLColor.FromArgb(64, 64, 64));
                range1_7.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                IXLBorder border_1 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 5).Address).Style.Border;
                border_1.BottomBorder = border_1.TopBorder = border_1.LeftBorder = border_1.RightBorder = XLBorderStyleValues.Thin;

                #endregion

                #region Body

                currentRow++;

                foreach (var summary in qualityReport.CategorySummaryELSV)
                {
                    if(summary.Category.ToLower() != "total")
                    {
                        worksheet.Cell(currentRow, 1).Value = currentRow - 1;
                        worksheet.Cell(currentRow, 2).Value = summary.Category;
                        worksheet.Cell(currentRow, 3).Value = summary.Details;
                        worksheet.Cell(currentRow, 4).Value = summary.Defination;
                        worksheet.Cell(currentRow, 5).Value = summary.PointsEarned;
                        worksheet.Cell(currentRow, 6).Value = summary.TotalPoints;
                        worksheet.Cell(currentRow, 7).Value = $"{summary.ScorePercentage}%";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 2).Value = summary.Category;
                        worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 3).Value = summary.Details;
                        worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 4).Value = summary.Defination;
                        worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 5).Value = summary.PointsEarned;
                        worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 6).Value = summary.TotalPoints;
                        worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 7).Value = $"{summary.ScorePercentage}%";
                        worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
                    }

                    worksheet.Cell(currentRow, 7).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 7).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLBorder border_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 7).Address).Style.Border;
                    border_1_n.BottomBorder = border_1_n.TopBorder = border_1_n.LeftBorder = border_1_n.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;
                }

                if(reportType == QCReportType3.CategorySummary.ToString())
                {
                    worksheet.Column(3).Hide();
                    worksheet.Column(4).Hide();
                }

                worksheet.Column(1).AdjustToContents();
                worksheet.Column(2).AdjustToContents();
                worksheet.Column(5).AdjustToContents();
                worksheet.Column(6).AdjustToContents();
                worksheet.Column(7).AdjustToContents();

                #endregion

                var fileName = $"QualitySummary_{filter.ReportType}.xlsx";
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

        public IActionResult QualityExcel5(DateTime minDate, DateTime maxDate, string reportType, int passingScore)
        {
            var filter = new QualityFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                ReportType = reportType,
                PassingScore = passingScore
            };

            var qualityReport = _reportService.GetQualityReport3(filter);

            #region Workbook

            using (var workbook = new XLWorkbook())
            {
                var tab = $"Summary";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Calibri");
                var currentRow = 1;

                #region Header

                worksheet.Cell(currentRow, 7).Value = "CF1";
                worksheet.Cell(currentRow, 10).Value = "CF2";
                worksheet.Cell(currentRow, 13).Value = "CF3";
                worksheet.Cell(currentRow, 16).Value = "CF4";
                worksheet.Cell(currentRow, 19).Value = "Customer Focus";
                worksheet.Cell(currentRow, 21).Value = "SF1";
                worksheet.Cell(currentRow, 24).Value = "SF2";
                worksheet.Cell(currentRow, 27).Value = "SF3";
                worksheet.Cell(currentRow, 30).Value = "System Focus";
                worksheet.Cell(currentRow, 32).Value = "BP1";
                worksheet.Cell(currentRow, 35).Value = "BP2";
                worksheet.Cell(currentRow, 38).Value = "BP3";
                worksheet.Cell(currentRow, 41).Value = "Business Focus";
                worksheet.Cell(currentRow, 43).Value = "IC11";
                worksheet.Cell(currentRow, 46).Value = "IC2";
                worksheet.Cell(currentRow, 49).Value = "IC3";
                worksheet.Cell(currentRow, 52).Value = "IC4";
                worksheet.Cell(currentRow, 55).Value = "Intuitive Customer";

                IXLRange range1_7_9 = worksheet.Range(worksheet.Cell(currentRow, 7).Address, worksheet.Cell(currentRow, 9).Address);
                range1_7_9.Merge();
                range1_7_9.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_10_12 = worksheet.Range(worksheet.Cell(currentRow, 10).Address, worksheet.Cell(currentRow, 12).Address);
                range1_10_12.Merge();
                range1_10_12.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_13_15 = worksheet.Range(worksheet.Cell(currentRow, 13).Address, worksheet.Cell(currentRow, 15).Address);
                range1_13_15.Merge();
                range1_13_15.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_16_18 = worksheet.Range(worksheet.Cell(currentRow, 16).Address, worksheet.Cell(currentRow, 18).Address);
                range1_16_18.Merge();
                range1_16_18.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_19_20 = worksheet.Range(worksheet.Cell(currentRow, 19).Address, worksheet.Cell(currentRow, 20).Address);
                range1_19_20.Merge();
                range1_19_20.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_21_23 = worksheet.Range(worksheet.Cell(currentRow, 21).Address, worksheet.Cell(currentRow, 23).Address);
                range1_21_23.Merge();
                range1_21_23.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_24_26 = worksheet.Range(worksheet.Cell(currentRow, 24).Address, worksheet.Cell(currentRow, 26).Address);
                range1_24_26.Merge();
                range1_24_26.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_27_29 = worksheet.Range(worksheet.Cell(currentRow, 27).Address, worksheet.Cell(currentRow, 29).Address);
                range1_27_29.Merge();
                range1_27_29.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_30_31 = worksheet.Range(worksheet.Cell(currentRow, 30).Address, worksheet.Cell(currentRow, 31).Address);
                range1_30_31.Merge();
                range1_30_31.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_32_34 = worksheet.Range(worksheet.Cell(currentRow, 32).Address, worksheet.Cell(currentRow, 34).Address);
                range1_32_34.Merge();
                range1_32_34.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_35_37 = worksheet.Range(worksheet.Cell(currentRow, 35).Address, worksheet.Cell(currentRow, 37).Address);
                range1_35_37.Merge();
                range1_35_37.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_38_40 = worksheet.Range(worksheet.Cell(currentRow, 38).Address, worksheet.Cell(currentRow, 40).Address);
                range1_38_40.Merge();
                range1_38_40.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_41_42 = worksheet.Range(worksheet.Cell(currentRow, 41).Address, worksheet.Cell(currentRow, 42).Address);
                range1_41_42.Merge();
                range1_41_42.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1_43_45 = worksheet.Range(worksheet.Cell(currentRow, 43).Address, worksheet.Cell(currentRow, 45).Address);
                range1_43_45.Merge();
                range1_43_45.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_46_48 = worksheet.Range(worksheet.Cell(currentRow, 46).Address, worksheet.Cell(currentRow, 48).Address);
                range1_46_48.Merge();
                range1_46_48.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_49_51 = worksheet.Range(worksheet.Cell(currentRow, 49).Address, worksheet.Cell(currentRow, 51).Address);
                range1_49_51.Merge();
                range1_49_51.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_52_54 = worksheet.Range(worksheet.Cell(currentRow, 52).Address, worksheet.Cell(currentRow, 54).Address);
                range1_52_54.Merge();
                range1_52_54.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                IXLRange range1_55_56 = worksheet.Range(worksheet.Cell(currentRow, 55).Address, worksheet.Cell(currentRow, 56).Address);
                range1_55_56.Merge();
                range1_55_56.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                IXLRange range1 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 66).Address);
                range1.Style.Fill.SetBackgroundColor(XLColor.FromArgb(146, 208, 80));
                range1.Style.Font.SetFontColor(XLColor.FromArgb(0, 0, 0));
                range1.Style.Font.Bold = true;

                IXLBorder border_1 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 66).Address).Style.Border;
                border_1.BottomBorder = border_1.TopBorder = border_1.LeftBorder = border_1.RightBorder = XLBorderStyleValues.Thin;

                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 2).Value = "Month";                
                worksheet.Cell(currentRow, 3).Value = "Year";                
                worksheet.Cell(currentRow, 4).Value = "TL";
                worksheet.Cell(currentRow, 5).Value = "Agent";
                worksheet.Cell(currentRow, 6).Value = "Employee ID";
                worksheet.Cell(currentRow, 7).Value = "PointsEarned";
                worksheet.Cell(currentRow, 8).Value = "TotalPoints";
                worksheet.Cell(currentRow, 9).Value = "%";
                worksheet.Cell(currentRow, 10).Value = "PointsEarned";
                worksheet.Cell(currentRow, 11).Value = "TotalPoints";
                worksheet.Cell(currentRow, 12).Value = "%";
                worksheet.Cell(currentRow, 13).Value = "PointsEarned";
                worksheet.Cell(currentRow, 14).Value = "TotalPoints";
                worksheet.Cell(currentRow, 15).Value = "%";
                worksheet.Cell(currentRow, 16).Value = "PointsEarned";
                worksheet.Cell(currentRow, 17).Value = "TotalPoints";
                worksheet.Cell(currentRow, 18).Value = "%";
                worksheet.Cell(currentRow, 19).Value = "PointsEarned";
                worksheet.Cell(currentRow, 20).Value = "TotalPoints";

                worksheet.Cell(currentRow, 21).Value = "PointsEarned";
                worksheet.Cell(currentRow, 22).Value = "TotalPoints";
                worksheet.Cell(currentRow, 23).Value = "%";
                worksheet.Cell(currentRow, 24).Value = "PointsEarned";
                worksheet.Cell(currentRow, 25).Value = "TotalPoints";
                worksheet.Cell(currentRow, 26).Value = "%";
                worksheet.Cell(currentRow, 27).Value = "PointsEarned";
                worksheet.Cell(currentRow, 28).Value = "TotalPoints";
                worksheet.Cell(currentRow, 29).Value = "%";                
                worksheet.Cell(currentRow, 30).Value = "PointsEarned";
                worksheet.Cell(currentRow, 31).Value = "TotalPoints";

                worksheet.Cell(currentRow, 32).Value = "PointsEarned";
                worksheet.Cell(currentRow, 33).Value = "TotalPoints";
                worksheet.Cell(currentRow, 34).Value = "%";
                worksheet.Cell(currentRow, 35).Value = "PointsEarned";
                worksheet.Cell(currentRow, 36).Value = "TotalPoints";
                worksheet.Cell(currentRow, 37).Value = "%";
                worksheet.Cell(currentRow, 38).Value = "PointsEarned";
                worksheet.Cell(currentRow, 39).Value = "TotalPoints";
                worksheet.Cell(currentRow, 40).Value = "%";
                worksheet.Cell(currentRow, 41).Value = "PointsEarned";
                worksheet.Cell(currentRow, 42).Value = "TotalPoints";

                worksheet.Cell(currentRow, 43).Value = "PointsEarned";
                worksheet.Cell(currentRow, 44).Value = "TotalPoints";
                worksheet.Cell(currentRow, 45).Value = "%";
                worksheet.Cell(currentRow, 46).Value = "PointsEarned";
                worksheet.Cell(currentRow, 47).Value = "TotalPoints";
                worksheet.Cell(currentRow, 48).Value = "%";
                worksheet.Cell(currentRow, 49).Value = "PointsEarned";
                worksheet.Cell(currentRow, 50).Value = "TotalPoints";
                worksheet.Cell(currentRow, 51).Value = "%";
                worksheet.Cell(currentRow, 52).Value = "PointsEarned";
                worksheet.Cell(currentRow, 53).Value = "TotalPoints";
                worksheet.Cell(currentRow, 54).Value = "%";
                worksheet.Cell(currentRow, 55).Value = "PointsEarned";
                worksheet.Cell(currentRow, 56).Value = "TotalPoints";

                worksheet.Cell(currentRow, 57).Value = "Overall Points";
                worksheet.Cell(currentRow, 58).Value = "Overall";
                worksheet.Cell(currentRow, 59).Value = "Overall QC Score";

                worksheet.Cell(currentRow, 60).Value = "Passed/Failed";
                worksheet.Cell(currentRow, 61).Value = "Passive Survey";
                worksheet.Cell(currentRow, 62).Value = "Individial CSAT";
                worksheet.Cell(currentRow, 63).Value = "No. Of People";
                worksheet.Cell(currentRow, 64).Value = "Flexible QC Type";
                worksheet.Cell(currentRow, 65).Value = "No. Of Samples";
                worksheet.Cell(currentRow, 66).Value = "Remarks";

                IXLRange range1_66 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 66).Address);
                range1_66.Style.Fill.SetBackgroundColor(XLColor.FromArgb(146, 208, 80));
                range1_66.Style.Font.SetFontColor(XLColor.FromArgb(0, 0, 0));
                range1_66.Style.Font.Bold = true;

                IXLBorder border_1_66 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 66).Address).Style.Border;
                border_1_66.BottomBorder = border_1_66.TopBorder = border_1_66.LeftBorder = border_1_66.RightBorder = XLBorderStyleValues.Thin;

                #endregion

                #region Body

                currentRow++;

                foreach (var summary in qualityReport.AgentSummaryELSV)
                {
                    worksheet.Cell(currentRow, 1).Value = currentRow - 2;
                    worksheet.Cell(currentRow, 2).Value = summary.Month;
                    worksheet.Cell(currentRow, 3).Value = summary.Year;
                    worksheet.Cell(currentRow, 4).Value = summary.TeamLead;
                    worksheet.Cell(currentRow, 5).Value = summary.AgentName;
                    worksheet.Cell(currentRow, 6).Value = summary.EmployeeId;

                    worksheet.Cell(currentRow, 7).Value = summary.CF1_PointsEarned;
                    worksheet.Cell(currentRow, 8).Value = summary.CF1_TotalPoints;
                    worksheet.Cell(currentRow, 9).Value = $"{summary.CF1_Percent}%";
                    worksheet.Cell(currentRow, 9).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 9).Style.NumberFormat.Format = "0.00%";
                    
                    worksheet.Cell(currentRow, 10).Value = summary.CF2_PointsEarned;
                    worksheet.Cell(currentRow, 11).Value = summary.CF2_TotalPoints;
                    worksheet.Cell(currentRow, 12).Value = $"{summary.CF2_Percent}%";
                    worksheet.Cell(currentRow, 12).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 12).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 13).Value = summary.CF3_PointsEarned;
                    worksheet.Cell(currentRow, 14).Value = summary.CF3_TotalPoints;
                    worksheet.Cell(currentRow, 15).Value = $"{summary.CF3_Percent}%";
                    worksheet.Cell(currentRow, 15).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 15).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 16).Value = summary.CF4_PointsEarned;
                    worksheet.Cell(currentRow, 17).Value = summary.CF4_TotalPoints;
                    worksheet.Cell(currentRow, 18).Value = $"{summary.CF4_Percent}%";
                    worksheet.Cell(currentRow, 18).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 18).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 19).Value = summary.CF_PointsEarned;
                    worksheet.Cell(currentRow, 20).Value = summary.CF_TotalPoints;

                    worksheet.Cell(currentRow, 21).Value = summary.SF1_PointsEarned;
                    worksheet.Cell(currentRow, 22).Value = summary.SF1_TotalPoints;
                    worksheet.Cell(currentRow, 23).Value = $"{summary.SF1_Percent}%";
                    worksheet.Cell(currentRow, 23).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 23).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 24).Value = summary.SF2_PointsEarned;
                    worksheet.Cell(currentRow, 25).Value = summary.SF2_TotalPoints;
                    worksheet.Cell(currentRow, 26).Value = $"{summary.SF2_Percent}%";
                    worksheet.Cell(currentRow, 26).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 26).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 27).Value = summary.SF3_PointsEarned;
                    worksheet.Cell(currentRow, 28).Value = summary.SF3_TotalPoints;
                    worksheet.Cell(currentRow, 29).Value = $"{summary.SF3_Percent}%";
                    worksheet.Cell(currentRow, 29).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 29).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 30).Value = summary.SF_PointsEarned;
                    worksheet.Cell(currentRow, 31).Value = summary.SF_TotalPoints;

                    worksheet.Cell(currentRow, 32).Value = summary.BP1_PointsEarned;
                    worksheet.Cell(currentRow, 33).Value = summary.BP1_TotalPoints;
                    worksheet.Cell(currentRow, 34).Value = $"{summary.BP1_Percent}%";
                    worksheet.Cell(currentRow, 34).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 34).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 35).Value = summary.BP2_PointsEarned;
                    worksheet.Cell(currentRow, 36).Value = summary.BP2_TotalPoints;
                    worksheet.Cell(currentRow, 37).Value = $"{summary.BP2_Percent}%";
                    worksheet.Cell(currentRow, 37).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 37).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 38).Value = summary.BP3_PointsEarned;
                    worksheet.Cell(currentRow, 39).Value = summary.BP3_TotalPoints;
                    worksheet.Cell(currentRow, 40).Value = $"{summary.BP3_Percent}%";
                    worksheet.Cell(currentRow, 40).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 40).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 41).Value = summary.BP_PointsEarned;
                    worksheet.Cell(currentRow, 42).Value = summary.BP_TotalPoints;

                    worksheet.Cell(currentRow, 43).Value = summary.IC1_PointsEarned;
                    worksheet.Cell(currentRow, 44).Value = summary.IC1_TotalPoints;
                    worksheet.Cell(currentRow, 45).Value = $"{summary.IC1_Percent}%";
                    worksheet.Cell(currentRow, 45).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 45).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 46).Value = summary.IC2_PointsEarned;
                    worksheet.Cell(currentRow, 47).Value = summary.IC2_TotalPoints;
                    worksheet.Cell(currentRow, 48).Value = $"{summary.IC2_Percent}%";
                    worksheet.Cell(currentRow, 48).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 48).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 49).Value = summary.IC3_PointsEarned;
                    worksheet.Cell(currentRow, 50).Value = summary.IC3_TotalPoints;
                    worksheet.Cell(currentRow, 51).Value = $"{summary.IC3_Percent}%";
                    worksheet.Cell(currentRow, 51).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 51).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 52).Value = summary.IC4_PointsEarned;
                    worksheet.Cell(currentRow, 53).Value = summary.IC4_TotalPoints;
                    worksheet.Cell(currentRow, 54).Value = $"{summary.IC4_Percent}%";
                    worksheet.Cell(currentRow, 54).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 54).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 55).Value = summary.IC_PointsEarned;
                    worksheet.Cell(currentRow, 56).Value = summary.IC_TotalPoints;

                    worksheet.Cell(currentRow, 57).Value = summary.Overall_PointsEarned;
                    worksheet.Cell(currentRow, 58).Value = summary.Overall_TotalPoints;
                    worksheet.Cell(currentRow, 59).Value = $"{summary.Overall_QCScore}%";
                    worksheet.Cell(currentRow, 59).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 59).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 60).Value = summary.PassedOrFailed;
                    worksheet.Cell(currentRow, 61).Value = $"{summary.PassiveSurvey}%";
                    worksheet.Cell(currentRow, 61).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 61).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 62).Value = $"{summary.CSATScore}%";
                    worksheet.Cell(currentRow, 62).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 62).Style.NumberFormat.Format = "0.00%";

                    worksheet.Cell(currentRow, 63).Value = summary.NoOfPplOpportunity;
                    worksheet.Cell(currentRow, 64).Value = summary.QCType;
                    worksheet.Cell(currentRow, 65).Value = summary.NoOfSamples;
                    worksheet.Cell(currentRow, 66).Value = summary.Remarks;



                    //worksheet.Cell(currentRow, 7).Style.NumberFormat.Format = "0.00%";
                    //worksheet.Cell(currentRow, 7).DataType = XLDataType.Number;
                    //worksheet.Cell(currentRow, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLBorder border_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 66).Address).Style.Border;
                    border_1_n.BottomBorder = border_1_n.TopBorder = border_1_n.LeftBorder = border_1_n.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;
                }

                worksheet.Columns().AdjustToContents();                

                #endregion

                var fileName = $"QualitySummary_{filter.ReportType}.xlsx";
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

        #region TICKETING TOOL

        public IActionResult TicketingTool()
        {
            var report = _reportService.GetTicketingToolReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult TicketingTool(TicketingToolFilter filter)
        {
            vwTicketingToolReport report = new vwTicketingToolReport();
            report = _reportService.GetTicketingToolReport(filter);
            if(filter.ReportType == ReportType.Weekly.ToString())
            {
                return PartialView("_TicketingToolTableWeekly", report);
            }
            else if(filter.ReportType == ReportType.Daily.ToString())
            {
                return PartialView("_TicketingToolTableDaily", report);
            }
            else
            {
                return PartialView("_TicketingToolTableMonthly", report);
            }            
        }

        [HttpGet]
        public IActionResult TicketingToolExcel(DateTime minDate, DateTime maxDate, string reportType)
        {
            var filter = new TicketingToolFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                ReportType = reportType
            };

            var ticketingToolReport = _reportService.GetTicketingToolReport(filter);

            if (filter.ReportType == ReportType.Daily.ToString())
            {
                #region Daily Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Daily Status";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;

                    //worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                    //IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    //range0_1_6.Merge();
                    //range0_1_6.Style.Font.Bold = true;
                    //range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    //range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    //range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    if (ticketingToolReport.TicketingStatusReport.Count > 0)
                    {
                        #region Body

                        worksheet.Cell(currentRow, 1).Value = "Sr.No";
                        worksheet.Cell(currentRow, 2).Value = "Engagement";
                        int headerCounter = 3;
                        foreach (var header in ticketingToolReport.TicketingStatusReport[0].TicketingStatusReportDaily)
                        {
                            worksheet.Cell(currentRow, headerCounter).Value = header.Description;
                            headerCounter++;
                        }
                        worksheet.Cell(currentRow, headerCounter).Value = "Average Accuracy";

                        IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, headerCounter).Address);
                        range1_1_n.Style.Font.Bold = true;
                        range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_1_n = range1_1_n.Style.Border;
                        border1_1_n.BottomBorder = border1_1_n.TopBorder = border1_1_n.LeftBorder = border1_1_n.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;

                        foreach (var statusReport in ticketingToolReport.TicketingStatusReport)
                        {
                            worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                            worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            int dailyHeaderCtr = 3;
                            foreach (var dailyData in statusReport.TicketingStatusReportDaily)
                            {
                                if(dailyData.AccuracyRate>0)
                                {
                                    worksheet.Cell(currentRow, dailyHeaderCtr).Value = $"{dailyData.AccuracyRate}%";
                                }                                
                                worksheet.Cell(currentRow, dailyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                                worksheet.Cell(currentRow, dailyHeaderCtr).DataType = XLDataType.Number;
                                worksheet.Cell(currentRow, dailyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                dailyHeaderCtr++;
                            }

                            worksheet.Cell(currentRow, dailyHeaderCtr).Value = $"{statusReport.AccuracyRate}%";
                            worksheet.Cell(currentRow, dailyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, dailyHeaderCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, dailyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, dailyHeaderCtr).Address);
                            range_n_1_n.Style.Font.FontSize = 9;
                            IXLBorder border_n_1_n = range_n_1_n.Style.Border;
                            border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;

                            currentRow++;
                        }

                        worksheet.Cell(currentRow, 1).Value = "";

                        worksheet.Cell(currentRow, 2).Value = "Total";
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        int dailyTotalCtr = 3;
                        foreach (var dailyReport in ticketingToolReport.TicketingStatusReport[0].TicketingStatusReportDaily)
                        {
                            if(dailyReport.AvgAccuracyRate>0)
                            {
                                worksheet.Cell(currentRow, dailyTotalCtr).Value = $"{dailyReport.AvgAccuracyRate}%";
                            }                            
                            worksheet.Cell(currentRow, dailyTotalCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, dailyTotalCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, dailyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            dailyTotalCtr++;
                        }

                        worksheet.Cell(currentRow, dailyTotalCtr).Value = $"{ticketingToolReport.TicketingStatusReport[0].AvgAccuracyRate}%";
                        worksheet.Cell(currentRow, dailyTotalCtr).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, dailyTotalCtr).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, dailyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, dailyTotalCtr).Address);
                        range1_n.Style.Font.Bold = true;
                        range1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_n = range1_n.Style.Border;
                        border1_n.BottomBorder = border1_n.TopBorder = border1_n.LeftBorder = border1_n.RightBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(1, 1).Value = "Daily Statuses Checked per Team";
                        IXLRange range0_1_n = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, dailyTotalCtr).Address);
                        range0_1_n.Merge();
                        range0_1_n.Style.Font.Bold = true;
                        range0_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                        range0_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                        range0_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Columns().AdjustToContents();

                        #endregion
                    }

                    var fileName = $"Ticketing_Tool_Month_End_Accuracy_report.xlsx";
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
            else if (filter.ReportType == ReportType.Weekly.ToString())
            {
                #region Weekly Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Weekly Status";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;


                    //worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                    //IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    //range0_1_6.Merge();
                    //range0_1_6.Style.Font.Bold = true;
                    //range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    //range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    //range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    if (ticketingToolReport.TicketingStatusReport.Count > 0)
                    {
                        #region Body

                        worksheet.Cell(currentRow, 1).Value = "Sr.No";
                        worksheet.Cell(currentRow, 2).Value = "Engagement";
                        int headerCounter = 3;
                        foreach (var header in ticketingToolReport.TicketingStatusReport[0].TicketingStatusReportWeekly)
                        {
                            worksheet.Cell(currentRow, headerCounter).Value = header.Description;
                            headerCounter++;
                        }
                        worksheet.Cell(currentRow, headerCounter).Value = "Average Accuracy";

                        IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, headerCounter).Address);
                        range1_1_n.Style.Font.Bold = true;
                        range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_1_n = range1_1_n.Style.Border;
                        border1_1_n.BottomBorder = border1_1_n.TopBorder = border1_1_n.LeftBorder = border1_1_n.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;

                        foreach (var statusReport in ticketingToolReport.TicketingStatusReport)
                        {
                            worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                            worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            int weeklyHeaderCtr = 3;
                            foreach(var weeklyData in statusReport.TicketingStatusReportWeekly)
                            {
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Value = $"{weeklyData.AccuracyRate}%";
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                                worksheet.Cell(currentRow, weeklyHeaderCtr).DataType = XLDataType.Number;
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                weeklyHeaderCtr++;
                            }

                            worksheet.Cell(currentRow, weeklyHeaderCtr).Value = $"{statusReport.AccuracyRate}%";
                            worksheet.Cell(currentRow, weeklyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, weeklyHeaderCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, weeklyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, weeklyHeaderCtr).Address);
                            range_n_1_n.Style.Font.FontSize = 9;
                            IXLBorder border_n_1_n = range_n_1_n.Style.Border;
                            border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;

                            currentRow++;
                        }

                        worksheet.Cell(currentRow, 1).Value = "";

                        worksheet.Cell(currentRow, 2).Value = "Total";
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        int weeklyTotalCtr = 3;
                        foreach (var weeklyReport in ticketingToolReport.TicketingStatusReport[0].TicketingStatusReportWeekly)
                        {
                            worksheet.Cell(currentRow, weeklyTotalCtr).Value = $"{weeklyReport.AvgAccuracyRate}%";
                            worksheet.Cell(currentRow, weeklyTotalCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, weeklyTotalCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, weeklyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            weeklyTotalCtr++;
                        }

                        worksheet.Cell(currentRow, weeklyTotalCtr).Value = $"{ticketingToolReport.TicketingStatusReport[0].AvgAccuracyRate}%";
                        worksheet.Cell(currentRow, weeklyTotalCtr).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, weeklyTotalCtr).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, weeklyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, weeklyTotalCtr).Address);
                        range1_n.Style.Font.Bold = true;
                        range1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_n = range1_n.Style.Border;
                        border1_n.BottomBorder = border1_n.TopBorder = border1_n.LeftBorder = border1_n.RightBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(1, 1).Value = "Weekly Statuses Checked per Team";
                        IXLRange range0_1_n = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, weeklyTotalCtr).Address);
                        range0_1_n.Merge();
                        range0_1_n.Style.Font.Bold = true;
                        range0_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                        range0_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                        range0_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Columns().AdjustToContents();

                        #endregion
                    }

                    var fileName = $"Ticketing_Tool_Month_End_Accuracy_report.xlsx";
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
            else
            {
                #region Monthly Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Status Checked";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;


                    worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                    IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range0_1_6.Merge();
                    range0_1_6.Style.Font.Bold = true;
                    range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;


                    #region Body

                    worksheet.Cell(currentRow, 1).Value = "Sr.No";
                    worksheet.Cell(currentRow, 2).Value = "Engagement";
                    worksheet.Cell(currentRow, 3).Value = "Tickets Checked";
                    worksheet.Cell(currentRow, 4).Value = "Correct Tickets";
                    worksheet.Cell(currentRow, 5).Value = "Error Counts";
                    worksheet.Cell(currentRow, 6).Value = "Accuracy Rate";

                    IXLRange range1_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range1_1_6.Style.Font.Bold = true;
                    range1_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                    range1_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                    IXLBorder border1_1_6 = range1_1_6.Style.Border;
                    border1_1_6.BottomBorder = border1_1_6.TopBorder = border1_1_6.LeftBorder = border1_1_6.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;

                    foreach (var statusReport in ticketingToolReport.TicketingStatusReport)
                    {
                        worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                        worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                        worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 3).Value = statusReport.TicketsChecked;
                        worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 4).Value = statusReport.CorrectTickets;
                        worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 5).Value = statusReport.ErrorCounts;
                        worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 6).Value = $"{statusReport.AccuracyRate}%";
                        worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 6).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range_n_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                        range_n_1_6.Style.Font.FontSize = 9;
                        IXLBorder border_n_1_6 = range_n_1_6.Style.Border;
                        border_n_1_6.BottomBorder = border_n_1_6.TopBorder = border_n_1_6.LeftBorder = border_n_1_6.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;
                    }

                    worksheet.Cell(currentRow, 1).Value = "";

                    worksheet.Cell(currentRow, 2).Value = "Total";
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 3).Value = ticketingToolReport.TotalTicketsChecked;
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 4).Value = ticketingToolReport.TotalCorrectTickets;
                    worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 5).Value = ticketingToolReport.TotalErrorCounts;
                    worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 6).Value = $"{ticketingToolReport.AvgAccuracyRate}%";
                    worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 6).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLRange range1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range1_6.Style.Font.Bold = true;
                    range1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                    range1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                    IXLBorder border1_6 = range1_6.Style.Border;
                    border1_6.BottomBorder = border1_6.TopBorder = border1_6.LeftBorder = border1_6.RightBorder = XLBorderStyleValues.Thin;

                    worksheet.Columns().AdjustToContents();

                    #endregion

                    var fileName = $"Ticketing_Tool_Month_End_Accuracy_report.xlsx";
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
        }

        #endregion

        #region BUSINESS PARTNER 

        public IActionResult BusinessPartner()
        {
            var report = _reportService.GetBusinessPartnerReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult BusinessPartner(BusinessPartnerFilter filter)
        {
            vwBusinessPartnerReport report = new vwBusinessPartnerReport();
            report = _reportService.GetBusinessPartnerReport(filter);
            if (filter.ReportType == ReportType.Weekly.ToString())
            {
                return PartialView("_BusinessPartnerTableWeekly", report);
            }
            else if (filter.ReportType == ReportType.Daily.ToString())
            {
                return PartialView("_BusinessPartnerTableDaily", report);
            }
            else
            {
                return PartialView("_BusinessPartnerTableMonthly", report);
            }
        }

        [HttpGet]
        public IActionResult BusinessPartnerExcel(DateTime minDate, DateTime maxDate, string reportType)
        {
            var filter = new BusinessPartnerFilter
            {
                StartDate = minDate,
                EndDate = maxDate,
                ReportType = reportType
            };

            var businessPartnerReport = _reportService.GetBusinessPartnerReport(filter);

            if (filter.ReportType == ReportType.Daily.ToString())
            {
                #region Daily Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Daily Status";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;

                    //worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                    //IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    //range0_1_6.Merge();
                    //range0_1_6.Style.Font.Bold = true;
                    //range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    //range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    //range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    if (businessPartnerReport.BPStatusReport.Count > 0)
                    {
                        #region Body

                        worksheet.Cell(currentRow, 1).Value = "Sr.No";
                        worksheet.Cell(currentRow, 2).Value = "Group Name";
                        int headerCounter = 3;
                        foreach (var header in businessPartnerReport.BPStatusReport[0].BPStatusReportDaily)
                        {
                            worksheet.Cell(currentRow, headerCounter).Value = header.Description;
                            headerCounter++;
                        }
                        worksheet.Cell(currentRow, headerCounter).Value = "Average Accuracy";

                        IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, headerCounter).Address);
                        range1_1_n.Style.Font.Bold = true;
                        range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_1_n = range1_1_n.Style.Border;
                        border1_1_n.BottomBorder = border1_1_n.TopBorder = border1_1_n.LeftBorder = border1_1_n.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;

                        foreach (var statusReport in businessPartnerReport.BPStatusReport)
                        {
                            worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                            worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            int dailyHeaderCtr = 3;
                            foreach (var dailyData in statusReport.BPStatusReportDaily)
                            {
                                if (dailyData.AccuracyRate > 0)
                                {
                                    worksheet.Cell(currentRow, dailyHeaderCtr).Value = $"{dailyData.AccuracyRate}%";
                                }
                                worksheet.Cell(currentRow, dailyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                                worksheet.Cell(currentRow, dailyHeaderCtr).DataType = XLDataType.Number;
                                worksheet.Cell(currentRow, dailyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                dailyHeaderCtr++;
                            }

                            worksheet.Cell(currentRow, dailyHeaderCtr).Value = $"{statusReport.AccuracyRate}%";
                            worksheet.Cell(currentRow, dailyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, dailyHeaderCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, dailyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, dailyHeaderCtr).Address);
                            range_n_1_n.Style.Font.FontSize = 9;
                            IXLBorder border_n_1_n = range_n_1_n.Style.Border;
                            border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;

                            currentRow++;
                        }

                        worksheet.Cell(currentRow, 1).Value = "";

                        worksheet.Cell(currentRow, 2).Value = "Total";
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        int dailyTotalCtr = 3;
                        foreach (var dailyReport in businessPartnerReport.BPStatusReport[0].BPStatusReportDaily)
                        {
                            if (dailyReport.AvgAccuracyRate > 0)
                            {
                                worksheet.Cell(currentRow, dailyTotalCtr).Value = $"{dailyReport.AvgAccuracyRate}%";
                            }
                            worksheet.Cell(currentRow, dailyTotalCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, dailyTotalCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, dailyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            dailyTotalCtr++;
                        }

                        worksheet.Cell(currentRow, dailyTotalCtr).Value = $"{businessPartnerReport.BPStatusReport[0].AvgAccuracyRate}%";
                        worksheet.Cell(currentRow, dailyTotalCtr).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, dailyTotalCtr).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, dailyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, dailyTotalCtr).Address);
                        range1_n.Style.Font.Bold = true;
                        range1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_n = range1_n.Style.Border;
                        border1_n.BottomBorder = border1_n.TopBorder = border1_n.LeftBorder = border1_n.RightBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(1, 1).Value = "Daily Statuses Checked per Group";
                        IXLRange range0_1_n = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, dailyTotalCtr).Address);
                        range0_1_n.Merge();
                        range0_1_n.Style.Font.Bold = true;
                        range0_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                        range0_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                        range0_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Columns().AdjustToContents();

                        #endregion
                    }

                    var fileName = $"Business_Partner_Month_End_Accuracy_report.xlsx";
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
            else if (filter.ReportType == ReportType.Weekly.ToString())
            {
                #region Weekly Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Weekly Status";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;


                    //worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                    //IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    //range0_1_6.Merge();
                    //range0_1_6.Style.Font.Bold = true;
                    //range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    //range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    //range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;

                    if (businessPartnerReport.BPStatusReport.Count > 0)
                    {
                        #region Body

                        worksheet.Cell(currentRow, 1).Value = "Sr.No";
                        worksheet.Cell(currentRow, 2).Value = "Group Name";
                        int headerCounter = 3;
                        foreach (var header in businessPartnerReport.BPStatusReport[0].BPStatusReportWeekly)
                        {
                            worksheet.Cell(currentRow, headerCounter).Value = header.Description;
                            headerCounter++;
                        }
                        worksheet.Cell(currentRow, headerCounter).Value = "Average Accuracy";

                        IXLRange range1_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, headerCounter).Address);
                        range1_1_n.Style.Font.Bold = true;
                        range1_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_1_n = range1_1_n.Style.Border;
                        border1_1_n.BottomBorder = border1_1_n.TopBorder = border1_1_n.LeftBorder = border1_1_n.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;

                        foreach (var statusReport in businessPartnerReport.BPStatusReport)
                        {
                            worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                            worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            int weeklyHeaderCtr = 3;
                            foreach (var weeklyData in statusReport.BPStatusReportWeekly)
                            {
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Value = $"{weeklyData.AccuracyRate}%";
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                                worksheet.Cell(currentRow, weeklyHeaderCtr).DataType = XLDataType.Number;
                                worksheet.Cell(currentRow, weeklyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                weeklyHeaderCtr++;
                            }

                            worksheet.Cell(currentRow, weeklyHeaderCtr).Value = $"{statusReport.AccuracyRate}%";
                            worksheet.Cell(currentRow, weeklyHeaderCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, weeklyHeaderCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, weeklyHeaderCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            IXLRange range_n_1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, weeklyHeaderCtr).Address);
                            range_n_1_n.Style.Font.FontSize = 9;
                            IXLBorder border_n_1_n = range_n_1_n.Style.Border;
                            border_n_1_n.BottomBorder = border_n_1_n.TopBorder = border_n_1_n.LeftBorder = border_n_1_n.RightBorder = XLBorderStyleValues.Thin;

                            currentRow++;
                        }

                        worksheet.Cell(currentRow, 1).Value = "";

                        worksheet.Cell(currentRow, 2).Value = "Total";
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                        int weeklyTotalCtr = 3;
                        foreach (var weeklyReport in businessPartnerReport.BPStatusReport[0].BPStatusReportWeekly)
                        {
                            worksheet.Cell(currentRow, weeklyTotalCtr).Value = $"{weeklyReport.AvgAccuracyRate}%";
                            worksheet.Cell(currentRow, weeklyTotalCtr).Style.NumberFormat.Format = "0.00%";
                            worksheet.Cell(currentRow, weeklyTotalCtr).DataType = XLDataType.Number;
                            worksheet.Cell(currentRow, weeklyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            weeklyTotalCtr++;
                        }

                        worksheet.Cell(currentRow, weeklyTotalCtr).Value = $"{businessPartnerReport.BPStatusReport[0].AvgAccuracyRate}%";
                        worksheet.Cell(currentRow, weeklyTotalCtr).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, weeklyTotalCtr).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, weeklyTotalCtr).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range1_n = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, weeklyTotalCtr).Address);
                        range1_n.Style.Font.Bold = true;
                        range1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                        range1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                        IXLBorder border1_n = range1_n.Style.Border;
                        border1_n.BottomBorder = border1_n.TopBorder = border1_n.LeftBorder = border1_n.RightBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(1, 1).Value = "Weekly Statuses Checked per Group";
                        IXLRange range0_1_n = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, weeklyTotalCtr).Address);
                        range0_1_n.Merge();
                        range0_1_n.Style.Font.Bold = true;
                        range0_1_n.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                        range0_1_n.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                        range0_1_n.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Columns().AdjustToContents();

                        #endregion
                    }

                    var fileName = $"Business_Partner_Month_End_Accuracy_report.xlsx";
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
            else
            {
                #region Monthly Workbook

                using (var workbook = new XLWorkbook())
                {
                    var tab = $"Status Checked";
                    var worksheet = workbook.Worksheets.Add(tab);
                    worksheet.Style.Font.SetFontName("Calibri");
                    var currentRow = 1;


                    worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Group";
                    IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range0_1_6.Merge();
                    range0_1_6.Style.Font.Bold = true;
                    range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                    range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                    range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    currentRow++;


                    #region Body

                    worksheet.Cell(currentRow, 1).Value = "Sr.No";
                    worksheet.Cell(currentRow, 2).Value = "Group Name";
                    worksheet.Cell(currentRow, 3).Value = "Tickets Checked";
                    worksheet.Cell(currentRow, 4).Value = "Correct Tickets";
                    worksheet.Cell(currentRow, 5).Value = "Error Counts";
                    worksheet.Cell(currentRow, 6).Value = "Accuracy Rate";

                    IXLRange range1_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range1_1_6.Style.Font.Bold = true;
                    range1_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                    range1_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                    IXLBorder border1_1_6 = range1_1_6.Style.Border;
                    border1_1_6.BottomBorder = border1_1_6.TopBorder = border1_1_6.LeftBorder = border1_1_6.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;

                    foreach (var statusReport in businessPartnerReport.BPStatusReport)
                    {
                        worksheet.Cell(currentRow, 1).Value = currentRow - 2;

                        worksheet.Cell(currentRow, 2).Value = statusReport.Engagement;
                        worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                        worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 3).Value = statusReport.TicketsChecked;
                        worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 4).Value = statusReport.CorrectTickets;
                        worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 5).Value = statusReport.ErrorCounts;
                        worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        worksheet.Cell(currentRow, 6).Value = $"{statusReport.AccuracyRate}%";
                        worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "0.00%";
                        worksheet.Cell(currentRow, 6).DataType = XLDataType.Number;
                        worksheet.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        IXLRange range_n_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                        range_n_1_6.Style.Font.FontSize = 9;
                        IXLBorder border_n_1_6 = range_n_1_6.Style.Border;
                        border_n_1_6.BottomBorder = border_n_1_6.TopBorder = border_n_1_6.LeftBorder = border_n_1_6.RightBorder = XLBorderStyleValues.Thin;

                        currentRow++;
                    }

                    worksheet.Cell(currentRow, 1).Value = "";

                    worksheet.Cell(currentRow, 2).Value = "Total";
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 3).Value = businessPartnerReport.TotalTicketsChecked;
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 4).Value = businessPartnerReport.TotalCorrectTickets;
                    worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 5).Value = businessPartnerReport.TotalErrorCounts;
                    worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 6).Value = $"{businessPartnerReport.AvgAccuracyRate}%";
                    worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 6).DataType = XLDataType.Number;
                    worksheet.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    IXLRange range1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                    range1_6.Style.Font.Bold = true;
                    range1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                    range1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                    IXLBorder border1_6 = range1_6.Style.Border;
                    border1_6.BottomBorder = border1_6.TopBorder = border1_6.LeftBorder = border1_6.RightBorder = XLBorderStyleValues.Thin;

                    worksheet.Columns().AdjustToContents();

                    #endregion

                    var fileName = $"Business_Partner_Month_End_Accuracy_report.xlsx";
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
        }

        #endregion

        #region Certification
        public IActionResult Certification()
        {
            var report = _reportService.GetCertificationReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult Certification(CertificationFilter filter)
        {
            vwCertificationReport report = new vwCertificationReport();
            report = _reportService.GetCertificationReport(filter);
            return PartialView("_CertificationTable", report);            
        }

        [HttpGet]
        public IActionResult CertificationExcel(DateTime minDate, DateTime maxDate)
        {
            var filter = new CertificationFilter
            {
                StartDate = minDate,
                EndDate = maxDate
            };

            var certificationReport = _reportService.GetCertificationReport(filter);
            using (var workbook = new XLWorkbook())
            {
                var tab = $"Certification Report";
                var worksheet = workbook.Worksheets.Add(tab);
                worksheet.Style.Font.SetFontName("Calibri");
                var currentRow = 1;


                //worksheet.Cell(currentRow, 1).Value = "Statuses Checked per Team";
                //IXLRange range0_1_6 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 6).Address);
                //range0_1_6.Merge();
                //range0_1_6.Style.Font.Bold = true;
                //range0_1_6.Style.Fill.SetBackgroundColor(XLColor.FromArgb(31, 78, 121));
                //range0_1_6.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));
                //range0_1_6.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                //currentRow++;


                #region Body

                worksheet.Cell(currentRow, 1).Value = "SR.NO.";
                worksheet.Cell(currentRow, 2).Value = "AGENT NAME";
                worksheet.Cell(currentRow, 3).Value = "EMPLOYEE ID";
                worksheet.Cell(currentRow, 4).Value = "POSITION";
                worksheet.Cell(currentRow, 5).Value = "DATE HIRED";
                worksheet.Cell(currentRow, 6).Value = "TENURE";
                worksheet.Cell(currentRow, 7).Value = "CERTIFICATION DATE";
                worksheet.Cell(currentRow, 8).Value = "OSVC SCORE";
                worksheet.Cell(currentRow, 9).Value = "OA SCORE";
                worksheet.Cell(currentRow, 10).Value = "EM SCORE";
                worksheet.Cell(currentRow, 11).Value = "PRODUCT/ SYSTEM AVERAGE";
                worksheet.Cell(currentRow, 12).Value = "PRODUCT & SYSTEM CERTIFICATION LEVEL";

                IXLRange range1_1_12 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 12).Address);
                range1_1_12.Style.Font.Bold = true;
                range1_1_12.Style.Fill.SetBackgroundColor(XLColor.FromArgb(46, 117, 182));
                range1_1_12.Style.Font.SetFontColor(XLColor.FromArgb(255, 255, 255));

                IXLBorder border1_1_12 = range1_1_12.Style.Border;
                border1_1_12.BottomBorder = border1_1_12.TopBorder = border1_1_12.LeftBorder = border1_1_12.RightBorder = XLBorderStyleValues.Thin;

                currentRow++;

                foreach (var statusReport in certificationReport.CertificationLevelReport)
                {
                    worksheet.Cell(currentRow, 1).Value = currentRow - 1;

                    worksheet.Cell(currentRow, 2).Value = statusReport.AgentName;
                    worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 3).Value = statusReport.EmployeeId;
                    worksheet.Cell(currentRow, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 4).Value = statusReport.Position;
                    worksheet.Cell(currentRow, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 5).Value = statusReport.HiredDate;
                    worksheet.Cell(currentRow, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 6).Value = statusReport.Tenure;
                    worksheet.Cell(currentRow, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 7).Value = statusReport.CertificationDate;
                    worksheet.Cell(currentRow, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    worksheet.Cell(currentRow, 8).Value = statusReport.OSVC_Score;
                    worksheet.Cell(currentRow, 8).Style.NumberFormat.Format = "0.00%";                    
                    worksheet.Cell(currentRow, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    if(statusReport.OSVC_Score!="N/A")
                    {
                        worksheet.Cell(currentRow, 8).DataType = XLDataType.Number;
                    }

                    worksheet.Cell(currentRow, 9).Value = statusReport.OA_Score;
                    worksheet.Cell(currentRow, 9).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    if (statusReport.OA_Score != "N/A")
                    {
                        worksheet.Cell(currentRow, 9).DataType = XLDataType.Number;
                    }

                    worksheet.Cell(currentRow, 10).Value = statusReport.EM_Score;
                    worksheet.Cell(currentRow, 10).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    if (statusReport.EM_Score != "N/A")
                    {
                        worksheet.Cell(currentRow, 10).DataType = XLDataType.Number;
                    }

                    worksheet.Cell(currentRow, 11).Value = statusReport.Average;
                    worksheet.Cell(currentRow, 11).Style.NumberFormat.Format = "0.00%";
                    worksheet.Cell(currentRow, 11).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    if (statusReport.Average != "N/A")
                    {
                        worksheet.Cell(currentRow, 11).DataType = XLDataType.Number;
                    }

                    worksheet.Cell(currentRow, 12).Value = statusReport.Level;
                    worksheet.Cell(currentRow, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    
                    IXLRange range_n_1_12 = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 12).Address);
                    range_n_1_12.Style.Font.FontSize = 9;
                    IXLBorder border_n_1_12 = range_n_1_12.Style.Border;
                    border_n_1_12.BottomBorder = border_n_1_12.TopBorder = border_n_1_12.LeftBorder = border_n_1_12.RightBorder = XLBorderStyleValues.Thin;

                    currentRow++;
                }                

                worksheet.Columns().AdjustToContents();

                #endregion

                var fileName = $"Certification_report.xlsx";
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
}
