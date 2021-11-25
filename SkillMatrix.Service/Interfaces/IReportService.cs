using ClosedXML.Excel;
using SkillMatrix.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        Dictionary<string, string> mtdGetDepartments();
        Dictionary<string, string> mtdGetQCReportTypes1();
        Dictionary<string, string> mtdGetQCReportTypes2();
        vwQualityReport GetQualityReport(QualityFilter filter);
        vwQualityReport GetQualityReport2(QualityFilter filter);
        vwQualityReport GetQualityReport3(QualityFilter filter);
        vwTicketingToolReport GetTicketingToolReport(TicketingToolFilter filter);
        vwBusinessPartnerReport GetBusinessPartnerReport(BusinessPartnerFilter filter);
    }
}
