using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class TicketingToolFilter
    {
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PageNumber { get; set; }
    }
}
