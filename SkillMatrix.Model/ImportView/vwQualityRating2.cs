using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwQualityRating2
    {
        public virtual string Department { get; set; }
        public virtual string Name { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual string Group { get; set; }
        public virtual string TeamLeader { get; set; }
        public virtual DateTime TaskCompletionDate { get; set; }
        public virtual DateTime AuditedDate { get; set; }
        public virtual string Process { get; set; }
        public virtual string ErrorType { get; set; }
        public virtual string CheckerRemarks { get; set; }
        public virtual string Modified { get; set; }
        public virtual string TicketNumber { get; set; }
        public virtual string Shift { get; set; }
        public virtual string Lines { get; set; }
        public virtual string IssueType { get; set; }
        public virtual string TLAnalysis { get; set; }
        public virtual string Level1Opportunity { get; set; }
        public virtual string Level2Opportunity { get; set; }
        public virtual string RootCause { get; set; }
        public virtual string CorrectiveAction { get; set; }
        public virtual string PreventiveAction { get; set; }
        public virtual string ProcessChange { get; set; }
        public virtual string EffectivenessVerification { get; set; }
        public virtual string AuditResult { get; set; }
        public virtual string DOIVerification { get; set; }
        public virtual string IsCorrect { get; set; }
        public virtual string IsError { get; set; }
        public virtual string WeekRange { get; set; }
        public virtual string Date { get; set; }
        public virtual string Volume { get; set; }
        public virtual string Counter { get; set; }
        public virtual string EmpIdDate { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
