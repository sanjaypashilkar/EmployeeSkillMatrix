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

        public EmployeeController(IHostingEnvironment _environment, IEmployeeService employeeService)
        {
            Environment = _environment;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = new vwEmployee();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            vwEmployee employeesView = new vwEmployee();
            if (file != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(file.FileName);
                string fullFilePath = Path.Combine(path, fileName);
                if (System.IO.File.Exists(fullFilePath))
                {
                    System.IO.File.Delete(fullFilePath);
                }
                using (FileStream stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                    ViewBag.FileName += fileName;
                }
                var employees = _employeeService.GetEmployees(fullFilePath);
                employeesView.Employees = employees;
            }
            return View(employeesView);
        }

        [HttpPost]
        public IActionResult SaveEmployees(string fileName)
        {
            Response response = new Response();
            List<vwEmployee> employees = new List<vwEmployee>();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _employeeService.SaveEmployees(fullFilePath);
                response.Success = true;
                response.Message = $"Employees saved successfully";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Employees()
        {
            var employees = _employeeService.GetEmployees();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Employees(int pg)
        {
            var employees = _employeeService.GetEmployees(pg);
            return PartialView("_Table", employees);
        }
    }
}
