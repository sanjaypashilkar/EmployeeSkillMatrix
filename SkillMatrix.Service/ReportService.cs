using ClosedXML.Excel;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
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

        public Dictionary<string, string> mtdGetDepartments()
        {
            var selectList = Enum.GetNames(typeof(Department)).ToList().Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetReportTypes()
        {
            var selectList = Enum.GetNames(typeof(ReportType)).ToList().Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public vwQualityReport GetQualityReport(QualityFilter filter = null)
        {
            if (filter == null)
            {
                filter = new QualityFilter();
                filter.StartDate = DateTime.Today.AddDays(-7).Date;
                filter.EndDate = DateTime.Today.Date;
                //filter.StartDate = new DateTime(2021, 08, 02).Date;
                //filter.EndDate = new DateTime(2021, 09, 05).Date;
                filter.Department = Department.CustomerService.ToString();
                filter.ReportType = ReportType.External.ToString();
                filter.TargetScore = 85;
                filter.PageNumber = 1;
            }

            vwQualityReport report = new vwQualityReport();
            report.QualityFilter = filter;
            report.lstDepartments = mtdGetDepartments();            
            report.lstReportType = mtdGetReportTypes();

            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate(filter.StartDate, filter.EndDate).ToList();            
            if (!string.IsNullOrEmpty(filter.Department))
            {
                qualityRatings = qualityRatings.Where(s => s.Department.ToLower() == filter.Department.ToLower()).ToList();
            }
            if (filter.ReportType == ReportType.Internal.ToString() || filter.ReportType == ReportType.External.ToString())
            {
                qualityRatings = qualityRatings.Where(s => s.CustomerType.ToLower() == filter.ReportType.ToLower()).ToList();
            }
            if (qualityRatings.Count > 0)
            {
                List<vwQualityReportSummary> reportSummaries = new List<vwQualityReportSummary>();
                if(filter.ReportType == ReportType.Internal.ToString() || filter.ReportType == ReportType.External.ToString())
                {
                    reportSummaries = GetCustomerTypeReport(qualityRatings, filter.ReportType, filter.TargetScore);
                }
                else if(filter.ReportType == ReportType.TicketStatus.ToString())
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
                filter.Department = Department.OrderManagement.ToString();
                filter.ReportType = ReportType.WeeklyLevelSummary.ToString();
                filter.TargetScore = 85;
                filter.PageNumber = 1;
            }

            vwQualityReport report = new vwQualityReport();
            report.QualityFilter = filter;
            report.lstDepartments = mtdGetDepartments();
            report.lstReportType = mtdGetReportTypes();

            var qualityRatings = _skillMatrixRepository.GetQualityRatingByDate2(filter.StartDate, filter.EndDate).ToList();            
            qualityRatings = qualityRatings.Where(s => s.Department.ToLower() == filter.Department.ToLower()).ToList();            
            if (qualityRatings.Count > 0)
            {
                if(filter.ReportType == ReportType.WeeklyLevelSummary.ToString())
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
                else
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
            }
            return report;
        }

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
            DateTime startRange = StartOfWeek(startDate, DayOfWeek.Monday);
            DateTime endRange = EndOfWeek(endDate, DayOfWeek.Sunday);
            for (var dt = startRange; dt <= endDate; dt = dt.AddDays(1))
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
    }
}
