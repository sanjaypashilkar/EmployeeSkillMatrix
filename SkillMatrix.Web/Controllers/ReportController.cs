using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Model;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
