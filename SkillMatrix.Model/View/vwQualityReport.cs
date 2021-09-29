using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwQualityReport
    {
        public virtual List<vwQualityReportSummary> QualitySummary { get; set; }
        public virtual List<vwQualityReportSummary> PaginatedSummary { get; set; }
        public virtual Dictionary<string, string> lstDepartments { get; set; }
        public virtual Dictionary<string, string> lstReportType { get; set; }
        public virtual QualityFilter QualityFilter { get; set; }
        public virtual Pager Pager { get; set; }

        public vwQualityReport()
        {
            QualitySummary = new List<vwQualityReportSummary>();
            PaginatedSummary = new List<vwQualityReportSummary>();
            lstDepartments = new Dictionary<string, string>();
            lstReportType = new Dictionary<string, string>();
            QualityFilter = new QualityFilter();
            Pager = new Pager();
        }
    }

    public class vwQualityReportSummary
    {
        public string Category { get; set; }
        public int TicketsChecked { get; set; }
        public double TicketsPassed { get; set; }
        public double AvgSNCSScore { get; set; }
        public double AvgSPIScore { get; set; }
    }
}
