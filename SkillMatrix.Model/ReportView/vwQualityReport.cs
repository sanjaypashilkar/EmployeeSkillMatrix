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

        public virtual List<vwQualityReportSummaryELSV> CategorySummaryELSV { get; set; }
        public virtual List<vwQualityReportSummaryELSV> PaginatedCategorySummaryELSV { get; set; }

        public virtual List<vwQualityReportAgentSummaryELSV> AgentSummaryELSV { get; set; }
        public virtual List<vwQualityReportAgentSummaryELSV> PaginatedAgentSummaryELSV { get; set; }

        public virtual Dictionary<string, string> lstAccountTypes { get; set; }
        public virtual Dictionary<string, string> lstDepartments { get; set; }
        public virtual Dictionary<string, string> lstReportType1 { get; set; }
        public virtual Dictionary<string, string> lstReportType2 { get; set; }
        public virtual Dictionary<string, string> lstReportType3 { get; set; }
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

            CategorySummaryELSV = new List<vwQualityReportSummaryELSV>();
            PaginatedCategorySummaryELSV = new List<vwQualityReportSummaryELSV>();

            AgentSummaryELSV = new List<vwQualityReportAgentSummaryELSV>();
            PaginatedAgentSummaryELSV = new List<vwQualityReportAgentSummaryELSV>();

            lstAccountTypes = new Dictionary<string, string>();
            lstDepartments = new Dictionary<string, string>();
            lstReportType1 = new Dictionary<string, string>();
            lstReportType2 = new Dictionary<string, string>();
            lstReportType3 = new Dictionary<string, string>();
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

    public class vwQualityReportSummaryELSV
    {
        public string Category { get; set; }
        public int PointsEarned { get; set; }
        public int TotalPoints { get; set; }
        public double ScorePercentage { get; set; }
        public string Details { get; set; }
        public string Defination { get; set; }
    }

    public class vwQualityReportAgentSummaryELSV
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
        public string TeamLead { get; set; }
        public string AgentName { get; set; }
        public string EmployeeId { get; set; }
        public int CF1_PointsEarned { get; set; }
        public int CF1_TotalPoints { get; set; }
        public double CF1_Percent { get; set; }
        public int CF2_PointsEarned { get; set; }
        public int CF2_TotalPoints { get; set; }
        public double CF2_Percent { get; set; }
        public int CF3_PointsEarned { get; set; }
        public int CF3_TotalPoints { get; set; }
        public double CF3_Percent { get; set; }
        public int CF4_PointsEarned { get; set; }
        public int CF4_TotalPoints { get; set; }
        public double CF4_Percent { get; set; }
        public int CF_PointsEarned { get; set; }
        public int CF_TotalPoints { get; set; }
        public int SF1_PointsEarned { get; set; }
        public int SF1_TotalPoints { get; set; }
        public double SF1_Percent { get; set; }
        public int SF2_PointsEarned { get; set; }
        public int SF2_TotalPoints { get; set; }
        public double SF2_Percent { get; set; }
        public int SF3_PointsEarned { get; set; }
        public int SF3_TotalPoints { get; set; }
        public double SF3_Percent { get; set; }
        public int SF_PointsEarned { get; set; }
        public int SF_TotalPoints { get; set; }
        public int BP1_PointsEarned { get; set; }
        public int BP1_TotalPoints { get; set; }
        public double BP1_Percent { get; set; }
        public int BP2_PointsEarned { get; set; }
        public int BP2_TotalPoints { get; set; }
        public double BP2_Percent { get; set; }
        public int BP3_PointsEarned { get; set; }
        public int BP3_TotalPoints { get; set; }
        public double BP3_Percent { get; set; }
        public int BP_PointsEarned { get; set; }
        public int BP_TotalPoints { get; set; }
        public int IC1_PointsEarned { get; set; }
        public int IC1_TotalPoints { get; set; }
        public double IC1_Percent { get; set; }
        public int IC2_PointsEarned { get; set; }
        public int IC2_TotalPoints { get; set; }
        public double IC2_Percent { get; set; }
        public int IC3_PointsEarned { get; set; }
        public int IC3_TotalPoints { get; set; }
        public double IC3_Percent { get; set; }
        public int IC4_PointsEarned { get; set; }
        public int IC4_TotalPoints { get; set; }
        public double IC4_Percent { get; set; }
        public int IC_PointsEarned { get; set; }
        public int IC_TotalPoints { get; set; }
        public int Overall_PointsEarned { get; set; }
        public int Overall_TotalPoints { get; set; }
        public double Overall_QCScore { get; set; }
        public string PassedOrFailed { get; set; }
        public double PassiveSurvey { get; set; }
        public double CSATScore { get; set; }
        public int NoOfPplOpportunity { get; set; }
        public string QCType { get; set; }
        public int NoOfSamples { get; set; }
        public string Remarks { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
