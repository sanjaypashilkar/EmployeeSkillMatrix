using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IAttributeService
    {
        Dictionary<string, string> mtdGetDepartments();
        vwImportAndSaveQualityRating GetUploadedQualityRating(string fileName);        
        void SaveQualityRatings(string fileName, string department, string recordDate);
        vwImportAndSaveTicketingTool GetUploadedTicketingRecords(string fileName);
        void SaveTicketingRecords(string fileName, string recordDate);
        vwImportAndSaveBusinessPartner GetUploadedBusinessPartnerRecords(string fileName);
        void SaveBusinessPartnerRecords(string fileName, string recordDate);
    }
}
