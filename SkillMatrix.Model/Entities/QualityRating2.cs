using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkillMatrix.Model
{
    public class QualityRating2
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public string Group { get; set; }
        public string TeamLeader { get; set; }
        public DateTime TaskCompletionDate { get; set; }
        public DateTime AuditedDate { get; set; }
        public string Process { get; set; }
        public string ErrorType { get; set; }
        public string CheckerRemarks { get; set; }
        public string Modified { get; set; }
        public string TicketNumber { get; set; }
        public string Shift { get; set; }
        public int Lines { get; set; }
        public string IssueType { get; set; }
        public string TLAnalysis { get; set; }
        public string Level1Opportunity { get; set; }
        public string Level2Opportunity { get; set; }
        public string RootCause { get; set; }
        public string CorrectiveAction { get; set; }
        public string PreventiveAction { get; set; }
        public string ProcessChange { get; set; }
        public string EffectivenessVerification { get; set; }
        public string AuditResult { get; set; }
        public string DOIVerification { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsError { get; set; }
        public string WeekRange { get; set; }
        public string Date { get; set; }
        public double Volume { get; set; }
        public int Counter { get; set; }
        public string EmpIdDate { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
