using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillMatrix.Model
{
    public class EmployeeSkillMatrix
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public string Team { get; set; }
        public string Name { get; set; }
        public DateTime DateHired { get; set; }
        public int TenureYears { get; set; }
        public int TenureMonths { get; set; }
        public DateTime DateCompleted { get; set; }
        [Column("ProficiencyReportProcessSpecific")]
        public double ProcessSpecific_PR { get; set; }
        [Column("ProficiencyReportStarAndOSvC")]
        public double StarAndOSvC_PR { get; set; }
        [Column("TimeSpentProcessSpecific")]
        public string ProcessSpecific_TS { get; set; }
        [Column("TimeSpentStarAndOSvC")]
        public string StarAndOSvC_TS { get; set; }
        public string TotalTimeSpent { get; set; }
        [Column("QuestionsStatisticsReportProcessSpecific")]
        public double ProcessSpecific_QSR { get; set; }
        [Column("QuestionsStatisticsReportStarAndOSvC")]
        public double StarAndOSvC_QSR { get; set; }
        public double AvgQuestionsStatisticsReport { get; set; }
        public double CertificationScore { get; set; }
        public string CertificationLevel { get; set; }
        public double CSATScore { get; set; }
        public string CSATLevel { get; set; }
        public double QCScore { get; set; }
        public string QCLevel { get; set; }
        public double ScoreSum { get; set; }
        public int ScoreCount { get; set; }
        public double OverallScore { get; set; }
        public string CompetencyLevel { get; set; }
        public string TenureLevel { get; set; }
        public string TenurePlusCompetency { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public EmployeeSkillMatrix()
        {
            Id = 0;
            Year = 0;
            Quarter = 0;
            Team = string.Empty;
            Name = string.Empty;
            DateHired = new DateTime();
            TenureYears = 0;
            TenureMonths = 0;
            DateCompleted = new DateTime();
            ProcessSpecific_PR = 0;
            StarAndOSvC_PR = 0;
            ProcessSpecific_TS = string.Empty;
            StarAndOSvC_TS = string.Empty;
            TotalTimeSpent = string.Empty;
            ProcessSpecific_QSR = 0;
            StarAndOSvC_QSR = 0;
            AvgQuestionsStatisticsReport = 0;
            CertificationScore = 0;
            CertificationLevel = string.Empty;
            CSATScore = 0;
            CSATLevel = string.Empty;
            QCScore = 0;
            QCLevel = string.Empty;
            ScoreSum = 0;
            ScoreCount = 0;
            OverallScore = 0;
            CompetencyLevel = string.Empty;
            TenureLevel = string.Empty;
            TenurePlusCompetency = string.Empty;
            CreatedDate = new DateTime();
            UpdatedDate = new DateTime();
        }

        public EmployeeSkillMatrix(string _team, string _name, DateTime _dateHired, DateTime _createdDate)
        {
            Team = _team;
            Name = _name;
            DateHired = _dateHired;
            CreatedDate = _createdDate;
        }
    }    
}
