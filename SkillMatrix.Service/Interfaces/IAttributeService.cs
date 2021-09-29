using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Service
{
    public interface IAttributeService
    {
        vwImportAndSaveQualityRating GetUploadedQualityRating(string fileName);
        Dictionary<string, string> mtdGetDepartments();
        void SaveQualityRatings(string fileName, string department, string recordDate);
    }
}
