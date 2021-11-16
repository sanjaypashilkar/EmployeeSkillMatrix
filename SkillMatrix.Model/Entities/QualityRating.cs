using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkillMatrix.Model
{
    public class QualityRating
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string AgentName { get; set; }
        public string EmployeeId { get; set; }
        public DateTime TaskCompletionDate { get; set; }
        public DateTime QADate { get; set; }
        public string Region { get; set; }
        public string TicketNumber { get; set; }
        public string TicketStatus { get; set; }
        public string RequestReason { get; set; }
        public string CustomerType { get; set; }
        public double ProcessAdheranceScore { get; set; }
        public double EmailHandlingScore { get; set; }
        public double ResolutionScore { get; set; }
        public double ToneScore { get; set; }
        public string Remarks { get; set; }
        public double TotalScore { get; set; }
        public double StraiveTotalScore { get; set; }
        public string QTPName { get; set; }
        public string QTPEmployeeId { get; set; }
        public double Variance { get; set; }
        public string OverallExperience { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
