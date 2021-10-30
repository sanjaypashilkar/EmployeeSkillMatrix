﻿using System;
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
        [Description("Fron Desk")]
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
        [Description("Com Copy")]
        ComCopy = 9,
    }

    public enum TeamForReviews
    {
        Straive = 1,
        SpringerNature = 2
    }

    public enum ReportType
    {
        [Description("External")]
        External = 1,
        [Description("Internal")]
        Internal = 2,
        [Description("Ticket Status")]
        TicketStatus = 3,
        [Description("Team Location")]
        TeamLocation = 4,
        [Description("Weekly Level Summary")]
        WeeklyLevelSummary = 5,
        [Description("Daily Sampling Percentage")]
        DailySamplingPercentage = 6,
        [Description("TeamLead Sampling")]
        TeamLeadSampling = 7
    }
}
