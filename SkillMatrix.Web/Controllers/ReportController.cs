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
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            var report = _reportService.GetSkillMatrixReport(null);
            return View(report);
        }

        [HttpPost]
        public IActionResult Index(SkillMatrixFilter filter)
        {
            var report = _reportService.GetSkillMatrixReport(filter);
            return PartialView("_FilterAndTable",report);
        }

        [HttpPost]
        public IActionResult Filter(SkillMatrixFilter filter)
        {
            var report = _reportService.GetSkillMatrixReport(filter);
            return PartialView("_Table", report);
        }

        public IActionResult GenerateExcel()
        {
            Response response = new Response();
            var filter = new SkillMatrixFilter
            {
                Year=2020,
                Quarter=1,
                Team = "EMEA Books"
            };

            var skillReport = _reportService.GetSkillMatrixReport(filter);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("SkillMatrix");
                var currentRow = 1;
                #region Header

                worksheet.Cell(currentRow, 1).Value = "Sr.No.";
                worksheet.Cell(currentRow, 2).Value = "Team";
                worksheet.Cell(currentRow, 3).Value = "Name";

                #endregion

                #region Body

                foreach (var skillMatrix in skillReport.SkillMatrix)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = currentRow - 1;
                    worksheet.Cell(currentRow, 2).Value = skillMatrix.Team;
                    worksheet.Cell(currentRow, 3).Value = skillMatrix.Name;
                }

                #endregion

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "SkillMatrix.xlsx"
                        );
                }                
            }
            response.Success = true;
            response.Message = $"Skill matrix report downloaded successfully";
            return Json(response);
        }
    }
}
