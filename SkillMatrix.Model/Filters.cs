using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public enum Department
    {
        CustomerService = 1,        
        OnlineService = 2,
        FrontDesk = 3,
        ORSupportGeneral = 4,
        ORSupportInstitutional = 5,
        ORSupportPayments = 6,
        AuthorSupport = 7,
        OrderManagement = 8,
        ComCopy =9,
    }

    public enum TeamForReviews
    {
        Straive = 1,
        SpringerNature = 2
    }

    public enum ReportType
    {
        External = 1,
        Internal = 2,
        TicketStatus = 3,
        TeamLocation = 4,
        WeeklyLevelSummary = 5,
        DailySamplingPercentage = 6,
        TeamLeadSampling = 7
    }
}
