﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyf;
        public SkillMatrixController(IHostingEnvironment _environment, ISkillMatrixService skillMatrixService, INotyfService notyf)
        {
            Environment = _environment;
            _skillMatrixService = skillMatrixService;
            _notyf = notyf;
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
                using (FileStream stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    ViewBag.FileName += fileName;
                }
                import = _skillMatrixService.GetUploadedSkillMatrix(fullFilePath);
            }
            return View(import);
        }

        [HttpPost]
        public void SaveSkillMatrix(string fileName, string year, string quarter)
        {
            if(!string.IsNullOrEmpty(fileName))
            { 
            string path = Path.Combine(this.Environment.WebRootPath, "Files");
            string fullFilePath = Path.Combine(path, fileName);
            _skillMatrixService.SaveSkillMatrix(fullFilePath, year, quarter);
            _notyf.Success("Skill matrix saved successfully.", 3);
            ViewBag.Message += string.Format("<b>{0}</b> saved.<br />", fileName);
            }
        }
    }
}
