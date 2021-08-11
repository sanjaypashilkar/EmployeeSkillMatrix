using Microsoft.AspNetCore.Mvc;
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
            var report = _reportService.GetSkillMatrixReport();
            return View(report);
        }
    }
}
