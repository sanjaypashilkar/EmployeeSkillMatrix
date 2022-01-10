using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IAttributeService
    {
        Dictionary<string, string> mtdGetDepartments();
        Dictionary<string, string> mtdGetAccountTypes();
        vwImportAndSaveQualityRating GetUploadedQualityRating(FileInput fileInput);        
        void SaveQualityRatings(FileInput fileInput);
        vwImportAndSaveTicketingTool GetUploadedTicketingRecords(string fileName);
        void SaveTicketingRecords(string fileName, string recordDate);
        vwImportAndSaveBusinessPartner GetUploadedBusinessPartnerRecords(string fileName);
        void SaveBusinessPartnerRecords(string fileName, string recordDate);
        vwImportAndSaveCSAT GetUploadedCSATRecords(string fileName);
        void SaveCSATRecords(string fileName, string recordDate);
        vwImportAndSaveCertification GetUploadedCertificationRecords(FileInput fileInput);
        void SaveCertifications(FileInput fileInput);
    }
}
