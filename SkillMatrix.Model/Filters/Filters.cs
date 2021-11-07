using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SkillMatrix.Model
{
    public enum Department
    {
        [Description("Customer Service")]
        CustomerService = 1,
        [Description("Online Service")]
        OnlineService = 2,
        [Description("Front Desk")]
        FrontDesk = 3,
        [Description("OR Support General")]
        ORSupportGeneral = 4,
        [Description("OR Support Institutional")]
        ORSupportInstitutional = 5,
        [Description("OR Support Payments")]
        ORSupportPayments = 6,
        [Description("Author Support")]
        AuthorSupport = 7,
        [Description("Order Management")]
        OrderManagement = 8,
        [Description("Comp Copy")]
        CompCopy = 9,
    }

    public enum TeamForReviews
    {
        Straive = 1,
        SpringerNature = 2
    }

    public enum QCReportType1
    {
        [Description("External")]
        External = 1,
        [Description("Internal")]
        Internal = 2,
        [Description("Ticket Status")]
        TicketStatus = 3,
        [Description("Team Location")]
        TeamLocation = 4,
    }

    public enum QCReportType2
    {
        [Description("Weekly Level Summary")]
        WeeklyLevelSummary = 1,
        [Description("Daily Sampling Percentage")]
        DailySamplingPercentage = 2,
        [Description("Team Lead Sampling")]
        TeamLeadSampling = 3
    }

    public enum ReportType
    {
        [Description("Daily")]
        Daily = 1,
        [Description("Weekly")]
        Weekly = 2,        
        [Description("Monthly")]
        Monthly = 3
    }
}
