using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwTicketingTool
    {
        public virtual DateTime Date { get; set; }
        public virtual string Status { get; set; }
        public virtual int TicketNumber { get; set; }
        public virtual string Team { get; set; }
        public virtual string Comment { get; set; }
        public virtual string AdditionalComments { get; set; }
        public virtual string ConcernedRep { get; set; }
        public virtual string Remarks { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }

    public class vwImportAndSaveTicketingTool
    {
        public virtual List<vwTicketingTool> TicketingTools { get; set; }
        public virtual TicketingToolFilter TicketingToolFilter { get; set; }

        public vwImportAndSaveTicketingTool()
        {
            TicketingTools = new List<vwTicketingTool>();
            TicketingToolFilter = new TicketingToolFilter();
        }
    }
}
