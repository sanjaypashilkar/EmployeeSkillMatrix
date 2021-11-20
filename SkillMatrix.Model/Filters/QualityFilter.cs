using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class QualityFilter
    {
        public string AccountType { get; set; }
        public string Department { get; set; }
        public string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TargetScore { get; set; }
        public int PageNumber { get; set; }
    }
}
