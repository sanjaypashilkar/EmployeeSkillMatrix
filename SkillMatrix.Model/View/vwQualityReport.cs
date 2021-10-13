using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwQualityReport
    {
        public virtual List<vwQualityReportSummary> QualitySummary { get; set; }
        public virtual List<vwQualityReportSummary> PaginatedSummary { get; set; }

        public virtual List<vwQualityReportWeekly> WeeklyQualityReport { get; set; }
        public virtual List<vwQualityReportWeekly> PaginatedWeeklyReport { get; set; }

        public virtual List<vwQualityReportDaily> DailyQualityReport { get; set; }
        public virtual List<vwQualityReportDaily> PaginatedDailyReport { get; set; }

        public virtual Dictionary<string, string> lstDepartments { get; set; }
        public virtual Dictionary<string, string> lstReportType { get; set; }
        public virtual QualityFilter QualityFilter { get; set; }
        public virtual Pager Pager { get; set; }

        public vwQualityReport()
        {
            QualitySummary = new List<vwQualityReportSummary>();
            PaginatedSummary = new List<vwQualityReportSummary>();
            
            WeeklyQualityReport = new List<vwQualityReportWeekly>();
            PaginatedWeeklyReport = new List<vwQualityReportWeekly>();

            DailyQualityReport = new List<vwQualityReportDaily>();
            PaginatedDailyReport = new List<vwQualityReportDaily>();

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

    public class vwQualityReportWeekly
    {
        public string AgentName { get; set; }
        public string TeamLead { get; set; }
        public List<WeeklyAccuracy> WeeklyAccuracy { get; set; }
        public double AverageMTD { get; set; }
        public double AvgOfAvgMTD { get; set; }

        public vwQualityReportWeekly()
        {
            WeeklyAccuracy = new List<WeeklyAccuracy>();
        }
    }

    public class vwQualityReportDaily
    {
        public string AgentName { get; set; }
        public string TeamLead { get; set; }
        public List<DailySampling> DailySampling { get; set; }
        public double AvgSampling { get; set; }
        public double AvgOfAvgSampling { get; set; }

        public vwQualityReportDaily()
        {
            DailySampling = new List<DailySampling>();
        }
    }
}
