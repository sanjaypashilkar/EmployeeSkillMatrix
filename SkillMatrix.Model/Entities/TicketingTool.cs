using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkillMatrix.Model
{
    public class TicketingTool
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int TicketNumber { get; set; }
        public string Team { get; set; }
        public string Comment { get; set; }
        public string AdditionalComments { get; set; }
        public string ConcernedRep { get; set; }
        public string Remarks { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
