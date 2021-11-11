using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class BusinessPartnerFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReportType { get; set; }
        public int PageNumber { get; set; }
    }
}
