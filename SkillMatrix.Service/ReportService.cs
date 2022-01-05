using ClosedXML.Excel;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SkillMatrix.Service
{
    public class ReportService : IReportService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }
        const int pageSize = 10;

        public ReportService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public vwSkillReport GetSkillMatrixReport(SkillMatrixFilter filter = null)
        {
            if (filter == null)
            {
                filter = new SkillMatrixFilter();
                int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
                int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
                int currentYear = DateTime.Today.Year;
                int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
                filter.Year = selectedYear;
                filter.Quarter = selectedQuarter;
                filter.PageNumber = 1;
            }

            vwSkillReport report = new vwSkillReport();
            report.SkillMatrixFilter = filter;
            report.lstYears = mtdGetYears();
            report.lstQuarters = mtdGetQuarters();
            report.lstTeams = mtdGetTeams(filter.Year, filter.Quarter);
            report.lstCompetencyLevel = mtdGetCompetencyLevel();
            report.lstTenureLevel = mtdGetTenureLevel();
            var skillMatrices = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(filter.Year, filter.Quarter).ToList();            
            if(!string.IsNullOrEmpty(filter.Team))
            {
                skillMatrices = skillMatrices.Where(s => s.Team.ToLower() == filter.Team.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.CompetencyLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.CompetencyLevel.ToLower() == filter.CompetencyLevel.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.TenureLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.TenureLevel.ToLower() == filter.TenureLevel.ToLower()).ToList();
            }
            if (skillMatrices.Count > 0)
            {
                var sortedList = skillMatrices.OrderBy(s => s.Team).ThenBy(s => s.Name).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;
                
                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedSkills = paginatedData;
                report.SkillMatrix = sortedList;
            }
            return report;
        }

        public Dictionary<string,string> mtdGetYears()
        {
            var selectList = Enumerable.Range(DateTime.Now.AddYears(-10).Year, 11).Reverse().Select(i => new { key = i.ToString(), value = i.ToString()}).ToDictionary(x=> x.key, x=>x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetQuarters()
        {
            var selectList = Enumerable.Range(1, 4).Select(i => new { key = i.ToString(), value = i.ToString()}).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetTeams(int year, int quarter)
        {
            var skillMatrix = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(year, quarter);
            var teams = skillMatrix.Select(i => i.Team).ToList().Distinct();
            var selectList = teams.Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetSkillMatrix1Teams(List<EmployeeCompetencyLevel> skillMatrix)
        {
            var teams = skillMatrix.Select(i => i.Engagement).ToList().Distinct();
            var selectList = teams.Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetCompetencyLevel()
        {
            var selectList = _skillMatrixRepository.GetCompetencyLevelScoring().Select(i => new { key = i.Level.ToString(), value = i.Level.ToString() }).ToDictionary(x => x.key, x => x.value);       
            return selectList;
        }

        public Dictionary<string, string> mtdGetTenureLevel()
        {
            var selectList = _skillMatrixRepository.GetTenureLevel().Select(i => new { key = i.Level.ToString(), value = i.Level.ToString() }).ToDictionary(x => x.key, x => x.value);           
            return selectList;
        }

        public Dictionary<string, string> mtdGetAccountTypes()
        {
            var accounts = Helper.GetEnumValuesAndDescriptions<AccountType>();
            var selectList = accounts.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetDepartments()
        {
            var departments = Helper.GetEnumValuesAndDescriptions<Department>();
            var selectList = departments.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetQCReportTypes1()
        {
            var reportTypes = Helper.GetEnumValuesAndDescriptions<QCReportType1>();
            var selectList = reportTypes.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetQCReportTypes2()
        {
            var reportTypes = Helper.GetEnumValuesAndDescriptions<QCReportType2>();
            var selectList = reportTypes.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetQCReportTypes3()
        {
            var reportTypes = Helper.GetEnumValuesAndDescriptions<QCReportType3>();
            var selectList = reportTypes.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetReportTypes()
        {
            var reportTypes = Helper.GetEnumValuesAndDescriptions<ReportType>();
            var selectList = reportTypes.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        #region QUALITY REPORTS

        public vwQualityReport GetQualityReport(QualityFilter filter = null)
        {
            if (filter == null)
            {
                filter = new QualityFilter();
                filter.StartDate = DateTime.Today.AddDays(-7).Date;
                filter.EndDate = DateTime.Today.Date;
                //filter.StartDate = new DateTime(2021, 08, 02).Date;
                //filter.EndDate = new DateTime(2021, 09, 05).Date;
                filter.AccountType = AccountType.SpringerNature.ToString();
                filter.Department = Department.CustomerService.ToString();
                filter.ReportType = QCReportType1.External.ToString();
                filter.TargetScore = 85;
                filter.PassingScore = 92;
                filter.PageNumber = 1;
            }

            vwQualityReport report = new vwQualityReport();
            report.QualityFilter = filter;
            report.lstAccountTypes = mtdGetAccountTypes();
            report.lstDepartments = mtdGetDepartments();            
            report.lstReportType1 = mtdGetQCReportTypes1();
            report.lstReportType2 = mtdGetQCReportTypes2();
            report.lstReportType3 = mtdGetQCReportTypes3();

            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate(filter.StartDate, filter.EndDate).ToList();            
            if (!string.IsNullOrEmpty(filter.Department))
            {
                qualityRatings = qualityRatings.Where(s => s.Department.ToLower() == filter.Department.ToLower()).ToList();
            }
            if (filter.ReportType == QCReportType1.Internal.ToString() || filter.ReportType == QCReportType1.External.ToString())
            {
                qualityRatings = qualityRatings.Where(s => s.CustomerType.ToLower() == filter.ReportType.ToLower()).ToList();
            }
            if (qualityRatings.Count > 0)
            {
                List<vwQualityReportSummary> reportSummaries = new List<vwQualityReportSummary>();
                if(filter.ReportType == QCReportType1.Internal.ToString() || filter.ReportType == QCReportType1.External.ToString())
                {
                    reportSummaries = GetCustomerTypeReport(qualityRatings, filter.ReportType, filter.TargetScore);
                }
                else if(filter.ReportType == QCReportType1.TicketStatus.ToString())
                {
                    reportSummaries = GetTicketStatusReport(qualityRatings, filter.TargetScore);
                }
                else
                {
                    reportSummaries = GetTeamLocationReport(qualityRatings, filter.TargetScore);
                }
                var sortedList = reportSummaries.OrderByDescending(s => s.TicketsChecked).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedSummary = paginatedData;
                report.QualitySummary = sortedList;
            }
            return report;
        }

        public vwQualityReport GetQualityReport2(QualityFilter filter = null)
        {
            if (filter == null)
            {
                filter = new QualityFilter();
                filter.StartDate = DateTime.Today.AddDays(-7).Date;
                filter.EndDate = DateTime.Today.Date;
                //filter.StartDate = new DateTime(2021, 08, 02).Date;
                //filter.EndDate = new DateTime(2021, 09, 05).Date;
                filter.AccountType = AccountType.SpringerNature.ToString();
                filter.Department = Department.OrderManagement.ToString();
                filter.ReportType = QCReportType2.WeeklyLevelSummary.ToString();
                filter.TargetScore = 85;
                filter.PageNumber = 1;
            }

            vwQualityReport report = new vwQualityReport();
            report.QualityFilter = filter;
            report.lstDepartments = mtdGetDepartments();
            report.lstReportType1 = mtdGetQCReportTypes1();
            report.lstReportType2 = mtdGetQCReportTypes2();
            report.lstReportType3 = mtdGetQCReportTypes3();

            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate2(filter.StartDate, filter.EndDate).ToList();            
            qualityRatings = qualityRatings.Where(s => s.Department.ToLower() == filter.Department.ToLower()).ToList();            
            if (qualityRatings.Count > 0)
            {
                if(filter.ReportType == QCReportType2.WeeklyLevelSummary.ToString())
                {
                    var weeklyAccuracyReport = GetWeeklyAccuracyReport(qualityRatings, filter.StartDate, filter.EndDate);
                    var sortedList = weeklyAccuracyReport.OrderBy(s => s.AgentName).ToList();
                    if (filter.PageNumber < 1)
                        filter.PageNumber = 1;

                    int rescCount = sortedList.Count();
                    int recSkip = (filter.PageNumber - 1) * pageSize;
                    var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                    report.Pager = pager;

                    var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                    report.PaginatedWeeklyReport = paginatedData;
                    report.WeeklyQualityReport = sortedList;
                }
                else if (filter.ReportType == QCReportType2.DailySamplingPercentage.ToString())
                {
                    var dailySamplingReport = GetDailySamplingPercentReport(qualityRatings, filter.StartDate, filter.EndDate);
                    var sortedList = dailySamplingReport.OrderBy(s => s.TeamLead).ThenBy(s=>s.AgentName).ToList();
                    if (filter.PageNumber < 1)
                        filter.PageNumber = 1;

                    int rescCount = sortedList.Count();
                    int recSkip = (filter.PageNumber - 1) * pageSize;
                    var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                    report.Pager = pager;

                    var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                    report.PaginatedDailyReport = paginatedData;
                    report.DailyQualityReport = sortedList;
                }
                else
                {
                    var teamLeadSamplingReport = GetTeamLeadSamplingPercentReport(qualityRatings, filter.StartDate, filter.EndDate);
                    var sortedList = teamLeadSamplingReport.OrderBy(s => s.TeamLead).ToList();
                    if (filter.PageNumber < 1)
                        filter.PageNumber = 1;

                    int rescCount = sortedList.Count();
                    int recSkip = (filter.PageNumber - 1) * pageSize;
                    var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                    report.Pager = pager;

                    var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                    report.PaginatedDailyReport = paginatedData;
                    report.DailyQualityReport = sortedList;
                }
            }
            return report;
        }

        public vwQualityReport GetQualityReport3(QualityFilter filter = null)
        {
            if (filter == null)
            {
                filter = new QualityFilter();
                filter.AccountType = AccountType.Elsevier.ToString();
                filter.StartDate = DateTime.Today.AddDays(-7).Date;
                filter.EndDate = DateTime.Today.Date;
                filter.ReportType = QCReportType3.CategorySummary.ToString();
                filter.PassingScore = 92;
                filter.PageNumber = 1;
            }

            vwQualityReport report = new vwQualityReport();
            report.QualityFilter = filter;
            report.lstDepartments = mtdGetDepartments();
            report.lstReportType1 = mtdGetQCReportTypes1();
            report.lstReportType2 = mtdGetQCReportTypes2();
            report.lstReportType3 = mtdGetQCReportTypes3();

            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate3(filter.StartDate, filter.EndDate).ToList();
            if (qualityRatings.Count > 0)
            {
                if(filter.ReportType == QCReportType3.AgentSummary.ToString())
                {
                    var agentSummaryELSV = new List<vwQualityReportAgentSummaryELSV>();
                    agentSummaryELSV = GetAgentSummaryReportELSV(qualityRatings, filter.PassingScore);
                    var sortedList = agentSummaryELSV.OrderBy(s => s.TeamLead).ThenBy(s=>s.AgentName).ToList();
                    if (filter.PageNumber < 1)
                        filter.PageNumber = 1;

                    int rescCount = sortedList.Count();
                    int recSkip = (filter.PageNumber - 1) * pageSize;
                    var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                    report.Pager = pager;

                    var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                    report.PaginatedAgentSummaryELSV = paginatedData;
                    report.AgentSummaryELSV = sortedList;
                }
                else
                {
                    var categorySummaryELSV = new List<vwQualityReportSummaryELSV>();
                    if (filter.ReportType == QCReportType3.CategorySummary.ToString())
                    {
                        categorySummaryELSV = GetCategorySummaryReportELSV(qualityRatings);
                    }
                    else if (filter.ReportType == QCReportType3.CodewiseSummary.ToString())
                    {
                        categorySummaryELSV = GetCodeSummaryReportELSV(qualityRatings);
                    }

                    var sortedList = categorySummaryELSV.ToList();
                    if (filter.PageNumber < 1)
                        filter.PageNumber = 1;

                    int rescCount = sortedList.Count();
                    int recSkip = (filter.PageNumber - 1) * pageSize;
                    var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                    report.Pager = pager;

                    var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                    report.PaginatedCategorySummaryELSV = paginatedData;
                    report.CategorySummaryELSV = sortedList;
                }                
            }
            return report;
        }

        #region PRIVATE METHODS

        private List<vwQualityReportSummary> GetCustomerTypeReport(List<QualityRating> qualityRatings, string customerType, int targetScore)
        {
            List<vwQualityReportSummary> reportSummaries = new List<vwQualityReportSummary>();
            var straiveQualityRating = qualityRatings.Where(q => q.Team.ToLower() == TeamForReviews.Straive.ToString().ToLower()).ToList();
            double customerTypeCount = straiveQualityRating.Count();
            double passedTickets = straiveQualityRating.Where(q => q.TotalScore >= targetScore).Count();
            var ticketsPassedScore = Math.Round((passedTickets / customerTypeCount) * 100, 2);
            double customerTypeAvgSPIScore = 0;
            if (straiveQualityRating.Count > 0)
            {
                customerTypeAvgSPIScore = Math.Round(straiveQualityRating.Average(s => s.TotalScore), 2);
            }
            var snQualityRating = qualityRatings.Where(q => q.Team.ToLower() == TeamForReviews.SpringerNature.ToString().ToLower()).ToList();
            double customerTypeAvgSNScore = 0;
            if (snQualityRating.Count > 0)
            {
                customerTypeAvgSNScore = Math.Round(snQualityRating.Average(s => s.TotalScore), 2);
            }
            vwQualityReportSummary categorySummary = new vwQualityReportSummary();
            categorySummary.Category = customerType;
            categorySummary.TicketsChecked = Convert.ToInt32(customerTypeCount);
            categorySummary.TicketsPassed = ticketsPassedScore;
            categorySummary.AvgSPIScore = customerTypeAvgSPIScore;
            categorySummary.AvgSNCSScore = customerTypeAvgSNScore;
            reportSummaries.Add(categorySummary);

            var requestReasons = qualityRatings.Select(q => q.RequestReason).Distinct().OrderBy(q => q).ToList();            
            foreach (var reason in requestReasons)
            {
                var reasonQualityRating = straiveQualityRating.Where(s => s.RequestReason.ToLower() == reason.ToLower()).ToList();
                double reasonCount = reasonQualityRating.Count();
                double reasonPassedTickets = reasonQualityRating.Where(q => q.TotalScore > targetScore).Count();
                var reasonPassedScore = Math.Round((reasonPassedTickets / reasonCount) * 100, 2);
                var reasonAvgSPIScore = Math.Round(reasonQualityRating.Average(r => r.TotalScore), 2);
                var reasonSNQualityRating = snQualityRating.Where(s => s.RequestReason.ToLower() == reason.ToLower()).ToList();
                double reasonAvgSNScore = 0;
                if (reasonSNQualityRating.Count > 0)
                {
                    reasonAvgSNScore = Math.Round(reasonSNQualityRating.Average(s => s.TotalScore), 2);
                }
                vwQualityReportSummary reasonSummary = new vwQualityReportSummary();
                reasonSummary.Category = reason;
                reasonSummary.TicketsChecked = Convert.ToInt32(reasonCount);
                reasonSummary.TicketsPassed = reasonPassedScore;
                reasonSummary.AvgSPIScore = reasonAvgSPIScore;
                reasonSummary.AvgSNCSScore = reasonAvgSNScore;
                reportSummaries.Add(reasonSummary);
            }
            return reportSummaries;
        }
        private List<vwQualityReportSummary> GetTicketStatusReport(List<QualityRating> qualityRatings, int targetScore)
        {
            List<vwQualityReportSummary> reportSummaries = new List<vwQualityReportSummary>();
            var straiveQualityRating = qualityRatings.Where(q => q.Team.ToLower() == TeamForReviews.Straive.ToString().ToLower()).ToList();
            var snQualityRating = qualityRatings.Where(q => q.Team.ToLower() == TeamForReviews.SpringerNature.ToString().ToLower()).ToList();           
            var ticketStatus = qualityRatings.Select(q => q.TicketStatus).Distinct().OrderBy(q => q).ToList();
            foreach (var status in ticketStatus)
            {
                var statusQualityRating = straiveQualityRating.Where(s => s.TicketStatus.ToLower() == status.ToLower()).ToList();
                double statusCount = statusQualityRating.Count();
                double statusPassedTickets = statusQualityRating.Where(q => q.TotalScore > targetScore).Count();
                var statusPassedScore = Math.Round((statusPassedTickets / statusCount) * 100, 2);
                var statusAvgSPIScore = Math.Round(statusQualityRating.Average(r => r.TotalScore), 2);
                var statusSNQualityRating = snQualityRating.Where(s => s.TicketStatus.ToLower() == status.ToLower()).ToList();
                double statusAvgSNScore = 0;
                if (statusSNQualityRating.Count > 0)
                {
                    statusAvgSNScore = Math.Round(statusSNQualityRating.Average(s => s.TotalScore), 2);
                }
                vwQualityReportSummary reasonSummary = new vwQualityReportSummary();
                reasonSummary.Category = status;
                reasonSummary.TicketsChecked = Convert.ToInt32(statusCount);
                reasonSummary.TicketsPassed = statusPassedScore;
                reasonSummary.AvgSPIScore = statusAvgSPIScore;
                reasonSummary.AvgSNCSScore = statusAvgSNScore;
                reportSummaries.Add(reasonSummary);
            }
            return reportSummaries;
        }
        private List<vwQualityReportSummary> GetTeamLocationReport(List<QualityRating> qualityRatings, int targetScore)
        {
            List<vwQualityReportSummary> reportSummaries = new List<vwQualityReportSummary>();
            var snQualityRating = qualityRatings.Where(q => q.Team.ToLower() == TeamForReviews.SpringerNature.ToString().ToLower()).ToList();
            var teamLocations = snQualityRating.Select(q => q.QTPName).Distinct().OrderBy(q => q).ToList();
            foreach (var team in teamLocations)
            {
                var teamQualityRating = snQualityRating.Where(s => s.QTPName.ToLower() == team.ToLower()).ToList();
                double teamCount = teamQualityRating.Count();
                double teamPassedTickets = teamQualityRating.Where(q => q.TotalScore > targetScore).Count();
                var teamPassedScore = Math.Round((teamPassedTickets / teamCount) * 100, 2);
                var teamAvgSPIScore = Math.Round(teamQualityRating.Average(r => r.StraiveTotalScore), 2);
                double teamAvgSNScore = 0;
                if (teamQualityRating.Count > 0)
                {
                    teamAvgSNScore = Math.Round(teamQualityRating.Average(s => s.TotalScore), 2);
                }
                vwQualityReportSummary reasonSummary = new vwQualityReportSummary();
                reasonSummary.Category = team;
                reasonSummary.TicketsChecked = Convert.ToInt32(teamCount);
                reasonSummary.TicketsPassed = teamPassedScore;
                reasonSummary.AvgSPIScore = teamAvgSPIScore;
                reasonSummary.AvgSNCSScore = teamAvgSNScore;
                reportSummaries.Add(reasonSummary);
            }
            return reportSummaries;
        }
        private List<vwQualityReportWeekly> GetWeeklyAccuracyReport(List<QualityRating2> qualityRatings, DateTime startDate, DateTime endDate)
        {
            List<vwQualityReportWeekly> weeklyAccuracyReport = new List<vwQualityReportWeekly>();
            var weeks = GetWeekRanges(startDate, endDate);
            double totalAvgMTD = 0;
            int avgMTDCounter = 0;

            var agentNames = qualityRatings.Select(q => q.Name).Distinct().OrderBy(q => q).ToList();
            foreach (var agent in agentNames)
            {
                vwQualityReportWeekly agentWeeklyAccuracy = new vwQualityReportWeekly();
                agentWeeklyAccuracy.AgentName = agent;
                double totalMTD = 0;
                int counter = 0;
                var agentQuality = qualityRatings.Where(r => r.Name.ToLowerInvariant() == agent.ToLowerInvariant()).ToList();
                foreach (var week in weeks)
                {
                    var weekRangeQuality = agentQuality.Where(r => r.TaskCompletionDate >= week.StartDate && r.TaskCompletionDate <= week.EndDate).ToList();
                    int totalCount = weekRangeQuality.Count();
                    int correctCount = weekRangeQuality.Where(q => q.ErrorType.ToLowerInvariant() == "correct").ToList().Count();
                    double accuracyRate = 0;
                    if (correctCount != 0 && totalCount != 0)
                    {
                        accuracyRate = Math.Round(((double)correctCount / totalCount) * 100, 2);
                        counter += 1;
                        totalMTD += accuracyRate;
                    }

                    agentWeeklyAccuracy.WeeklyAccuracy.Add(new WeeklyAccuracy
                    {
                        Week = week.Week,
                        StartDate = week.StartDate,
                        EndDate = week.EndDate,
                        AccuracyRate = accuracyRate
                    });
                }
                var avgMTD = Math.Round(((double)totalMTD / counter), 2);
                if(avgMTD>0)
                {
                    totalAvgMTD += avgMTD;
                    avgMTDCounter += 1; 
                }                
                agentWeeklyAccuracy.AverageMTD = avgMTD;
                weeklyAccuracyReport.Add(agentWeeklyAccuracy);
            }
            double avgOfAvgMTD = Math.Round(((double)totalAvgMTD / avgMTDCounter), 2);
            foreach (var week in weeks)
            {
                var counter = 0;
                double totalAccuracy = 0;
                var weekAccuracyData = weeklyAccuracyReport.Select(a => a.WeeklyAccuracy.Where(w=>w.Week == week.Week).FirstOrDefault()).ToList();
                foreach(var weekAccuracy in weekAccuracyData)
                {
                    if(weekAccuracy.AccuracyRate!=0)
                    {
                        counter += 1;
                        totalAccuracy += weekAccuracy.AccuracyRate;
                    }
                }
                week.AverageMTD = Math.Round(((double)totalAccuracy / counter), 2);
                weeklyAccuracyReport.ForEach(a =>
                        {
                            a.WeeklyAccuracy.Where(w => w.Week == week.Week).FirstOrDefault().AverageMTD = week.AverageMTD;
                            a.AvgOfAvgMTD = avgOfAvgMTD;
                        });
            }
            return weeklyAccuracyReport;
        }
        private List<vwQualityReportDaily> GetDailySamplingPercentReport(List<QualityRating2> qualityRatings, DateTime startDate, DateTime endDate)
        {
            List<vwQualityReportDaily> dailySamplingReport = new List<vwQualityReportDaily>();
            var dailySamplings = GetDailySampling(startDate, endDate);
            double totalAvgSampling = 0;
            int avgSamplingCounter = 0;
            var agentNames = qualityRatings.Select(q => q.Name).Distinct().OrderBy(q => q).ToList();
            foreach (var agent in agentNames)
            {
                vwQualityReportDaily agentDailySampling = new vwQualityReportDaily();
                agentDailySampling.AgentName = agent;
                double totalSampling = 0;
                int samplingCounter = 0;
                var agentQuality = qualityRatings.Where(r => r.Name.ToLowerInvariant() == agent.ToLowerInvariant()).ToList();
                agentDailySampling.TeamLead = agentQuality.Count() > 0 ? agentQuality[0].TeamLeader : string.Empty;
                foreach (var date in dailySamplings)
                {
                    var dailyQuality = agentQuality.Where(r => r.TaskCompletionDate.Date == date.Date.Date).ToList();
                    int totalCount = dailyQuality.Count();
                    int line = totalCount > 0 ? dailyQuality.FirstOrDefault().Lines : 0;
                    double sampling = 0;
                    if (line != 0 && totalCount != 0)
                    {
                        sampling = Math.Round(((double)totalCount / line) * 100, 2);
                        totalSampling += sampling;
                        samplingCounter += 1;
                    }
                    agentDailySampling.DailySampling.Add(new DailySampling
                    {
                        Date = date.Date,
                        DateString = date.DateString,
                        SamplePercentage = sampling
                    });
                }
                var avgSampling = Math.Round(((double)totalSampling / samplingCounter), 2);
                if (avgSampling > 0)
                {
                    totalAvgSampling += avgSampling;
                    avgSamplingCounter += 1;
                }
                agentDailySampling.AvgSampling = avgSampling;
                dailySamplingReport.Add(agentDailySampling);
            }
            double avgOfAvgSampling = Math.Round(((double)totalAvgSampling / avgSamplingCounter), 2);
            foreach (var dailySample in dailySamplings)
            {
                var counter = 0;
                double totalSampling = 0;
                var dailySampleData = dailySamplingReport.Select(s => s.DailySampling.Where(d => d.Date == dailySample.Date).FirstOrDefault()).ToList();
                foreach (var sample in dailySampleData)
                {
                    if (sample.SamplePercentage != 0)
                    {
                        counter += 1;
                        totalSampling += sample.SamplePercentage;
                    }
                }
                dailySample.AvgSamplePercentage = Math.Round(((double)totalSampling / counter), 2);
                dailySamplingReport.ForEach(a =>
                {
                    a.DailySampling.Where(w => w.Date == dailySample.Date).FirstOrDefault().AvgSamplePercentage = dailySample.AvgSamplePercentage;
                    a.AvgOfAvgSampling = avgOfAvgSampling;
                });
            }
            return dailySamplingReport;
        }
        private List<vwQualityReportDaily> GetTeamLeadSamplingPercentReport(List<QualityRating2> qualityRatings, DateTime startDate, DateTime endDate)
        {
            List<vwQualityReportDaily> teamleadSamplingReport = new List<vwQualityReportDaily>();
            var dailySamplingReport = GetDailySamplingPercentReport(qualityRatings, startDate, endDate);
            if(dailySamplingReport.Count>0)
            {
                double totalAvgSampling = 0;
                int avgSamplingCounter = 0;
                var teamLeads = qualityRatings.Select(q => q.TeamLeader).Distinct().OrderBy(q => q).ToList();
                var sampleDates = dailySamplingReport[0].DailySampling.Select(d => d.Date).ToList();
                foreach (var teamLead in teamLeads)
                {
                    vwQualityReportDaily teamLeadReport = new vwQualityReportDaily();
                    teamLeadReport.TeamLead = teamLead;
                    double totalSampling = 0;
                    int samplingCounter = 0;
                    var teamleadSamples = dailySamplingReport.Where(d => d.TeamLead == teamLead).ToList();
                    foreach (var sampling in teamleadSamples[0].DailySampling)
                    {
                        DailySampling teamLeadSample = new DailySampling();
                        teamLeadSample.Date = sampling.Date;
                        teamLeadSample.DateString = sampling.DateString;

                        var teamLeadDateSampling = teamleadSamples.Select(t => t.DailySampling.Where(d => d.DateString == sampling.DateString).FirstOrDefault()).ToList();
                        int teamLeadSampleCount = teamLeadDateSampling.Where(d => d.SamplePercentage > 0).Count();
                        var teamLeadSampleSum = teamLeadDateSampling.Where(d => d.SamplePercentage > 0).Sum(s => s.SamplePercentage);
                        double teamLeadsamplingAverage = 0;
                        if (teamLeadSampleCount>0)
                        {
                            teamLeadsamplingAverage = Math.Round((teamLeadSampleSum / teamLeadSampleCount),2);
                            totalSampling += teamLeadsamplingAverage;
                            samplingCounter += 1;
                        }
                        teamLeadSample.SamplePercentage = teamLeadsamplingAverage;
                        teamLeadReport.DailySampling.Add(teamLeadSample);
                    }
                    if(samplingCounter > 0)
                    {
                        var avgSampling = Math.Round((totalSampling / samplingCounter),2);
                        teamLeadReport.AvgSampling = avgSampling;
                        totalAvgSampling += avgSampling;
                        avgSamplingCounter += 1;
                    }                    
                    teamleadSamplingReport.Add(teamLeadReport);
                }
                var avgOfAvgSample = Math.Round(((double)totalAvgSampling / avgSamplingCounter), 2);
                foreach (var sampling in dailySamplingReport[0].DailySampling)
                {
                    var counter = 0;
                    double totalDateSampling = 0;
                    var temLeadSampleData = teamleadSamplingReport.Select(s => s.DailySampling.Where(d => d.Date == sampling.Date).FirstOrDefault()).ToList();
                    foreach (var sample in temLeadSampleData)
                    {
                        if (sample.SamplePercentage != 0)
                        {
                            counter += 1;
                            totalDateSampling += sample.SamplePercentage;
                        }
                    }
                    var avgSamplePercentage = Math.Round(((double)totalDateSampling / counter), 2);
                    teamleadSamplingReport.ForEach(a =>
                    {
                        a.DailySampling.Where(w => w.Date == sampling.Date).FirstOrDefault().AvgSamplePercentage = avgSamplePercentage;
                        a.AvgOfAvgSampling = avgOfAvgSample;
                    });
                }
            }
            return teamleadSamplingReport;
        }
        private List<vwQualityReportSummaryELSV> GetCategorySummaryReportELSV(List<QualityRating3> qualityRatings)
        {
            List<vwQualityReportSummaryELSV> reportSummaries = new List<vwQualityReportSummaryELSV>();
            var cf1_PointsEarned = qualityRatings.Sum(q => q.CF1_PointsEarned);
            var cf2_PointsEarned = qualityRatings.Sum(q => q.CF2_PointsEarned);
            var cf3_PointsEarned = qualityRatings.Sum(q => q.CF3_PointsEarned);
            var cf4_PointsEarned = qualityRatings.Sum(q => q.CF4_PointsEarned);

            var customerFocus_PointsEarned = (cf1_PointsEarned + cf2_PointsEarned + cf3_PointsEarned + cf4_PointsEarned);

            var cf1_TotalPoints = qualityRatings.Sum(q => q.CF1_TotalPoints);
            var cf2_TotalPoints = qualityRatings.Sum(q => q.CF2_TotalPoints);
            var cf3_TotalPoints = qualityRatings.Sum(q => q.CF3_TotalPoints);
            var cf4_TotalPoints = qualityRatings.Sum(q => q.CF4_TotalPoints);

            var customerFocus_TotalPoints = (cf1_TotalPoints + cf2_TotalPoints + cf3_TotalPoints + cf4_TotalPoints);

            double customerFocus_Percent = Math.Round(((double)customerFocus_PointsEarned / customerFocus_TotalPoints) * 100,2);

            reportSummaries.Add(new vwQualityReportSummaryELSV {
                Category = "Customer Focus",
                PointsEarned = customerFocus_PointsEarned,
                TotalPoints = customerFocus_TotalPoints,
                ScorePercentage = customerFocus_Percent,
            });

            var sf1_PointsEarned = qualityRatings.Sum(q => q.SF1_PointsEarned);
            var sf2_PointsEarned = qualityRatings.Sum(q => q.SF2_PointsEarned);
            var sf3_PointsEarned = qualityRatings.Sum(q => q.SF3_PointsEarned);

            var systemFocus_PointsEarned = (sf1_PointsEarned + sf2_PointsEarned + sf3_PointsEarned);

            var sf1_TotalPoints = qualityRatings.Sum(q => q.SF1_TotalPoints);
            var sf2_TotalPoints = qualityRatings.Sum(q => q.SF2_TotalPoints);
            var sf3_TotalPoints = qualityRatings.Sum(q => q.SF3_TotalPoints);

            var systemFocus_TotalPoints = (sf1_TotalPoints + sf2_TotalPoints + sf3_TotalPoints);

            double systemFocus_Percent = Math.Round(((double)systemFocus_PointsEarned / systemFocus_TotalPoints) * 100,2);

            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "System Focus",
                PointsEarned = systemFocus_PointsEarned,
                TotalPoints = systemFocus_TotalPoints,
                ScorePercentage = systemFocus_Percent,
            });

            var bp1_PointsEarned = qualityRatings.Sum(q => q.BP1_PointsEarned);
            var bp2_PointsEarned = qualityRatings.Sum(q => q.BP2_PointsEarned);
            var bp3_PointsEarned = qualityRatings.Sum(q => q.BP3_PointsEarned);

            var businessProcess_PointsEarned = (bp1_PointsEarned + bp2_PointsEarned + bp3_PointsEarned);

            var bp1_TotalPoints = qualityRatings.Sum(q => q.BP1_TotalPoints);
            var bp2_TotalPoints = qualityRatings.Sum(q => q.BP2_TotalPoints);
            var bp3_TotalPoints = qualityRatings.Sum(q => q.BP3_TotalPoints);

            var businessProcess_TotalPoints = (bp1_TotalPoints + bp2_TotalPoints + bp3_TotalPoints);

            double businessProcess_Percent = Math.Round(((double)businessProcess_PointsEarned / businessProcess_TotalPoints) * 100,2);

            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "Business Process Focus",
                PointsEarned = businessProcess_PointsEarned,
                TotalPoints = businessProcess_TotalPoints,
                ScorePercentage = businessProcess_Percent,
            });

            var ic1_PointsEarned = qualityRatings.Sum(q => q.IC1_PointsEarned);
            var ic2_PointsEarned = qualityRatings.Sum(q => q.IC2_PointsEarned);
            var ic3_PointsEarned = qualityRatings.Sum(q => q.IC3_PointsEarned);
            var ic4_PointsEarned = qualityRatings.Sum(q => q.IC4_PointsEarned);

            var languageFocus_PointsEarned = (ic1_PointsEarned + ic2_PointsEarned + ic3_PointsEarned + ic4_PointsEarned);

            var ic1_TotalPoints = qualityRatings.Sum(q => q.IC1_TotalPoints);
            var ic2_TotalPoints = qualityRatings.Sum(q => q.IC2_TotalPoints);
            var ic3_TotalPoints = qualityRatings.Sum(q => q.IC3_TotalPoints);
            var ic4_TotalPoints = qualityRatings.Sum(q => q.IC4_TotalPoints);

            var languageFocus_TotalPoints = (ic1_TotalPoints + ic2_TotalPoints + ic3_TotalPoints + ic4_TotalPoints);

            double languageFocus_Percent = Math.Round(((double)languageFocus_PointsEarned / languageFocus_TotalPoints) * 100,2);

            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "Language Focus",
                PointsEarned = languageFocus_PointsEarned,
                TotalPoints = languageFocus_TotalPoints,
                ScorePercentage = languageFocus_Percent,
            });

            var totalPointsEarned = (customerFocus_PointsEarned + systemFocus_PointsEarned + businessProcess_PointsEarned + languageFocus_PointsEarned);
            var totalPoints = (customerFocus_TotalPoints + systemFocus_TotalPoints + businessProcess_TotalPoints + languageFocus_TotalPoints);

            double percent = Math.Round(((double)totalPointsEarned / totalPoints) * 100,2);

            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "Total",
                PointsEarned = totalPointsEarned,
                TotalPoints = totalPoints,
                ScorePercentage = percent,
            });

            return reportSummaries;
        }
        private List<vwQualityReportSummaryELSV> GetCodeSummaryReportELSV(List<QualityRating3> qualityRatings)
        {
            var codeDefinations = GetElsvCodeDefinations();
            List<vwQualityReportSummaryELSV> reportSummaries = new List<vwQualityReportSummaryELSV>();
            var cf1_PointsEarned = qualityRatings.Sum(q => q.CF1_PointsEarned);
            var cf2_PointsEarned = qualityRatings.Sum(q => q.CF2_PointsEarned);
            var cf3_PointsEarned = qualityRatings.Sum(q => q.CF3_PointsEarned);
            var cf4_PointsEarned = qualityRatings.Sum(q => q.CF4_PointsEarned);

            var customerFocus_PointsEarned = (cf1_PointsEarned + cf2_PointsEarned + cf3_PointsEarned + cf4_PointsEarned);

            var cf1_TotalPoints = qualityRatings.Sum(q => q.CF1_TotalPoints);
            var cf2_TotalPoints = qualityRatings.Sum(q => q.CF2_TotalPoints);
            var cf3_TotalPoints = qualityRatings.Sum(q => q.CF3_TotalPoints);
            var cf4_TotalPoints = qualityRatings.Sum(q => q.CF4_TotalPoints);

            var customerFocus_TotalPoints = (cf1_TotalPoints + cf2_TotalPoints + cf3_TotalPoints + cf4_TotalPoints);

            double customerFocus_Percent = Math.Round(((double)customerFocus_PointsEarned / customerFocus_TotalPoints) * 100, 2);

            var cf1Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "CF1").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "CF1",
                PointsEarned = cf1_PointsEarned,
                TotalPoints = cf1_TotalPoints,
                ScorePercentage = Math.Round(((double)cf1_PointsEarned / cf1_TotalPoints) * 100, 2),
                Details = cf1Tuple.Item2,
                Defination = cf1Tuple.Item3,
            });

            var cf2Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "CF2").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "CF2",
                PointsEarned = cf2_PointsEarned,
                TotalPoints = cf2_TotalPoints,
                ScorePercentage = Math.Round(((double)cf2_PointsEarned / cf2_TotalPoints) * 100, 2),
                Details = cf2Tuple.Item2,
                Defination = cf2Tuple.Item3,
            });

            var cf3Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "CF3").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "CF3",
                PointsEarned = cf3_PointsEarned,
                TotalPoints = cf3_TotalPoints,
                ScorePercentage = Math.Round(((double)cf3_PointsEarned / cf3_TotalPoints) * 100, 2),
                Details = cf3Tuple.Item2,
                Defination = cf3Tuple.Item3,
            });

            var cf4Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "CF4").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "CF4",
                PointsEarned = cf4_PointsEarned,
                TotalPoints = cf4_TotalPoints,
                ScorePercentage = Math.Round(((double)cf4_PointsEarned / cf4_TotalPoints) * 100, 2),
                Details = cf4Tuple.Item2,
                Defination = cf4Tuple.Item3,
            });

            var sf1_PointsEarned = qualityRatings.Sum(q => q.SF1_PointsEarned);
            var sf2_PointsEarned = qualityRatings.Sum(q => q.SF2_PointsEarned);
            var sf3_PointsEarned = qualityRatings.Sum(q => q.SF3_PointsEarned);

            var systemFocus_PointsEarned = (sf1_PointsEarned + sf2_PointsEarned + sf3_PointsEarned);

            var sf1_TotalPoints = qualityRatings.Sum(q => q.SF1_TotalPoints);
            var sf2_TotalPoints = qualityRatings.Sum(q => q.SF2_TotalPoints);
            var sf3_TotalPoints = qualityRatings.Sum(q => q.SF3_TotalPoints);

            var systemFocus_TotalPoints = (sf1_TotalPoints + sf2_TotalPoints + sf3_TotalPoints);

            double systemFocus_Percent = Math.Round(((double)systemFocus_PointsEarned / systemFocus_TotalPoints) * 100, 2);

            var sf1Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "SF1").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "SF1",
                PointsEarned = sf1_PointsEarned,
                TotalPoints = sf1_TotalPoints,
                ScorePercentage = Math.Round(((double)sf1_PointsEarned / sf1_TotalPoints) * 100, 2),
                Details = sf1Tuple.Item2,
                Defination = sf1Tuple.Item3,
            });

            var sf2Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "SF2").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "SF2",
                PointsEarned = sf2_PointsEarned,
                TotalPoints = sf2_TotalPoints,
                ScorePercentage = Math.Round(((double)sf2_PointsEarned / sf2_TotalPoints) * 100, 2),
                Details = sf2Tuple.Item2,
                Defination = sf2Tuple.Item3,
            });

            var sf3Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "SF3").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "SF3",
                PointsEarned = sf3_PointsEarned,
                TotalPoints = sf3_TotalPoints,
                ScorePercentage = Math.Round(((double)sf3_PointsEarned / sf3_TotalPoints) * 100, 2),
                Details = sf3Tuple.Item2,
                Defination = sf3Tuple.Item3,
            });

            var bp1_PointsEarned = qualityRatings.Sum(q => q.BP1_PointsEarned);
            var bp2_PointsEarned = qualityRatings.Sum(q => q.BP2_PointsEarned);
            var bp3_PointsEarned = qualityRatings.Sum(q => q.BP3_PointsEarned);

            var businessProcess_PointsEarned = (bp1_PointsEarned + bp2_PointsEarned + bp3_PointsEarned);

            var bp1_TotalPoints = qualityRatings.Sum(q => q.BP1_TotalPoints);
            var bp2_TotalPoints = qualityRatings.Sum(q => q.BP2_TotalPoints);
            var bp3_TotalPoints = qualityRatings.Sum(q => q.BP3_TotalPoints);

            var businessProcess_TotalPoints = (bp1_TotalPoints + bp2_TotalPoints + bp3_TotalPoints);

            double businessProcess_Percent = Math.Round(((double)businessProcess_PointsEarned / businessProcess_TotalPoints) * 100, 2);

            var bp1Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "BP1").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "BP1",
                PointsEarned = bp1_PointsEarned,
                TotalPoints = bp1_TotalPoints,
                ScorePercentage = Math.Round(((double)bp1_PointsEarned / bp1_TotalPoints) * 100, 2),
                Details = bp1Tuple.Item2,
                Defination = bp1Tuple.Item3,
            });

            var bp2Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "BP2").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "BP2",
                PointsEarned = bp2_PointsEarned,
                TotalPoints = bp2_TotalPoints,
                ScorePercentage = Math.Round(((double)bp2_PointsEarned / bp2_TotalPoints) * 100, 2),
                Details = bp2Tuple.Item2,
                Defination = bp2Tuple.Item3,
            });

            var bp3Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "BP3").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "BP3",
                PointsEarned = bp3_PointsEarned,
                TotalPoints = bp3_TotalPoints,
                ScorePercentage = Math.Round(((double)bp3_PointsEarned / bp3_TotalPoints) * 100, 2),
                Details = bp3Tuple.Item2,
                Defination = bp3Tuple.Item3,
            });

            var ic1_PointsEarned = qualityRatings.Sum(q => q.IC1_PointsEarned);
            var ic2_PointsEarned = qualityRatings.Sum(q => q.IC2_PointsEarned);
            var ic3_PointsEarned = qualityRatings.Sum(q => q.IC3_PointsEarned);
            var ic4_PointsEarned = qualityRatings.Sum(q => q.IC4_PointsEarned);

            var languageFocus_PointsEarned = (ic1_PointsEarned + ic2_PointsEarned + ic3_PointsEarned + ic4_PointsEarned);

            var ic1_TotalPoints = qualityRatings.Sum(q => q.IC1_TotalPoints);
            var ic2_TotalPoints = qualityRatings.Sum(q => q.IC2_TotalPoints);
            var ic3_TotalPoints = qualityRatings.Sum(q => q.IC3_TotalPoints);
            var ic4_TotalPoints = qualityRatings.Sum(q => q.IC4_TotalPoints);

            var languageFocus_TotalPoints = (ic1_TotalPoints + ic2_TotalPoints + ic3_TotalPoints + ic4_TotalPoints);

            double languageFocus_Percent = Math.Round(((double)languageFocus_PointsEarned / languageFocus_TotalPoints) * 100, 2);

            var ic1Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "IC1").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "IC1",
                PointsEarned = ic1_PointsEarned,
                TotalPoints = ic1_TotalPoints,
                ScorePercentage = Math.Round(((double)ic1_PointsEarned / ic1_TotalPoints) * 100, 2),
                Details = ic1Tuple.Item2,
                Defination = ic1Tuple.Item3,
            });

            var ic2Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "IC2").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "IC2",
                PointsEarned = ic2_PointsEarned,
                TotalPoints = ic2_TotalPoints,
                ScorePercentage = Math.Round(((double)ic2_PointsEarned / ic2_TotalPoints) * 100, 2),
                Details = ic2Tuple.Item2,
                Defination = ic2Tuple.Item3,
            });

            var ic3Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "IC3").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "IC3",
                PointsEarned = ic3_PointsEarned,
                TotalPoints = ic3_TotalPoints,
                ScorePercentage = Math.Round(((double)ic3_PointsEarned / ic3_TotalPoints) * 100, 2),
                Details = ic3Tuple.Item2,
                Defination = ic3Tuple.Item3,
            });

            var ic4Tuple = codeDefinations.Where(t => t.Item1.ToUpper() == "IC4").FirstOrDefault();
            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "IC4",
                PointsEarned = ic4_PointsEarned,
                TotalPoints = ic4_TotalPoints,
                ScorePercentage = Math.Round(((double)ic4_PointsEarned / ic4_TotalPoints) * 100, 2),
                Details = ic4Tuple.Item2,
                Defination = ic4Tuple.Item3,
            });

            var totalPointsEarned = (customerFocus_PointsEarned + systemFocus_PointsEarned + businessProcess_PointsEarned + languageFocus_PointsEarned);
            var totalPoints = (customerFocus_TotalPoints + systemFocus_TotalPoints + businessProcess_TotalPoints + languageFocus_TotalPoints);

            double percent = Math.Round(((double)totalPointsEarned / totalPoints) * 100, 2);

            reportSummaries.Add(new vwQualityReportSummaryELSV
            {
                Category = "Total",
                PointsEarned = totalPointsEarned,
                TotalPoints = totalPoints,
                ScorePercentage = percent,
            });

            return reportSummaries;
        }
        private List<vwQualityReportAgentSummaryELSV> GetAgentSummaryReportELSV(List<QualityRating3> qualityRatings, int passingScore)
        {
            List<vwQualityReportAgentSummaryELSV> agentSummaries = new List<vwQualityReportAgentSummaryELSV>();
            foreach(var quality in qualityRatings)
            {
                vwQualityReportAgentSummaryELSV agentInfo = new vwQualityReportAgentSummaryELSV();
                agentInfo.Month = quality.Month;
                agentInfo.Year = quality.Date.Year;
                agentInfo.Date = quality.Date;
                agentInfo.TeamLead = quality.TeamLead;
                agentInfo.AgentName = quality.AgentName;
                agentInfo.EmployeeId = quality.EmployeeId;
                agentInfo.CF1_PointsEarned = quality.CF1_PointsEarned;
                agentInfo.CF1_TotalPoints = quality.CF1_TotalPoints;
                agentInfo.CF1_Percent = (quality.CF1_PointsEarned>0 && quality.CF1_TotalPoints>0)? Math.Round(((double)quality.CF1_PointsEarned / quality.CF1_TotalPoints) * 100, 2) : 0;

                agentInfo.CF2_PointsEarned = quality.CF2_PointsEarned;
                agentInfo.CF2_TotalPoints = quality.CF2_TotalPoints;
                agentInfo.CF2_Percent = (quality.CF2_PointsEarned > 0 && quality.CF2_TotalPoints > 0) ? Math.Round(((double)quality.CF2_PointsEarned / quality.CF2_TotalPoints) * 100, 2):0;

                agentInfo.CF3_PointsEarned = quality.CF3_PointsEarned;
                agentInfo.CF3_TotalPoints = quality.CF3_TotalPoints;
                agentInfo.CF3_Percent = (quality.CF3_PointsEarned > 0 && quality.CF3_TotalPoints > 0) ? Math.Round(((double)quality.CF3_PointsEarned / quality.CF3_TotalPoints) * 100, 2):0;

                agentInfo.CF4_PointsEarned = quality.CF4_PointsEarned;
                agentInfo.CF4_TotalPoints = quality.CF4_TotalPoints;
                agentInfo.CF4_Percent = (quality.CF4_PointsEarned > 0 && quality.CF4_TotalPoints > 0) ? Math.Round(((double)quality.CF4_PointsEarned / quality.CF4_TotalPoints) * 100, 2):0;

                agentInfo.CF_PointsEarned = (quality.CF1_PointsEarned + quality.CF2_PointsEarned + quality.CF3_PointsEarned + quality.CF4_PointsEarned);
                agentInfo.CF_TotalPoints = (quality.CF1_TotalPoints + quality.CF2_TotalPoints + quality.CF3_TotalPoints + quality.CF4_TotalPoints);

                agentInfo.SF1_PointsEarned = quality.SF1_PointsEarned;
                agentInfo.SF1_TotalPoints = quality.SF1_TotalPoints;
                agentInfo.SF1_Percent = (quality.SF1_PointsEarned > 0 && quality.SF1_TotalPoints > 0) ? Math.Round(((double)quality.SF1_PointsEarned / quality.SF1_TotalPoints) * 100, 2) : 0;

                agentInfo.SF2_PointsEarned = quality.SF2_PointsEarned;
                agentInfo.SF2_TotalPoints = quality.SF2_TotalPoints;
                agentInfo.SF2_Percent = (quality.SF2_PointsEarned > 0 && quality.SF2_TotalPoints > 0) ? Math.Round(((double)quality.SF2_PointsEarned / quality.SF2_TotalPoints) * 100, 2) : 0;

                agentInfo.SF3_PointsEarned = quality.SF3_PointsEarned;
                agentInfo.SF3_TotalPoints = quality.SF3_TotalPoints;
                agentInfo.SF3_Percent = (quality.SF3_PointsEarned > 0 && quality.SF3_TotalPoints > 0) ? Math.Round(((double)quality.SF3_PointsEarned / quality.SF3_TotalPoints) * 100, 2) : 0;

                agentInfo.SF_PointsEarned = (quality.SF1_PointsEarned + quality.SF2_PointsEarned + quality.SF3_PointsEarned);
                agentInfo.SF_TotalPoints = (quality.SF1_TotalPoints + quality.SF2_TotalPoints + quality.SF3_TotalPoints);

                agentInfo.BP1_PointsEarned = quality.BP1_PointsEarned;
                agentInfo.BP1_TotalPoints = quality.BP1_TotalPoints;
                agentInfo.BP1_Percent = (quality.BP1_PointsEarned > 0 && quality.BP1_TotalPoints > 0) ? Math.Round(((double)quality.BP1_PointsEarned / quality.BP1_TotalPoints) * 100, 2) : 0;

                agentInfo.BP2_PointsEarned = quality.BP2_PointsEarned;
                agentInfo.BP2_TotalPoints = quality.BP2_TotalPoints;
                agentInfo.BP2_Percent = (quality.BP2_PointsEarned > 0 && quality.BP2_TotalPoints > 0) ? Math.Round(((double)quality.BP2_PointsEarned / quality.BP2_TotalPoints) * 100, 2) : 0;

                agentInfo.BP3_PointsEarned = quality.BP3_PointsEarned;
                agentInfo.BP3_TotalPoints = quality.BP3_TotalPoints;
                agentInfo.BP3_Percent = (quality.BP3_PointsEarned > 0 && quality.BP3_TotalPoints > 0) ? Math.Round(((double)quality.BP3_PointsEarned / quality.BP3_TotalPoints) * 100, 2) : 0;

                agentInfo.BP_PointsEarned = (quality.BP1_PointsEarned + quality.BP2_PointsEarned + quality.BP3_PointsEarned);
                agentInfo.BP_TotalPoints = (quality.BP1_TotalPoints + quality.BP2_TotalPoints + quality.BP3_TotalPoints);

                agentInfo.IC1_PointsEarned = quality.IC1_PointsEarned;
                agentInfo.IC1_TotalPoints = quality.IC1_TotalPoints;
                agentInfo.IC1_Percent = (quality.IC1_PointsEarned > 0 && quality.IC1_TotalPoints > 0) ? Math.Round(((double)quality.IC1_PointsEarned / quality.IC1_TotalPoints) * 100, 2) : 0;

                agentInfo.IC2_PointsEarned = quality.IC2_PointsEarned;
                agentInfo.IC2_TotalPoints = quality.IC2_TotalPoints;
                agentInfo.IC2_Percent = (quality.IC2_PointsEarned > 0 && quality.IC2_TotalPoints > 0) ? Math.Round(((double)quality.IC2_PointsEarned / quality.IC2_TotalPoints) * 100, 2) : 0;

                agentInfo.IC3_PointsEarned = quality.IC3_PointsEarned;
                agentInfo.IC3_TotalPoints = quality.IC3_TotalPoints;
                agentInfo.IC3_Percent = (quality.IC3_PointsEarned > 0 && quality.IC3_TotalPoints > 0) ? Math.Round(((double)quality.IC3_PointsEarned / quality.IC3_TotalPoints) * 100, 2) : 0;

                agentInfo.IC4_PointsEarned = quality.IC4_PointsEarned;
                agentInfo.IC4_TotalPoints = quality.IC4_TotalPoints;
                agentInfo.IC4_Percent = (quality.IC4_PointsEarned > 0 && quality.IC4_TotalPoints > 0) ? Math.Round(((double)quality.IC4_PointsEarned / quality.IC4_TotalPoints) * 100, 2) : 0;

                agentInfo.IC_PointsEarned = (quality.IC1_PointsEarned + quality.IC2_PointsEarned + quality.IC3_PointsEarned + quality.IC4_PointsEarned);
                agentInfo.IC_TotalPoints = (quality.IC1_TotalPoints + quality.IC2_TotalPoints + quality.IC3_TotalPoints + quality.IC4_TotalPoints);

                agentInfo.Overall_PointsEarned = (agentInfo.CF_PointsEarned + agentInfo.SF_PointsEarned + agentInfo.BP_PointsEarned + agentInfo.IC_PointsEarned);
                agentInfo.Overall_TotalPoints = (agentInfo.CF_TotalPoints + agentInfo.SF_TotalPoints + agentInfo.BP_TotalPoints + agentInfo.IC_TotalPoints);
                agentInfo.Overall_QCScore = (agentInfo.Overall_PointsEarned > 0 && agentInfo.Overall_TotalPoints > 0) ? Math.Round(((double)agentInfo.Overall_PointsEarned / agentInfo.Overall_TotalPoints) * 100, 2) : 0;
                agentInfo.PassedOrFailed = (agentInfo.Overall_QCScore >= passingScore) ? "Passed" : "ForCoaching";
                agentInfo.PassiveSurvey = quality.PassiveSurvey;
                agentInfo.CSATScore = quality.CSATScore;
                agentInfo.NoOfPplOpportunity = quality.NoOfPplOpportunity;
                if(agentInfo.Overall_QCScore>91.99 && agentInfo.PassiveSurvey>91.99 && agentInfo.CSATScore>91.99 && agentInfo.NoOfPplOpportunity<=1)
                {
                    agentInfo.QCType = "Reduced";
                }
                else if(agentInfo.Overall_QCScore > 91.99 && agentInfo.NoOfPplOpportunity <= 2)
                {
                    agentInfo.QCType = "Regular";
                }
                else if (agentInfo.Overall_QCScore < 92 || agentInfo.NoOfPplOpportunity >= 3)
                {
                    agentInfo.QCType = "Tightened";
                }

                if(agentInfo.QCType == "Reduced")
                {
                    agentInfo.NoOfSamples = 4;
                }
                else if (agentInfo.QCType == "Regular")
                {
                    agentInfo.NoOfSamples = 8;
                }
                else if (agentInfo.QCType == "Tightened")
                {
                    agentInfo.NoOfSamples = 20;
                }
                agentInfo.Remarks = "Per Month";
                agentInfo.CreatedDate = quality.CreatedDate;

                agentSummaries.Add(agentInfo);
            }            
            return agentSummaries;
        }
        private List<WeeklyAccuracy> GetWeekRanges (DateTime startDate, DateTime endDate)
        {
            List<WeeklyAccuracy> weekRanges = new List<WeeklyAccuracy>();
            DateTime startRange = StartOfWeek(startDate, DayOfWeek.Monday);
            DateTime endRange = EndOfWeek(endDate, DayOfWeek.Sunday);                        
            for (var dt = startRange; dt <= endDate; dt = dt.AddDays(7))
            {
                WeeklyAccuracy weekRange = new WeeklyAccuracy
                {
                    StartDate = dt,
                    EndDate = dt.AddDays(6),
                    Week = $"{dt.ToString("MMM dd")} - {dt.AddDays(6).ToString("MMM dd")}",
                };
                weekRanges.Add(weekRange);
            }
            return weekRanges;
        }
        private List<DailySampling> GetDailySampling(DateTime startDate, DateTime endDate)
        {
            List<DailySampling> dailySamplings = new List<DailySampling>();
            //DateTime startRange = StartOfWeek(startDate, DayOfWeek.Monday);
            //DateTime endRange = EndOfWeek(endDate, DayOfWeek.Sunday);
            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                DailySampling daily = new DailySampling
                {
                    Date = dt,
                    DateString = dt.ToString("dd-MMM-yy")
                };
                dailySamplings.Add(daily);
            }
            return dailySamplings;
        }
        private DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        private DateTime EndOfWeek(DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = (7 + (endOfWeek - dt.DayOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }
        public List<Tuple<string, string, string>> GetElsvCodeDefinations()
        {
            List<Tuple<string, string, string>> codeDefinations = new List<Tuple<string, string, string>>();

            codeDefinations.Add(new Tuple<string, string, string>("CF1", "Welcomed customer correctly and demonstrated understanding of customer's issue?", "Asked the right questions, gathered the right information & showed understanding of the query."));
            codeDefinations.Add(new Tuple<string, string, string>("CF2", "Explained to the customer why the issue is happening? (where applicable)", "Ability to provide additional information where required to explain the back ground of the situation."));
            codeDefinations.Add(new Tuple<string, string, string>("CF3", "Correct and complete solution offered where guidance was required?", "Where a customer was asking for advice on process or procedure was the correct advise provided"));
            codeDefinations.Add(new Tuple<string, string, string>("CF4", "Was a recap or follow up met after? (if applicable)", "Query was followed up as required to build trust/relationships with the customer."));

            codeDefinations.Add(new Tuple<string, string, string>("SF1", "Has OSvC best practice been followed?. (Forward & Tracked / Collaborated / Tasked appropriately and correctly, OSvC incident thread is complete and legible)", "Followed correct procedure in OSVC ie,adding private note,  query sent to the right recipient in a timely manner for the right reason if necessary, If another colleague was to pick this up would they have the full story in the thread"));
            codeDefinations.Add(new Tuple<string, string, string>("SF2", "Supporting Tools", "Utilize and correctly use Supporting tools; ie, EM, PTS, Delta, CHIEF, Salesforce, R12"));
            codeDefinations.Add(new Tuple<string, string, string>("SF3", "Was new/correct template have been used?", "Utilize and correctly use Supporting tools; ie, EM, PTS, Delta, CHIEF, Salesforce, R12"));

            codeDefinations.Add(new Tuple<string, string, string>("BP1", "Pointed customer to suitable self-help on website?", "Links or knowledge base answers were offered to easily assist the customer on how to self-navigate."));
            codeDefinations.Add(new Tuple<string, string, string>("BP2", "OSvC Admin part 1: Selected the appropriate queue and mailbox, customer classification and added product.", "When creating a new incident or received collaboration to make sure the correct fields are chosen during and before solving/closing an incident."));
            codeDefinations.Add(new Tuple<string, string, string>("BP3", "OSvC Admin part 2: Selected the appropriate contact reason, resolution code, root cause", "Based on the customers query, did they match what the customers email was about. The root cause and JIRA ticket also added when applicable."));

            codeDefinations.Add(new Tuple<string, string, string>("IC1", "Demonstrated positivity", "Supported the customer in a positive manner, used good phrasing"));
            codeDefinations.Add(new Tuple<string, string, string>("IC2", "Reassured the customer", "Informed the customer why the issue was happening and what they could do to solve it for good"));
            codeDefinations.Add(new Tuple<string, string, string>("IC3", "Ended on a positive peak", "Checked the customer was happy with the solution/ understood any additional timelines or actions to be completed"));
            codeDefinations.Add(new Tuple<string, string, string>("IC4", "Aimed to surprise/ delight customer", "Did they go out of their way to support/ take additional steps . Did the customer express their satisfaction/ happiness at the end of the interaction"));

            return codeDefinations;
        }

        #endregion

        #endregion

        #region TICKETING TOOL REPORTS

        public vwTicketingToolReport GetTicketingToolReport(TicketingToolFilter filter = null)
        {
            if (filter == null)
            {
                filter = new TicketingToolFilter();
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                filter.StartDate = first;
                filter.EndDate = last;
                //filter.StartDate = new DateTime(2021, 07, 01).Date;
                //filter.EndDate = new DateTime(2021, 07, 31).Date;
                filter.ReportType = ReportType.Monthly.ToString();
                filter.PageNumber = 1;
            }

            vwTicketingToolReport report = new vwTicketingToolReport();
            report.lstReportType = mtdGetReportTypes();
            report.TicketingFilter = filter;
            var ticketingRecords = _skillMatrixRepository.GetTicketingRecordsByDate(filter.StartDate, filter.EndDate).ToList();
            if (ticketingRecords.Count > 0)
            {
                List<vwTicketingStatusReport> statusReport = new List<vwTicketingStatusReport>();
                if (filter.ReportType == ReportType.Daily.ToString())
                {
                    statusReport = GetTicketingToolDailyStatusReport(ticketingRecords, filter.StartDate, filter.EndDate);
                }
                else if(filter.ReportType == ReportType.Weekly.ToString())
                {
                    statusReport = GetTicketingToolWeeklyStatusReport(ticketingRecords, filter.StartDate, filter.EndDate);
                }
                else
                {
                    statusReport = GetTicketingToolStatusReport(ticketingRecords);
                }
                report.TicketingStatusReport = statusReport;
                report.TotalTicketsChecked = statusReport.Sum(s => s.TicketsChecked);
                report.TotalCorrectTickets = statusReport.Sum(s => s.CorrectTickets);
                report.TotalErrorCounts = statusReport.Sum(s => s.ErrorCounts);
                report.AvgAccuracyRate = Math.Round(((double)report.TotalCorrectTickets / report.TotalTicketsChecked) * 100, 2);

                var sortedList = statusReport.OrderBy(s => s.Engagement).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedStatusReport = paginatedData;
                report.TicketingStatusReport = sortedList;
            }
            return report;
        }

        private List<vwTicketingStatusReport> GetTicketingToolStatusReport(List<TicketingTool> ticketingRecords)
        {
            List<vwTicketingStatusReport> statusReport = new List<vwTicketingStatusReport>();
            var engagements = ticketingRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = ticketingRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                int ticketsChecked = engagementRecords.Count();
                int errorTickets = engagementRecords.Where(q => q.Comment.Trim().ToLower() !=  "correct").Count();
                int correctTickets = ticketsChecked - errorTickets;
                double accuracyRate = 0;
                if (ticketsChecked > 0 && correctTickets>0)
                {
                    accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                }
                vwTicketingStatusReport engagementStatus = new vwTicketingStatusReport();
                engagementStatus.Engagement = engagement;
                engagementStatus.TicketsChecked = ticketsChecked;
                engagementStatus.ErrorCounts = errorTickets;
                engagementStatus.CorrectTickets = correctTickets;
                engagementStatus.AccuracyRate = accuracyRate;
                statusReport.Add(engagementStatus);
            }
            return statusReport;
        }

        private List<vwTicketingStatusReport> GetTicketingToolDailyStatusReport(List<TicketingTool> ticketingRecords, DateTime startDate, DateTime endDate)
        {
            List<vwTicketingStatusReport> statusReport = new List<vwTicketingStatusReport>();            
            var dailySamplings = GetDates(startDate, endDate);
            int totalTicketsChecked = 0;
            int totalCorrectTickets = 0;
            int totalAvgCounter = 0;
            var engagements = ticketingRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = ticketingRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                vwTicketingStatusReport status = new vwTicketingStatusReport();
                status.Engagement = engagement;
                status.TicketsChecked = engagementRecords.Count();
                status.ErrorCounts = engagementRecords.Where(q => q.Comment.Trim().ToLower() != "correct").ToList().Count();
                status.CorrectTickets = status.TicketsChecked - status.ErrorCounts;
                status.AccuracyRate = 0;
                if (status.TicketsChecked > 0 && status.CorrectTickets > 0)
                {
                    status.AccuracyRate = Math.Round(((double)status.CorrectTickets / status.TicketsChecked) * 100, 2);
                    totalTicketsChecked += status.TicketsChecked;
                    totalCorrectTickets += status.CorrectTickets;
                    totalAvgCounter += 1;
                }
                
                foreach(var sample in dailySamplings)
                {
                    var dailyRecords = engagementRecords.Where(e => e.Date == sample.Date).ToList();
                    int ticketsChecked = dailyRecords.Count();
                    int errorTickets = dailyRecords.Where(q => q.Comment.Trim().ToLower() != "correct").ToList().Count();
                    int correctTickets = ticketsChecked - errorTickets;
                    double accuracyRate = 0;
                    if (ticketsChecked > 0 && correctTickets > 0)
                    {
                        accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                    }

                    vwTicketingStatusReportDaily dailyStatus = new vwTicketingStatusReportDaily();
                    dailyStatus.Date = sample.Date;
                    dailyStatus.Description = sample.DateString;
                    dailyStatus.TicketsChecked = ticketsChecked;
                    dailyStatus.ErrorCounts = errorTickets;
                    dailyStatus.CorrectTickets = correctTickets;
                    dailyStatus.AccuracyRate = accuracyRate;
                    status.TicketingStatusReportDaily.Add(dailyStatus);
                }
                statusReport.Add(status);
            }
            double avgOfAvgAccuracy = 0;
            if (totalTicketsChecked > 0 && totalCorrectTickets > 0)
            {
                avgOfAvgAccuracy = Math.Round(((double)totalCorrectTickets / totalTicketsChecked) * 100, 2);
            }            
            foreach (var sample in dailySamplings)
            {

                var counter = 0;
                int sumOfTicketsChecked = 0;
                int sumOfCorrectTickets = 0;
                var dailyStatusReport = statusReport.Select(s => s.TicketingStatusReportDaily.Where(e => e.Date == sample.Date).FirstOrDefault()).ToList();
                foreach (var status in dailyStatusReport)
                {
                    if (status.AccuracyRate > 0)
                    {
                        counter += 1;
                        sumOfTicketsChecked += status.TicketsChecked;
                        sumOfCorrectTickets += status.CorrectTickets;
                    }
                }
                double avgAccuracyRate = 0;
                if (sumOfTicketsChecked > 0 && sumOfCorrectTickets > 0)
                {
                    avgAccuracyRate = Math.Round(((double)sumOfCorrectTickets / sumOfTicketsChecked) * 100, 2);
                }
                statusReport.ForEach(a =>
                {
                    a.TicketingStatusReportDaily.Where(w => w.Date == sample.Date).FirstOrDefault().AvgAccuracyRate = avgAccuracyRate;
                    a.AvgAccuracyRate = avgOfAvgAccuracy;
                });
            }
            return statusReport;
        }

        private List<vwTicketingStatusReport> GetTicketingToolWeeklyStatusReport(List<TicketingTool> ticketingRecords, DateTime startDate, DateTime endDate)
        {
            List<vwTicketingStatusReport> statusReport = new List<vwTicketingStatusReport>();
            var weekRanges = GetWeekRanges(startDate, endDate);
            int totalTicketsChecked = 0;
            int totalCorrectTickets = 0;
            int totalAvgCounter = 0;
            var engagements = ticketingRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = ticketingRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                vwTicketingStatusReport status = new vwTicketingStatusReport();
                status.Engagement = engagement;                
                status.TicketsChecked = engagementRecords.Count();
                status.ErrorCounts = engagementRecords.Where(q => q.Comment.Trim().ToLower() != "correct").ToList().Count();
                status.CorrectTickets = status.TicketsChecked - status.ErrorCounts;
                status.AccuracyRate = 0;
                if (status.TicketsChecked > 0 && status.CorrectTickets > 0)
                {
                    status.AccuracyRate = Math.Round(((double)status.CorrectTickets / status.TicketsChecked) * 100, 2);
                    totalTicketsChecked += status.TicketsChecked;
                    totalCorrectTickets += status.CorrectTickets;
                    totalAvgCounter += 1;
                }
                foreach (var week in weekRanges)
                {
                    var weeklyRecords = engagementRecords.Where(e => e.Date >= week.StartDate && e.Date <= week.EndDate).ToList();
                    int ticketsChecked = weeklyRecords.Count();
                    int errorTickets = weeklyRecords.Where(q => q.Comment.Trim().ToLower() != "correct").ToList().Count();
                    int correctTickets = ticketsChecked - errorTickets;
                    double accuracyRate = 0;
                    if (ticketsChecked > 0 && correctTickets > 0)
                    {
                        accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                    }

                    vwTicketingStatusReportWeekly weeklyStatus = new vwTicketingStatusReportWeekly();
                    weeklyStatus.StartDate = week.StartDate;
                    weeklyStatus.EndDate = week.EndDate;
                    weeklyStatus.Description = week.Week;
                    weeklyStatus.TicketsChecked = ticketsChecked;
                    weeklyStatus.ErrorCounts = errorTickets;
                    weeklyStatus.CorrectTickets = correctTickets;
                    weeklyStatus.AccuracyRate = accuracyRate;
                    status.TicketingStatusReportWeekly.Add(weeklyStatus);
                }
                statusReport.Add(status);
            }
            double avgOfAvgAccuracy = 0;
            if (totalTicketsChecked > 0 && totalCorrectTickets > 0)
            {
                avgOfAvgAccuracy = Math.Round(((double)totalCorrectTickets / totalTicketsChecked) * 100, 2);
            }
            foreach (var week in weekRanges)
            {

                var counter = 0;
                int sumOfTicketsChecked = 0;
                int sumOfCorrectTickets = 0;
                var weeklyStatusReport = statusReport.Select(s => s.TicketingStatusReportWeekly.Where(e => e.StartDate >= week.StartDate && e.EndDate <= week.EndDate).FirstOrDefault()).ToList();
                foreach (var status in weeklyStatusReport)
                {
                    if (status.AccuracyRate > 0)
                    {
                        counter += 1;
                        sumOfTicketsChecked += status.TicketsChecked;
                        sumOfCorrectTickets += status.CorrectTickets;
                    }
                }
                double avgAccuracyRate = 0;
                if (sumOfTicketsChecked > 0 && sumOfCorrectTickets>0)
                {
                    avgAccuracyRate = Math.Round(((double)sumOfCorrectTickets / sumOfTicketsChecked) * 100, 2);
                }                
                statusReport.ForEach(a =>
                {
                    a.TicketingStatusReportWeekly.Where(w => w.Description == week.Week).FirstOrDefault().AvgAccuracyRate = avgAccuracyRate;
                    a.AvgAccuracyRate = avgOfAvgAccuracy;
                });
            }

            return statusReport;
        }

        private List<DailySampling> GetDates(DateTime startDate, DateTime endDate)
        {
            List<DailySampling> dailySamplings = new List<DailySampling>();
            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                if(dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday )
                {
                    DailySampling daily = new DailySampling
                    {
                        Date = dt,
                        DateString = dt.ToString("dd-MMM-yy")
                    };
                    dailySamplings.Add(daily);
                }                
            }
            return dailySamplings;
        }

        #endregion

        #region BUSINESS PARTNER REPORTS

        public vwBusinessPartnerReport GetBusinessPartnerReport(BusinessPartnerFilter filter = null)
        {
            if (filter == null)
            {
                filter = new BusinessPartnerFilter();
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                filter.StartDate = first;
                filter.EndDate = last;
                //filter.StartDate = new DateTime(2021, 08, 01).Date;
                //filter.EndDate = new DateTime(2021, 08, 31).Date;
                filter.ReportType = ReportType.Monthly.ToString();
                filter.PageNumber = 1;
            }

            vwBusinessPartnerReport report = new vwBusinessPartnerReport();
            report.lstReportType = mtdGetReportTypes();
            report.BusinessPartnerFilter = filter;
            var businessPartnerRecords = _skillMatrixRepository.GetBusinessPartnerRecordsByDate(filter.StartDate, filter.EndDate).ToList();
            if (businessPartnerRecords.Count > 0)
            {
                List<vwBusinessPartnerStatusReport> statusReport = new List<vwBusinessPartnerStatusReport>();
                if (filter.ReportType == ReportType.Daily.ToString())
                {
                    statusReport = GetBusinessPartnerDailyStatusReport(businessPartnerRecords, filter.StartDate, filter.EndDate);
                }
                else if (filter.ReportType == ReportType.Weekly.ToString())
                {
                    statusReport = GetBusinessPartnerWeeklyStatusReport(businessPartnerRecords, filter.StartDate, filter.EndDate);
                }
                else
                {
                    statusReport = GetBusinessPartnerStatusReport(businessPartnerRecords);
                }
                report.BPStatusReport = statusReport;
                report.TotalTicketsChecked = statusReport.Sum(s => s.TicketsChecked);
                report.TotalCorrectTickets = statusReport.Sum(s => s.CorrectTickets);
                report.TotalErrorCounts = statusReport.Sum(s => s.ErrorCounts);
                report.AvgAccuracyRate = Math.Round(((double)report.TotalCorrectTickets / report.TotalTicketsChecked) * 100, 2);

                var sortedList = statusReport.OrderByDescending(s => s.TicketsChecked).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedStatusReport = paginatedData;
                report.BPStatusReport = sortedList;
            }
            return report;
        }

        private List<vwBusinessPartnerStatusReport> GetBusinessPartnerStatusReport(List<BusinessPartner> businessPartnerRecords)
        {
            List<vwBusinessPartnerStatusReport> statusReport = new List<vwBusinessPartnerStatusReport>();
            var engagements = businessPartnerRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = businessPartnerRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                int ticketsChecked = engagementRecords.Count();
                int errorTickets = engagementRecords.Where(q => q.Remarks.Trim().ToLower() == "error").Count();
                int correctTickets = ticketsChecked - errorTickets;
                double accuracyRate = 0;
                if (ticketsChecked > 0 && correctTickets > 0)
                {
                    accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                }
                vwBusinessPartnerStatusReport engagementStatus = new vwBusinessPartnerStatusReport();
                engagementStatus.Engagement = engagement;
                engagementStatus.TicketsChecked = ticketsChecked;
                engagementStatus.ErrorCounts = errorTickets;
                engagementStatus.CorrectTickets = correctTickets;
                engagementStatus.AccuracyRate = accuracyRate;
                statusReport.Add(engagementStatus);
            }
            return statusReport;
        }

        private List<vwBusinessPartnerStatusReport> GetBusinessPartnerDailyStatusReport(List<BusinessPartner> businessPartnerRecords, DateTime startDate, DateTime endDate)
        {
            List<vwBusinessPartnerStatusReport> statusReport = new List<vwBusinessPartnerStatusReport>();
            var dailySamplings = GetDates(startDate, endDate);
            int totalTicketsChecked = 0;
            int totalCorrectTickets = 0;
            int totalAvgCounter = 0;
            var engagements = businessPartnerRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = businessPartnerRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                vwBusinessPartnerStatusReport status = new vwBusinessPartnerStatusReport();
                status.Engagement = engagement;
                status.TicketsChecked = engagementRecords.Count();
                status.ErrorCounts = engagementRecords.Where(q => q.Remarks.Trim().ToLower() == "error").ToList().Count();
                status.CorrectTickets = status.TicketsChecked - status.ErrorCounts;
                status.AccuracyRate = 0;
                if (status.TicketsChecked > 0 && status.CorrectTickets > 0)
                {
                    status.AccuracyRate = Math.Round(((double)status.CorrectTickets / status.TicketsChecked) * 100, 2);
                    totalTicketsChecked += status.TicketsChecked;
                    totalCorrectTickets += status.CorrectTickets;
                    totalAvgCounter += 1;
                }

                foreach (var sample in dailySamplings)
                {
                    var dailyRecords = engagementRecords.Where(e => e.Date == sample.Date).ToList();
                    int ticketsChecked = dailyRecords.Count();
                    int errorTickets = dailyRecords.Where(q => q.Remarks.Trim().ToLower() == "error").ToList().Count();
                    int correctTickets = ticketsChecked - errorTickets;
                    double accuracyRate = 0;
                    if (ticketsChecked > 0 && correctTickets > 0)
                    {
                        accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                    }

                    vwBusinessPartnerStatusReportDaily dailyStatus = new vwBusinessPartnerStatusReportDaily();
                    dailyStatus.Date = sample.Date;
                    dailyStatus.Description = sample.DateString;
                    dailyStatus.TicketsChecked = ticketsChecked;
                    dailyStatus.ErrorCounts = errorTickets;
                    dailyStatus.CorrectTickets = correctTickets;
                    dailyStatus.AccuracyRate = accuracyRate;
                    status.BPStatusReportDaily.Add(dailyStatus);
                }
                statusReport.Add(status);
            }
            double avgOfAvgAccuracy = 0;
            if (totalTicketsChecked > 0 && totalCorrectTickets > 0)
            {
                avgOfAvgAccuracy = Math.Round(((double)totalCorrectTickets / totalTicketsChecked) * 100, 2);
            }
            foreach (var sample in dailySamplings)
            {

                var counter = 0;
                int sumOfTicketsChecked = 0;
                int sumOfCorrectTickets = 0;
                var dailyStatusReport = statusReport.Select(s => s.BPStatusReportDaily.Where(e => e.Date == sample.Date).FirstOrDefault()).ToList();
                foreach (var status in dailyStatusReport)
                {
                    if (status.AccuracyRate > 0)
                    {
                        counter += 1;
                        sumOfTicketsChecked += status.TicketsChecked;
                        sumOfCorrectTickets += status.CorrectTickets;
                    }
                }
                double avgAccuracyRate = 0;
                if (sumOfTicketsChecked > 0 && sumOfCorrectTickets > 0)
                {
                    avgAccuracyRate = Math.Round(((double)sumOfCorrectTickets / sumOfTicketsChecked) * 100, 2);
                }
                statusReport.ForEach(a =>
                {
                    a.BPStatusReportDaily.Where(w => w.Date == sample.Date).FirstOrDefault().AvgAccuracyRate = avgAccuracyRate;
                    a.AvgAccuracyRate = avgOfAvgAccuracy;
                });
            }
            return statusReport;
        }

        private List<vwBusinessPartnerStatusReport> GetBusinessPartnerWeeklyStatusReport(List<BusinessPartner> businessPartnerRecords, DateTime startDate, DateTime endDate)
        {
            List<vwBusinessPartnerStatusReport> statusReport = new List<vwBusinessPartnerStatusReport>();
            var weekRanges = GetWeekRanges(startDate, endDate);
            int totalTicketsChecked = 0;
            int totalCorrectTickets = 0;
            int totalAvgCounter = 0;
            var engagements = businessPartnerRecords.Select(q => q.Team).Distinct().OrderBy(q => q).ToList();
            foreach (var engagement in engagements)
            {
                var engagementRecords = businessPartnerRecords.Where(s => s.Team.ToLower() == engagement.ToLower()).ToList();
                vwBusinessPartnerStatusReport status = new vwBusinessPartnerStatusReport();
                status.Engagement = engagement;
                status.TicketsChecked = engagementRecords.Count();
                status.ErrorCounts = engagementRecords.Where(q => q.Remarks.Trim().ToLower() == "error").ToList().Count();
                status.CorrectTickets = status.TicketsChecked - status.ErrorCounts;
                status.AccuracyRate = 0;
                if (status.TicketsChecked > 0 && status.CorrectTickets > 0)
                {
                    status.AccuracyRate = Math.Round(((double)status.CorrectTickets / status.TicketsChecked) * 100, 2);
                    totalTicketsChecked += status.TicketsChecked;
                    totalCorrectTickets += status.CorrectTickets;
                    totalAvgCounter += 1;
                }
                foreach (var week in weekRanges)
                {
                    var weeklyRecords = engagementRecords.Where(e => e.Date >= week.StartDate && e.Date <= week.EndDate).ToList();
                    int ticketsChecked = weeklyRecords.Count();
                    int errorTickets = weeklyRecords.Where(q => q.Remarks.Trim().ToLower() == "error").ToList().Count();
                    int correctTickets = ticketsChecked - errorTickets;
                    double accuracyRate = 0;
                    if (ticketsChecked > 0 && correctTickets > 0)
                    {
                        accuracyRate = Math.Round(((double)correctTickets / ticketsChecked) * 100, 2);
                    }

                    vwBusinessPartnerStatusReportWeekly weeklyStatus = new vwBusinessPartnerStatusReportWeekly();
                    weeklyStatus.StartDate = week.StartDate;
                    weeklyStatus.EndDate = week.EndDate;
                    weeklyStatus.Description = week.Week;
                    weeklyStatus.TicketsChecked = ticketsChecked;
                    weeklyStatus.ErrorCounts = errorTickets;
                    weeklyStatus.CorrectTickets = correctTickets;
                    weeklyStatus.AccuracyRate = accuracyRate;
                    status.BPStatusReportWeekly.Add(weeklyStatus);
                }
                statusReport.Add(status);
            }
            double avgOfAvgAccuracy = 0;
            if (totalTicketsChecked > 0 && totalCorrectTickets > 0)
            {
                avgOfAvgAccuracy = Math.Round(((double)totalCorrectTickets / totalTicketsChecked) * 100, 2);
            }
            foreach (var week in weekRanges)
            {

                var counter = 0;
                int sumOfTicketsChecked = 0;
                int sumOfCorrectTickets = 0;
                var weeklyStatusReport = statusReport.Select(s => s.BPStatusReportWeekly.Where(e => e.StartDate >= week.StartDate && e.EndDate <= week.EndDate).FirstOrDefault()).ToList();
                foreach (var status in weeklyStatusReport)
                {
                    if (status.AccuracyRate > 0)
                    {
                        counter += 1;
                        sumOfTicketsChecked += status.TicketsChecked;
                        sumOfCorrectTickets += status.CorrectTickets;
                    }
                }
                double avgAccuracyRate = 0;
                if (sumOfTicketsChecked > 0 && sumOfCorrectTickets > 0)
                {
                    avgAccuracyRate = Math.Round(((double)sumOfCorrectTickets / sumOfTicketsChecked) * 100, 2);
                }
                statusReport.ForEach(a =>
                {
                    a.BPStatusReportWeekly.Where(w => w.Description == week.Week).FirstOrDefault().AvgAccuracyRate = avgAccuracyRate;
                    a.AvgAccuracyRate = avgOfAvgAccuracy;
                });
            }

            return statusReport;
        }

        #endregion

        #region CERTIFICATION REPORTS
        public vwCertificationReport GetCertificationReport(CertificationFilter filter = null)
        {
            if (filter == null)
            {
                filter = new CertificationFilter();
                var today = DateTime.Today;
                var month = new DateTime(today.Year, today.Month, 1);
                var first = month.AddMonths(-1);
                var last = month.AddDays(-1);
                filter.StartDate = first;
                filter.EndDate = last;
                //filter.StartDate = new DateTime(2021, 07, 01).Date;
                //filter.EndDate = new DateTime(2021, 07, 31).Date;
                filter.PageNumber = 1;
            }

            vwCertificationReport report = new vwCertificationReport();
            report.CertificationFilter = filter;
            var certificationRecords = _skillMatrixRepository.GetCertificatiionRecordsByDate(filter.StartDate, filter.EndDate).ToList();
            if (certificationRecords.Count > 0)
            {
                List<vwCertifcationLevelReport> levelReport = new List<vwCertifcationLevelReport>();
                levelReport = GetCertificationLevelReport(certificationRecords);                
                report.CertificationLevelReport = levelReport;                

                var sortedList = levelReport.OrderBy(s => s.AgentName).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedLevelReport = paginatedData;
                report.CertificationLevelReport = sortedList;
            }
            return report;
        }

        private List<vwCertifcationLevelReport> GetCertificationLevelReport(List<Certification> certificationRecords)
        {
            List<vwCertifcationLevelReport> levelReport = new List<vwCertifcationLevelReport>();
            var employees = _skillMatrixRepository.GetEmployees().Where(e=>e.AccountType == AccountType.Elsevier.ToString()).ToList();
            var categoryScoring = _skillMatrixRepository.GetCategoryScoring().ToList();
            foreach (var certification in certificationRecords)
            {                
                var employeeRecord = employees.Where(e => e.SPIEmployeeNo.Trim().ToLower() == certification.EmployeeId.Trim().ToLower()).FirstOrDefault();
                if(employeeRecord!=null)
                {
                    vwCertifcationLevelReport certificationLevel = new vwCertifcationLevelReport();
                    certificationLevel.AccountType = certification.AccountType;
                    certificationLevel.AgentName = certification.AgentName;
                    certificationLevel.EmployeeId = certification.EmployeeId;
                    certificationLevel.Position = employeeRecord.Engagement;
                    certificationLevel.HiredDate = employeeRecord.DateHired;
                    int tenureDays = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(employeeRecord.DateHired)).TotalDays);
                    int tenureYears = tenureDays / 365;
                    int tenuremonths = (tenureDays % 365) / 30;
                    certificationLevel.TenureYears = tenureYears;
                    certificationLevel.TenureMonths = tenuremonths;
                    certificationLevel.Tenure = $"{tenureYears} years {tenuremonths} months";
                    certificationLevel.CertificationDate = certification.CertificationDate;
                    certificationLevel.Status = "ACTIVE";
                    certificationLevel.OSVC_Score = (certification.OSVC_Score > 0)? $"{certification.OSVC_Score}%":(certification.OSVC_Score == 0? "N/A":string.Empty);
                    certificationLevel.OA_Score = (certification.OA_Score > 0) ? $"{certification.OA_Score}%" : (certification.OA_Score == 0 ? "N/A" : string.Empty);
                    certificationLevel.EM_Score = (certification.EM_Score > 0) ? $"{certification.EM_Score}%" : (certification.EM_Score == 0 ? "N/A" : string.Empty);
                    double average = 0;
                    if (employeeRecord.Engagement == ElsevierEngagement.RSOA.ToString())
                    {
                        double osvc_score = certification.OSVC_Score != null ? Convert.ToDouble(certification.OSVC_Score) : 0;
                        double oa_score = certification.OA_Score != null ? Convert.ToDouble(certification.OA_Score) : 0;
                        average = Math.Round(((osvc_score + oa_score) / 2),2);
                    }
                    else if ((employeeRecord.Engagement == ElsevierEngagement.RS1LS.ToString()) || (employeeRecord.Engagement == ElsevierEngagement.ECS.ToString()))
                    {
                        double osvc_score = certification.OSVC_Score != null ? Convert.ToDouble(certification.OSVC_Score) : 0;
                        double em_score = certification.EM_Score != null ? Convert.ToDouble(certification.EM_Score) : 0;
                        average = Math.Round(((osvc_score + em_score) / 2), 2);
                    }
                    certificationLevel.Average = (average > 0) ? $"{average}%" : (average == 0 ? "N/A" : string.Empty);
                    if(average>0)
                    {
                        var scoreLevel = categoryScoring.Where(c => average >= c.LowerScore && average < c.UpperScore).FirstOrDefault().Score;
                        certificationLevel.Level = scoreLevel.ToString();
                    }
                    else
                    {
                        certificationLevel.Level = "N/A";
                    }                                        
                    levelReport.Add(certificationLevel);
                }                                
            }
            return levelReport;
        }

        #endregion

        public vwSkillReport GetSkillMatrixReport1(SkillMatrixFilter filter = null)
        {
            if (filter == null)
            {
                filter = new SkillMatrixFilter();
                filter.AccountType = AccountType.Elsevier.ToString();
                int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
                int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
                int currentYear = DateTime.Today.Year;
                int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
                filter.Year = selectedYear;
                filter.Quarter = selectedQuarter;
                filter.PageNumber = 1;
            }

            vwSkillReport report = new vwSkillReport();
            report.SkillMatrixFilter = filter;
            report.lstAccountTypes = mtdGetAccountTypes();
            report.lstYears = mtdGetYears();
            report.lstQuarters = mtdGetQuarters();            
            report.lstCompetencyLevel = mtdGetCompetencyLevel();
            report.lstTenureLevel = mtdGetTenureLevel();

            var skillMatrices = GetEmployeeSkillMatrix(filter);
            report.lstTeams = mtdGetSkillMatrix1Teams(skillMatrices);

            if (!string.IsNullOrEmpty(filter.Team))
            {
                skillMatrices = skillMatrices.Where(s => s.Engagement.ToLower() == filter.Team.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.CompetencyLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.CompetencyLevel.ToLower() == filter.CompetencyLevel.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.TenureLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.TenureLevel.ToLower() == filter.TenureLevel.ToLower()).ToList();
            }
            if (skillMatrices.Count > 0)
            {
                var sortedList = skillMatrices.OrderBy(s => s.Engagement).ThenBy(s => s.AgentName).ToList();
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = sortedList.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;

                var paginatedData = sortedList.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedCompetencyLevels = paginatedData;
                report.EmployeeCompetencyLevels = sortedList;
            }
            return report;
        }

        private List<EmployeeCompetencyLevel> GetEmployeeSkillMatrix(SkillMatrixFilter filter)
        {
            DateTime dtFirstDay = new DateTime(filter.Year, 3 * filter.Quarter - 2, 1);
            var lastDayOfMonth = DateTime.DaysInMonth(filter.Year, 3 * filter.Quarter);
            DateTime dtLastDay = new DateTime(filter.Year, 3 * filter.Quarter, lastDayOfMonth);
            var employees = _skillMatrixRepository.GetEmployees().Where(e => e.AccountType == filter.AccountType).ToList();
            var certificationRecords = _skillMatrixRepository.GetCertificatiionRecordsByDate(dtFirstDay, dtLastDay).ToList(); 
            var csatRecords = _skillMatrixRepository.GetCSATRecordsByDate(dtFirstDay, dtLastDay).ToList();
            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate3(dtFirstDay, dtLastDay).ToList();
            var agentSummaryELSV = new List<vwQualityReportAgentSummaryELSV>();
            agentSummaryELSV = GetAgentSummaryReportELSV(qualityRatings, 92);

            var categoryScoring = _skillMatrixRepository.GetCategoryScoring().ToList();
            var competencyLevelScoring = _skillMatrixRepository.GetCompetencyLevelScoring().ToList();
            var tenureScoringLevel = _skillMatrixRepository.GetTenureLevel().ToList();
            List<EmployeeCompetencyLevel> employeeSkillMatrix = new List<EmployeeCompetencyLevel>();
            foreach (var employee in employees)
            {
                EmployeeCompetencyLevel employeeSkill = new EmployeeCompetencyLevel();
                employeeSkill.AccountType = AccountType.Elsevier.ToString();
                employeeSkill.AgentName = employee.Name;
                employeeSkill.EmployeeId = employee.SPIEmployeeNo;
                employeeSkill.Engagement = employee.Engagement;
                employeeSkill.DateHired = employee.DateHired;
                int tenureDays = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(employee.DateHired)).TotalDays);
                int tenureYears = tenureDays / 365;
                int tenuremonths = (tenureDays % 365) / 30;
                employeeSkill.TenureYears = tenureYears;
                employeeSkill.TenureMonths = tenuremonths;
                employeeSkill.Tenure = $"{tenureYears} years {tenuremonths} months";
                employeeSkill.CertificationScore = "N/A";
                employeeSkill.CertificationLevel = "N/A";
                employeeSkill.CSATScore = "N/A";
                employeeSkill.CSATLevel = "N/A";
                employeeSkill.QCScore = "N/A";
                employeeSkill.QCLevel = "N/A";

                var certification = certificationRecords.Where(c => c.EmployeeId.Trim().ToLower() == employee.SPIEmployeeNo.Trim().ToLower()).FirstOrDefault();
                if (certification != null)
                {
                    employeeSkill.CertificationDate = certification.CertificationDate;
                    var OSVC_Score = (certification.OSVC_Score > 0) ? $"{certification.OSVC_Score}%" : (certification.OSVC_Score == 0 ? "N/A" : string.Empty);
                    var OA_Score = (certification.OA_Score > 0) ? $"{certification.OA_Score}%" : (certification.OA_Score == 0 ? "N/A" : string.Empty);
                    var EM_Score = (certification.EM_Score > 0) ? $"{certification.EM_Score}%" : (certification.EM_Score == 0 ? "N/A" : string.Empty);
                    double average = 0;
                    if (employeeSkill.Engagement == ElsevierEngagement.RSOA.ToString())
                    {
                        double osvc_score = certification.OSVC_Score != null ? Convert.ToDouble(certification.OSVC_Score) : 0;
                        double oa_score = certification.OA_Score != null ? Convert.ToDouble(certification.OA_Score) : 0;
                        average = Math.Round(((osvc_score + oa_score) / 2), 2);
                    }
                    else if ((employeeSkill.Engagement == ElsevierEngagement.RS1LS.ToString()) || (employeeSkill.Engagement == ElsevierEngagement.ECS.ToString()))
                    {
                        double osvc_score = certification.OSVC_Score != null ? Convert.ToDouble(certification.OSVC_Score) : 0;
                        double em_score = certification.EM_Score != null ? Convert.ToDouble(certification.EM_Score) : 0;
                        average = Math.Round(((osvc_score + em_score) / 2), 2);
                    }
                    employeeSkill.CertificationScore = (average > 0) ? $"{average}%" : (average == 0 ? "N/A" : string.Empty);
                    if (average > 0)
                    {
                        var scoreLevel = categoryScoring.Where(c => average >= c.LowerScore && average < c.UpperScore).FirstOrDefault().Score;
                        employeeSkill.CertificationLevel = scoreLevel.ToString();
                    }                    
                }               
                
                if (csatRecords?.Count > 0)
                {
                    var csatScore = csatRecords.Where(c => c.EmployeeId.Trim().ToLower() == employee.SPIEmployeeNo.Trim().ToLower()).FirstOrDefault();
                    if (csatScore != null)
                    {
                        employeeSkill.CSATScore = (csatScore.CSATScore > 0) ? $"{csatScore.CSATScore}%" : "N/A";
                        if (csatScore.CSATScore > 0)
                        {
                            var scoreLevel = categoryScoring.Where(c => csatScore.CSATScore >= c.LowerScore && csatScore.CSATScore < c.UpperScore).FirstOrDefault().Score;
                            employeeSkill.CSATLevel = scoreLevel.ToString();
                        }                        
                    }
                }
                
                if (agentSummaryELSV?.Count > 0)
                {
                    var qaRecord = agentSummaryELSV.Where(q => q.EmployeeId.Trim().ToLower() == employee.SPIEmployeeNo.Trim().ToLower()).FirstOrDefault();
                    if(qaRecord!=null)
                    {
                        employeeSkill.QCScore = (qaRecord.Overall_QCScore> 0) ? $"{qaRecord.Overall_QCScore}%" : "N/A";
                        if (qaRecord.Overall_QCScore > 0)
                        {
                            var scoreLevel = categoryScoring.Where(c => qaRecord.Overall_QCScore >= c.LowerScore && qaRecord.Overall_QCScore < c.UpperScore).FirstOrDefault().Score;
                            employeeSkill.QCLevel = scoreLevel.ToString();
                        }                        
                    }
                }

                double certificationLevel = employeeSkill.CertificationLevel != "N/A" ? Convert.ToDouble(employeeSkill.CertificationLevel) : 0;
                double csatLevel = employeeSkill.CSATLevel != "N/A" ? Convert.ToDouble(employeeSkill.CSATLevel) : 0;
                double qcLevel = employeeSkill.QCLevel != "N/A" ? Convert.ToDouble(employeeSkill.QCLevel) : 0;

                List<double> scoreList = new List<double> { certificationLevel, csatLevel, qcLevel };
                scoreList.RemoveAll(s => s == 0);
                var scoreSum = scoreList.Sum();
                var scoreCount = scoreList.Count();
                double[] score = { certificationLevel, csatLevel, qcLevel };
                var overallScore = scoreCount>0 ? Math.Round((scoreSum / scoreCount), 2):0;
                employeeSkill.OverallScore = overallScore;
                employeeSkill.CompetencyLevel = competencyLevelScoring.Where(cl => overallScore >= cl.LowerScore && overallScore <= cl.UpperScore).FirstOrDefault().Level;
                var tenure = ((tenureYears * 12) + tenuremonths);
                var tenuteLevels = tenureScoringLevel.Where(t => tenure >= t.LowerScore && tenure <= t.UpperScore).ToList();
                if (tenuteLevels.Count > 1)
                {
                    bool isMatched = tenuteLevels.Any(t => t.Level.ToLower() == employeeSkill.CompetencyLevel.ToLower());
                    if (isMatched)
                    {
                        employeeSkill.TenurePlusCompetency = "Matched";
                        employeeSkill.TenureLevel = employeeSkill.CompetencyLevel;
                    }
                    else
                    {
                        employeeSkill.TenureLevel = tenuteLevels.FirstOrDefault().Level;
                        employeeSkill.TenurePlusCompetency = "For evaluation";
                    }
                }
                else
                {
                    employeeSkill.TenureLevel = tenuteLevels.FirstOrDefault().Level;
                    employeeSkill.TenurePlusCompetency = (employeeSkill.CompetencyLevel.ToLower() == employeeSkill.TenureLevel.ToLower()) ? "Matched" : "For evaluation";
                }
                employeeSkillMatrix.Add(employeeSkill);
            }
            return employeeSkillMatrix;
        }
    }
}

