using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Model;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Controllers
{
    public class SkillMatrixController : Controller
    {
        private IHostingEnvironment Environment;
        public ISkillMatrixService _skillMatrixService { get; set; }

        public SkillMatrixController(IHostingEnvironment _environment, ISkillMatrixService skillMatrixService)
        {
            Environment = _environment;
            _skillMatrixService = skillMatrixService;
        }

        public IActionResult Index()
        {
            var importSkills = _skillMatrixService.GetYearAndQuarter();
            return View(importSkills);
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
            var employeeSkillMatrices = _skillMatrixService.GetUploadedSkillMatrix(fullFilePath);
            return View(employeeSkillMatrices);
        }

        [HttpPost]
        public void SaveSkillMatrix(string fileName, string year, string quarter)
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Files");
            string fullFilePath = Path.Combine(path, fileName);
            _skillMatrixService.SaveSkillMatrix(fullFilePath, year, quarter);           
            ViewBag.Message += string.Format("<b>{0}</b> saved.<br />", fileName);
        }
    }
}
