using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwTicketingToolReport
    {
        public virtual List<vwTicketingStatusReport> TicketingStatusReport { get; set; }
        public virtual List<vwTicketingStatusReport> PaginatedStatusReport { get; set; }
        public virtual Dictionary<string, string> lstReportType { get; set; }
        public virtual TicketingToolFilter TicketingFilter { get; set; }
        public virtual Pager Pager { get; set; }

        public virtual int TotalTicketsChecked { get; set; }
        public virtual int TotalErrorCounts { get; set; }
        public virtual int TotalCorrectTickets { get; set; }
        public virtual double AvgAccuracyRate { get; set; }

        public vwTicketingToolReport()
        {
            TicketingStatusReport = new List<vwTicketingStatusReport>();
            PaginatedStatusReport = new List<vwTicketingStatusReport>();
            lstReportType = new Dictionary<string, string>();
            TicketingFilter = new TicketingToolFilter();
            Pager = new Pager();
        }
    }

    public class vwTicketingStatusReport
    {
        public string Engagement { get; set; }
        public int TicketsChecked { get; set; }
        public int CorrectTickets { get; set; }
        public int ErrorCounts { get; set; }
        public double AccuracyRate { get; set; }

        public List<vwTicketingStatusReportDaily> TicketingStatusReportDaily { get; set; }
        public List<vwTicketingStatusReportWeekly> TicketingStatusReportWeekly { get; set; }
        public double AvgAccuracyRate { get; set; }

        public vwTicketingStatusReport()
        {
            TicketingStatusReportDaily = new List<vwTicketingStatusReportDaily>();
            TicketingStatusReportWeekly = new List<vwTicketingStatusReportWeekly>();
        }
    }

    public class vwTicketingStatusReportDaily
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int TicketsChecked { get; set; }
        public int CorrectTickets { get; set; }
        public int ErrorCounts { get; set; }
        public double AccuracyRate { get; set; }

        public int TotalTicketsChecked { get; set; }
        public int TotalCorrectTickets { get; set; }
        public int TotalErrorCounts { get; set; }
        public double AvgAccuracyRate { get; set; }
    }

    public class vwTicketingStatusReportWeekly
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int TicketsChecked { get; set; }
        public int CorrectTickets { get; set; }
        public int ErrorCounts { get; set; }
        public double AccuracyRate { get; set; }

        public int TotalTicketsChecked { get; set; }
        public int TotalCorrectTickets { get; set; }
        public int TotalErrorCounts { get; set; }
        public double AvgAccuracyRate { get; set; }
    }
}
