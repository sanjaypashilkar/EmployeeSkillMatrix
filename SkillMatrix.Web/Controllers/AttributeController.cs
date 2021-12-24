using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Model;
using SkillMatrix.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace SkillMatrix.Web.Controllers
{
    public class AttributeController : Controller
    {
        private IWebHostEnvironment _environment;
        public IAttributeService _attributeService { get; set; }
        public AttributeController(IWebHostEnvironment environment, IAttributeService attributeService)
        {
            _environment = environment;
            _attributeService = attributeService;
        }

        #region QUALITY RATING

        public IActionResult Quality()
        {
            vwImportAndSaveQualityRating qualityRating = new vwImportAndSaveQualityRating();
            qualityRating.lstDepartments = _attributeService.mtdGetDepartments();
            qualityRating.lstAccountTypes = _attributeService.mtdGetAccountTypes();
            return View(qualityRating);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Quality(IFormFile file, FileInput input)
        {
            vwImportAndSaveQualityRating qualityRating = new vwImportAndSaveQualityRating();
            if (file != null)
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(file.FileName);
                string fullFilePath = Path.Combine(path, fileName);
                input.FileName = fullFilePath;
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
                qualityRating = _attributeService.GetUploadedQualityRating(input);
            }
            return View(qualityRating);
        }

        [HttpPost]
        public IActionResult SaveQualityRating(FileInput fileInput)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileInput.FileName))
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileInput.FileName);
                fileInput.FileName = fullFilePath;
                _attributeService.SaveQualityRatings(fileInput);
                response.Success = true;
                response.Message = $"Quality rating saved successfully for department {fileInput.Department}";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadQualityTemplate(string accountType, string department)
        {
            string fileName = string.Empty;
            if (accountType == AccountType.Elsevier.ToString())
            {
                fileName = "Template_Quality_Elsevier.xlsx";
            }
            else
            {
                fileName = "Template_QualityChecks.xlsx";
                if (department.ToLowerInvariant() == Department.CompCopy.ToString().ToLowerInvariant() || department.ToLowerInvariant() == Department.OrderManagement.ToString().ToLowerInvariant())
                {
                    fileName = "Template_QualityForms.xlsx";
                }
            }            
            string path = Path.Combine(this._environment.WebRootPath, "Files\\Templates");
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

        #region TICKETING TOOL

        public IActionResult TicketingTool()
        {
            vwImportAndSaveTicketingTool ticketingTool = new vwImportAndSaveTicketingTool();
            return View(ticketingTool);
        }

        [HttpPost]
        public IActionResult TicketingTool(IFormFile file)
        {
            vwImportAndSaveTicketingTool ticketingTool = new vwImportAndSaveTicketingTool();
            if (file != null)
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
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
                ticketingTool = _attributeService.GetUploadedTicketingRecords(fullFilePath);
            }
            return View(ticketingTool);
        }

        [HttpPost]
        public IActionResult SaveTicketingRecords(string fileName, string recordDate)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _attributeService.SaveTicketingRecords(fullFilePath, recordDate);
                response.Success = true;
                response.Message = $"Ticketing tool records saved successfully";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadTicketingTemplate()
        {
            string fileName = "Template_TicketingTool.xlsx";
            string path = Path.Combine(this._environment.WebRootPath, "Files\\Templates");
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

        #region BUSINESS PARTNER

        public IActionResult BusinessPartner()
        {
            vwImportAndSaveBusinessPartner businessPartner = new vwImportAndSaveBusinessPartner();
            return View(businessPartner);
        }

        [HttpPost]
        public IActionResult BusinessPartner(IFormFile file)
        {
            vwImportAndSaveBusinessPartner businessPartner = new vwImportAndSaveBusinessPartner();
            if (file != null)
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
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
                businessPartner = _attributeService.GetUploadedBusinessPartnerRecords(fullFilePath);
            }
            return View(businessPartner);
        }

        [HttpPost]
        public IActionResult SaveBusinessPartnerRecords(string fileName, string recordDate)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _attributeService.SaveBusinessPartnerRecords(fullFilePath, recordDate);
                response.Success = true;
                response.Message = $"Business partner records saved successfully";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadBPTemplate()
        {
            string fileName = "Template_BusinessPartner.xlsx";
            string path = Path.Combine(this._environment.WebRootPath, "Files\\Templates");
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

        #region CSAT
        public IActionResult CSAT()
        {
            vwImportAndSaveCSAT csat = new vwImportAndSaveCSAT();
            return View(csat);
        }

        [HttpPost]
        public IActionResult CSAT(IFormFile file)
        {
            vwImportAndSaveCSAT csatRecords = new vwImportAndSaveCSAT();
            if (file != null)
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
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
                csatRecords = _attributeService.GetUploadedCSATRecords(fullFilePath);
            }
            return View(csatRecords);
        }

        [HttpPost]
        public IActionResult SaveCSATRecords(string fileName, string recordDate)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _attributeService.SaveCSATRecords(fullFilePath, recordDate);
                response.Success = true;
                response.Message = $"CSAT records saved successfully";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadCSATTemplate()
        {
            string fileName = "Template_CSAT.xlsx";
            string path = Path.Combine(this._environment.WebRootPath, "Files\\Templates");
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

        #region CERTIFICATION
        public IActionResult Certification()
        {
            vwImportAndSaveCertification certification = new vwImportAndSaveCertification();
            certification.lstAccountTypes = _attributeService.mtdGetAccountTypes();
            return View(certification);
        }

        [HttpPost]
        public IActionResult Certification(IFormFile file)
        {
            vwImportAndSaveCertification certifications = new vwImportAndSaveCertification();
            if (file != null)
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
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
                certifications = _attributeService.GetUploadedCertificationRecords(fullFilePath);
            }
            return View(certifications);
        }

        [HttpPost]
        public IActionResult SaveCertifications(string fileName, string recordDate)
        {
            Response response = new Response();
            if (!string.IsNullOrEmpty(fileName))
            {
                string path = Path.Combine(this._environment.WebRootPath, "Files");
                string fullFilePath = Path.Combine(path, fileName);
                _attributeService.SaveCertifications(fullFilePath, recordDate);
                response.Success = true;
                response.Message = $"Certification records saved successfully";
            }
            else
            {
                response.Success = false;
                response.Message = $"Please select file to import";
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult DownloadCertificationTemplate()
        {
            string fileName = "Template_Certification.xlsx";
            string path = Path.Combine(this._environment.WebRootPath, "Files\\Templates");
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
    }
}
