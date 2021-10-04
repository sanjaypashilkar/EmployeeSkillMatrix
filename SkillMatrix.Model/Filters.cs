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
        FreshDesk = 4,
        AuthorSupport = 5,
        OrderManagement = 6,
        ComCopy =7,
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
        TeamLocation = 4
    }
}
