using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SkillMatrix.Service
{
    public interface IReportService
    {
        vwSkillReport GetSkillMatrixReport(SkillMatrixFilter skillMatrixFilter);
        Dictionary<string,string> mtdGetCompetencyLevel();
        Dictionary<string, string> mtdGetTenureLevel();
        Dictionary<string, string> mtdGetYears();
        Dictionary<string, string> mtdGetQuarters();
        Dictionary<string, string> mtdGetTeams(int year, int quarter);
    }
}
