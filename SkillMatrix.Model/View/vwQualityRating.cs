using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwQualityRating
    {
        public virtual string Department { get; set; }
        public virtual string Team { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual DateTime TaskCompletionDate { get; set; }
        public virtual DateTime QADate { get; set; }
        public virtual string Region { get; set; }
        public virtual string TicketNumber { get; set; }
        public virtual string TicketStatus { get; set; }
        public virtual string RequestReason { get; set; }
        public virtual string CustomerType { get; set; }
        public virtual string ProcessAdheranceScore { get; set; }
        public virtual string EmailHandlingScore { get; set; }
        public virtual string ResolutionScore { get; set; }
        public virtual string ToneScore { get; set; }
        public virtual string Remarks { get; set; }
        public virtual string TotalScore { get; set; }
        public virtual string StraiveTotalScore { get; set; }
        public virtual string QTPName { get; set; }
        public virtual string QTPEmployeeId { get; set; }
        public virtual string Variance { get; set; }
        public virtual string OverallExperience { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }

    public class vwImportAndSaveQualityRating
    {
        public virtual List<vwQualityRating> QualityRatings { get; set; }
        public virtual List<vwQualityRating2> QualityRatings2 { get; set; }
        public virtual Dictionary<string, string> lstDepartments { get; set; }
        public virtual QualityFilter QualityFilter { get; set; }

        public vwImportAndSaveQualityRating()
        {
            QualityRatings = new List<vwQualityRating>();
            QualityRatings2 = new List<vwQualityRating2>();
            lstDepartments = new Dictionary<string, string>();
            QualityFilter = new QualityFilter();
        }
    }
}
