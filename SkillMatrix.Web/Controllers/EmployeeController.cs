using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Model;
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
        private readonly INotyfService _notyf;

        public EmployeeController(IHostingEnvironment _environment, IEmployeeService employeeService, INotyfService notyf)
        {
            Environment = _environment;
            _employeeService = employeeService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            List<vwEmployee> employees = new List<vwEmployee>();
            if (file != null)
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
                employees = _employeeService.GetEmployees(fullFilePath);
            }
            return View(employees);
        }

        [HttpPost]
        public IActionResult SaveEmployees(string fileName)
        {
            List<vwEmployee> employees = new List<vwEmployee>();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _employeeService.SaveEmployees(fullFilePath);
                ViewBag.Message += string.Format("<b>{0}</b> saved.<br />", fileName);
                employees = _employeeService.GetEmployees();
                _notyf.Success("Employees saved successfully.", 3);
            }
            return View(employees);
        }
    }
}
