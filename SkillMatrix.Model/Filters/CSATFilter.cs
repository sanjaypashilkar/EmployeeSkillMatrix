using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class CSATFilter
    {
        public string AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PageNumber { get; set; }
    }
}
