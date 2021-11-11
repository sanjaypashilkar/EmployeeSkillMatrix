using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwBusinessPartnerReport
    {
        public virtual List<vwBusinessPartnerStatusReport> BPStatusReport { get; set; }
        public virtual List<vwBusinessPartnerStatusReport> PaginatedStatusReport { get; set; }
        public virtual Dictionary<string, string> lstReportType { get; set; }
        public virtual BusinessPartnerFilter BusinessPartnerFilter { get; set; }
        public virtual Pager Pager { get; set; }

        public virtual int TotalTicketsChecked { get; set; }
        public virtual int TotalErrorCounts { get; set; }
        public virtual int TotalCorrectTickets { get; set; }
        public virtual double AvgAccuracyRate { get; set; }

        public vwBusinessPartnerReport()
        {
            BPStatusReport = new List<vwBusinessPartnerStatusReport>();
            PaginatedStatusReport = new List<vwBusinessPartnerStatusReport>();
            lstReportType = new Dictionary<string, string>();
            BusinessPartnerFilter = new BusinessPartnerFilter();
            Pager = new Pager();
        }
    }

    public class vwBusinessPartnerStatusReport
    {
        public string Engagement { get; set; }
        public int TicketsChecked { get; set; }
        public int CorrectTickets { get; set; }
        public int ErrorCounts { get; set; }
        public double AccuracyRate { get; set; }

        public List<vwBusinessPartnerStatusReportDaily> BPStatusReportDaily { get; set; }
        public List<vwBusinessPartnerStatusReportWeekly> BPStatusReportWeekly { get; set; }
        public double AvgAccuracyRate { get; set; }

        public vwBusinessPartnerStatusReport()
        {
            BPStatusReportDaily = new List<vwBusinessPartnerStatusReportDaily>();
            BPStatusReportWeekly = new List<vwBusinessPartnerStatusReportWeekly>();
        }
    }

    public class vwBusinessPartnerStatusReportDaily
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

    public class vwBusinessPartnerStatusReportWeekly
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
