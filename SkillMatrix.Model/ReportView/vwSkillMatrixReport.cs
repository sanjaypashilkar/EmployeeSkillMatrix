using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwSkillMatrixReport
    {
        public virtual List<EmployeeCompetencyLevel> EmployeeSkillMatrix { get; set; }
        public virtual List<EmployeeCompetencyLevel> PaginatedSkills { get; set; }
        public virtual SkillMatrixFilter SkillMatrixFilter { get; set; }
        public virtual Dictionary<string, string> lstYears { get; set; }
        public virtual Dictionary<string, string> lstQuarters { get; set; }
        public virtual Dictionary<string, string> lstTeams { get; set; }
        public virtual Dictionary<string, string> lstCompetencyLevel { get; set; }
        public virtual Dictionary<string, string> lstTenureLevel { get; set; }
        public virtual Pager Pager { get; set; }

        public vwSkillMatrixReport()
        {
            EmployeeSkillMatrix = new List<EmployeeCompetencyLevel>();
            PaginatedSkills = new List<EmployeeCompetencyLevel>();
            SkillMatrixFilter = new SkillMatrixFilter();
            lstYears = new Dictionary<string, string>();
            lstQuarters = new Dictionary<string, string>();
            lstTeams = new Dictionary<string, string>();
            lstCompetencyLevel = new Dictionary<string, string>();
            lstTenureLevel = new Dictionary<string, string>();
            Pager = new Pager();
        }
    }

    public class EmployeeCompetencyLevel
    {
        public virtual string AccountType { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual string Engagement { get; set; }
        public virtual DateTime DateHired { get; set; }
        public virtual int TenureYears { get; set; }
        public virtual int TenureMonths { get; set; }
        public virtual string Tenure { get; set; }
        public virtual DateTime CertificationDate { get; set; }
        public virtual string CertificationScore { get; set; }
        public virtual string CertificationLevel { get; set; }
        public virtual string CSATScore { get; set; }
        public virtual string CSATLevel { get; set; }
        public virtual string QCScore { get; set; }
        public virtual string QCLevel { get; set; }
        public virtual double OverallScore { get; set; }
        public virtual string CompetencyLevel { get; set; }
        public virtual string TenureLevel { get; set; }
        public virtual string TenurePlusCompetency { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

        //public int Year { get; set; }
        //public int Quarter { get; set; }
        //public string Team { get; set; }                
        //public int TenureYears { get; set; }
        //public int TenureMonths { get; set; }
        //public DateTime DateCompleted { get; set; }
        //[Column("ProficiencyReportProcessSpecific")]
        //public double ProcessSpecific_PR { get; set; }
        //[Column("ProficiencyReportStarAndOSvC")]
        //public double StarAndOSvC_PR { get; set; }
        //[Column("TimeSpentProcessSpecific")]
        //public string ProcessSpecific_TS { get; set; }
        //[Column("TimeSpentStarAndOSvC")]
        //public string StarAndOSvC_TS { get; set; }
        //public string TotalTimeSpent { get; set; }
        //[Column("QuestionsStatisticsReportProcessSpecific")]
        //public double ProcessSpecific_QSR { get; set; }
        //[Column("QuestionsStatisticsReportStarAndOSvC")]
        //public double StarAndOSvC_QSR { get; set; }
        //public double AvgQuestionsStatisticsReport { get; set; }
        //public double CertificationScore { get; set; }
        //public string CertificationLevel { get; set; }
        //public double CSATScore { get; set; }
        //public string CSATLevel { get; set; }
        //public double QCScore { get; set; }
        //public string QCLevel { get; set; }
        //public double ScoreSum { get; set; }
        //public int ScoreCount { get; set; }
        //public double OverallScore { get; set; }
        //public string CompetencyLevel { get; set; }
        //public string TenureLevel { get; set; }
        //public string TenurePlusCompetency { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}
