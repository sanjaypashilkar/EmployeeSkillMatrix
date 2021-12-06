using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class CSAT
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public string Month { get; set; }
        public DateTime Date { get; set; }
        public string AgentName { get; set; }
        public string EmployeeId { get; set; }
        public double CSATScore { get; set; }
        public double Effort { get; set; }
        public double FTR { get; set; }
        public double ComprNAccurate { get; set; }
        public double ProfessionalNHelpful { get; set; }
        public double Timely { get; set; }
        public int NoOfRedFlags { get; set; }
        public int NoOfSurveys { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
