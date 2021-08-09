using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IHostingEnvironment Environment;
        public IEmployeeService _employeeService { get; set; }

        public EmployeeController(IHostingEnvironment _environment, IEmployeeService employeeService)
        {
            Environment = _environment;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(file.FileName);
            string fullFilePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(fullFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Flush();
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                ViewBag.FileName += fileName;
            }
            var employeeSkillMatrices = _employeeService.GetEmployees(fullFilePath);
            return View(employeeSkillMatrices);
        }

        [HttpPost]
        public IActionResult SaveEmployees(string fileName)
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Files");
            string fullFilePath = Path.Combine(path, fileName);
            _employeeService.SaveEmployees(fullFilePath);
            ViewBag.Message += string.Format("<b>{0}</b> saved.<br />", fileName);
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }
    }
}
