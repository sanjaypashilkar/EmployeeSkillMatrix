using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SkillMatrix.Service
{
    public interface IReportService
    {
        vwSkillReport GetSkillMatrixReport();
        vwSkillReport GetSkillMatrixReport(SkillMatrixFilter skillMatrixFilter);
        List<SelectListItem> mtdGetCompetencyLevel();
        List<SelectListItem> mtdGetTenureLevel();
    }
}
