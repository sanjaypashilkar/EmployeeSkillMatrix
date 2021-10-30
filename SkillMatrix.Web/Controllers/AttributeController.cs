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
    public class AttributeController : Controller
    {
        private IHostingEnvironment Environment;
        public IAttributeService _attributeService { get; set; }
        public AttributeController(IHostingEnvironment _environment, IAttributeService attributeService)
        {
            Environment = _environment;
            _attributeService = attributeService;
        }

        #region QUALITY

        public IActionResult Quality()
        {
            vwImportAndSaveQualityRating qualityRating = new vwImportAndSaveQualityRating();
            qualityRating.lstDepartments = _attributeService.mtdGetDepartments();
            return View(qualityRating);
        }

        [HttpPost]
        public IActionResult Quality(IFormFile file)
        {
            vwImportAndSaveQualityRating qualityRating = new vwImportAndSaveQualityRating();
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
                qualityRating = _attributeService.GetUploadedQualityRating(fullFilePath);
            }
            return View(qualityRating);
        }

        [HttpPost]
        public IActionResult SaveQualityRating(string fileName, string department, string recordDate)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _attributeService.SaveQualityRatings(fullFilePath, department, recordDate);
                response.Success = true;
                response.Message = $"Quality rating saved successfully for department {department}";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadQualityTemplate(string department)
        {
            string fileName = "Template_QualityChecks.xlsx";
            if (department.ToLowerInvariant() == Department.ComCopy.ToString().ToLowerInvariant() || department.ToLowerInvariant() == Department.OrderManagement.ToString().ToLowerInvariant())
            {
                fileName = "Template_QualityForms.xlsx";
            }
            string path = Path.Combine(this.Environment.WebRootPath, "Files\\Templates");
            string path1 = Path.Combine(path, "Templates");
            string fullFilePath = Path.Combine(path, fileName);
            byte[] content = System.IO.File.ReadAllBytes(fullFilePath);
            return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName
                    );
        }

        #endregion

        public IActionResult TicketingTool()
        {
            vwImportAndSaveQualityRating qualityRating = new vwImportAndSaveQualityRating();
            qualityRating.lstDepartments = _attributeService.mtdGetDepartments();
            return View(qualityRating);
        }
    }
}
