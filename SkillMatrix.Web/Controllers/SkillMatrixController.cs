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
            vwImportAndSave import = new vwImportAndSave();
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
                import = _skillMatrixService.GetUploadedSkillMatrix(fullFilePath);
            }
            return View(import);
        }

        [HttpPost]
        public IActionResult SaveSkillMatrix(string fileName, string year, string quarter)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            { 
                string path = Path.Combine(this.Environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _skillMatrixService.SaveSkillMatrix(fullFilePath, year, quarter);
                response.Success = true;
                response.Message = $"Skill matrix saved successfully for year {year}, quarter {quarter}";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }
    }
}
