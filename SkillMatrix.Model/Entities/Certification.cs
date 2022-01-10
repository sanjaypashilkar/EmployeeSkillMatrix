using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class Certification
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public string AgentName { get; set; }
        public string EmployeeId { get; set; }
        public double? OSVC_Score { get; set; }
        public double? OA_Score { get; set; }
        public double? EM_Score { get; set; }
        public double EarnedScore { get; set; }
        public double TotalScore { get; set; }
        public DateTime CertificationDate { get; set; }        
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
