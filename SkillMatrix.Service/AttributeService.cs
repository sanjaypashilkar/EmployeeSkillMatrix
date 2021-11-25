using ExcelDataReader;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SkillMatrix.Service
{
    public class AttributeService : IAttributeService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }
        public AttributeService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public Dictionary<string, string> mtdGetDepartments()
        {
            var departments = Helper.GetEnumValuesAndDescriptions<Department>();
            var selectList = departments.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public Dictionary<string, string> mtdGetAccountTypes()
        {
            var departments = Helper.GetEnumValuesAndDescriptions<AccountType>();
            var selectList = departments.ToList().Select(i => new { key = i.Key.ToString(), value = i.Value.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public vwImportAndSaveQualityRating GetUploadedQualityRating(FileInput fileInput)
        {
            vwImportAndSaveQualityRating importAndSaveQuality = new vwImportAndSaveQualityRating();
            importAndSaveQuality.lstDepartments = mtdGetDepartments();
            importAndSaveQuality.lstAccountTypes = mtdGetAccountTypes();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (fileInput.AccountType == AccountType.SpringerNature.ToString())
            {
                if (fileInput.Department == Department.CompCopy.ToString() || fileInput.Department == Department.OrderManagement.ToString())
                {
                    using (FileStream stream = new FileStream(fileInput.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            while (reader.Read())
                            {
                                if (reader.Depth != 0)
                                {
                                    string name = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : string.Empty;
                                    string employeeId = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                                    if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(employeeId))
                                        break;
                                    var group = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                                    var teamLeader = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                                    var taskCompletionDate = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                                    var auditedDate = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                                    var process = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                                    var errorType = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;
                                    var checkerRemark = reader.GetValue(8) != null ? reader.GetValue(8).ToString().Trim() : string.Empty;
                                    var modified = reader.GetValue(9) != null ? reader.GetValue(9).ToString().Trim() : string.Empty;
                                    var ticketNumber = reader.GetValue(10) != null ? reader.GetValue(10).ToString().Trim() : string.Empty;
                                    var shift = reader.GetValue(11) != null ? reader.GetValue(11).ToString().Trim() : string.Empty;
                                    var lines = reader.GetValue(12) != null ? reader.GetValue(12).ToString().Trim() : string.Empty;
                                    var issueType = reader.GetValue(13) != null ? reader.GetValue(13).ToString().Trim() : string.Empty;
                                    var tlAnalysis = reader.GetValue(14) != null ? reader.GetValue(14).ToString().Trim() : string.Empty;
                                    var level1Opportunity = reader.GetValue(15) != null ? reader.GetValue(15).ToString().Trim() : string.Empty;
                                    var level2Opportunity = reader.GetValue(16) != null ? reader.GetValue(16).ToString().Trim() : string.Empty;
                                    var rootCause = reader.GetValue(17) != null ? reader.GetValue(17).ToString().Trim() : string.Empty;
                                    var correctiveAction = reader.GetValue(18) != null ? reader.GetValue(18).ToString().Trim() : string.Empty;
                                    var preventiveAction = reader.GetValue(19) != null ? reader.GetValue(19).ToString().Trim() : string.Empty;
                                    var processChange = reader.GetValue(20) != null ? reader.GetValue(20).ToString().Trim() : string.Empty;
                                    var effectivenessVerification = reader.GetValue(21) != null ? reader.GetValue(21).ToString().Trim() : string.Empty;
                                    var auditResult = reader.GetValue(22) != null ? reader.GetValue(22).ToString().Trim() : string.Empty;
                                    var doiVerification = reader.GetValue(23) != null ? reader.GetValue(23).ToString().Trim() : string.Empty;
                                    var isCorrect = reader.GetValue(24) != null ? reader.GetValue(24).ToString().Trim() : string.Empty;
                                    var isError = reader.GetValue(25) != null ? reader.GetValue(25).ToString().Trim() : string.Empty;
                                    var weekRange = reader.GetValue(26) != null ? reader.GetValue(26).ToString().Trim() : string.Empty;
                                    var date = reader.GetValue(27) != null ? reader.GetValue(27).ToString().Trim() : string.Empty;
                                    var volume = reader.GetValue(28) != null ? reader.GetValue(28).ToString().Trim() : string.Empty;
                                    var counter = reader.GetValue(29) != null ? reader.GetValue(29).ToString().Trim() : string.Empty;
                                    var empIdDate = reader.GetValue(30) != null ? reader.GetValue(30).ToString().Trim() : string.Empty;

                                    importAndSaveQuality.QualityRatings2.Add(new vwQualityRating2
                                    {
                                        Name = name,
                                        EmployeeId = employeeId,
                                        Group = group,
                                        TeamLeader = teamLeader,
                                        TaskCompletionDate = Convert.ToDateTime(taskCompletionDate),
                                        AuditedDate = Convert.ToDateTime(auditedDate),
                                        Process = process,
                                        ErrorType = errorType,
                                        CheckerRemarks = checkerRemark,
                                        Modified = modified,
                                        TicketNumber = ticketNumber,
                                        Shift = shift,
                                        Lines = lines,
                                        IssueType = issueType,
                                        TLAnalysis = tlAnalysis,
                                        Level1Opportunity = level1Opportunity,
                                        Level2Opportunity = level2Opportunity,
                                        RootCause = rootCause,
                                        CorrectiveAction = correctiveAction,
                                        PreventiveAction = preventiveAction,
                                        ProcessChange = processChange,
                                        EffectivenessVerification = effectivenessVerification,
                                        AuditResult = auditResult,
                                        DOIVerification = doiVerification,
                                        IsCorrect = isCorrect,
                                        IsError = isError,
                                        WeekRange = weekRange,
                                        Date = date,
                                        Volume = volume,
                                        Counter = counter,
                                        EmpIdDate = empIdDate
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (FileStream stream = new FileStream(fileInput.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            while (reader.Read())
                            {
                                if (reader.Depth != 0)
                                {
                                    string agentName = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : string.Empty;
                                    string employeeId = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                                    string taskCompletionDate = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                                    if (string.IsNullOrEmpty(agentName) && string.IsNullOrEmpty(taskCompletionDate))
                                        break;
                                    var qaDate = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                                    var region = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                                    var ticketNumber = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                                    var ticketStatus = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                                    var requestReason = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;
                                    var customerType = reader.GetValue(8) != null ? reader.GetValue(8).ToString().Trim() : string.Empty;
                                    var adherenceScore = reader.GetValue(9) != null ? reader.GetValue(9).ToString().Trim() : string.Empty;
                                    var emailScore = reader.GetValue(10) != null ? reader.GetValue(10).ToString().Trim() : string.Empty;
                                    var resolutionScore = reader.GetValue(11) != null ? reader.GetValue(11).ToString().Trim() : string.Empty;
                                    var toneScore = reader.GetValue(12) != null ? reader.GetValue(12).ToString().Trim() : string.Empty;
                                    var remark = reader.GetValue(13) != null ? reader.GetValue(13).ToString().Trim() : string.Empty;
                                    var totalScore = reader.GetValue(14) != null ? reader.GetValue(14).ToString().Trim() : string.Empty;
                                    var QTPName = reader.GetValue(15) != null ? reader.GetValue(15).ToString().Trim() : string.Empty;
                                    var QTPEmployeeId = reader.GetValue(16) != null ? reader.GetValue(16).ToString().Trim() : string.Empty;

                                    var scncTeam = reader.GetValue(17) != null ? reader.GetValue(17).ToString().Trim() : string.Empty;
                                    var QTPAdherence = reader.GetValue(18) != null ? reader.GetValue(18).ToString().Trim() : string.Empty;

                                    var QTPVariance = reader.GetValue(24) != null ? reader.GetValue(24).ToString().Trim() : string.Empty;
                                    var QTPOverallExp = reader.GetValue(25) != null ? reader.GetValue(25).ToString().Trim() : string.Empty;

                                    importAndSaveQuality.QualityRatings.Add(new vwQualityRating
                                    {
                                        Team = TeamForReviews.Straive.ToString(),
                                        AgentName = agentName,
                                        EmployeeId = employeeId,
                                        TaskCompletionDate = Convert.ToDateTime(taskCompletionDate),
                                        QADate = Convert.ToDateTime(qaDate),
                                        Region = region,
                                        TicketNumber = ticketNumber,
                                        TicketStatus = ticketStatus,
                                        RequestReason = requestReason,
                                        CustomerType = customerType,
                                        ProcessAdheranceScore = adherenceScore,
                                        EmailHandlingScore = emailScore,
                                        ResolutionScore = resolutionScore,
                                        ToneScore = toneScore,
                                        StraiveTotalScore = totalScore,
                                        Remarks = remark,
                                        QTPName = QTPName,
                                        QTPEmployeeId = QTPEmployeeId,
                                        Variance = QTPVariance,
                                        OverallExperience = QTPOverallExp
                                    });

                                    if (!string.IsNullOrEmpty(scncTeam) && !string.IsNullOrEmpty(QTPAdherence))
                                    {
                                        var QTPemailScore = reader.GetValue(19) != null ? reader.GetValue(19).ToString().Trim() : string.Empty;
                                        var QTPResolutionScore = reader.GetValue(20) != null ? reader.GetValue(20).ToString().Trim() : string.Empty;
                                        var QTPToneScore = reader.GetValue(21) != null ? reader.GetValue(21).ToString().Trim() : string.Empty;
                                        var QTPRemarks = reader.GetValue(22) != null ? reader.GetValue(22).ToString().Trim() : string.Empty;
                                        var QTPTotalScore = reader.GetValue(23) != null ? reader.GetValue(23).ToString().Trim() : string.Empty;

                                        importAndSaveQuality.QualityRatings.Add(new vwQualityRating
                                        {
                                            Team = TeamForReviews.SpringerNature.ToString(),
                                            AgentName = QTPName,
                                            EmployeeId = QTPEmployeeId,
                                            TaskCompletionDate = Convert.ToDateTime(taskCompletionDate),
                                            QADate = Convert.ToDateTime(qaDate),
                                            Region = region,
                                            TicketNumber = ticketNumber,
                                            TicketStatus = ticketStatus,
                                            RequestReason = requestReason,
                                            CustomerType = customerType,
                                            ProcessAdheranceScore = QTPAdherence,
                                            EmailHandlingScore = QTPemailScore,
                                            ResolutionScore = QTPResolutionScore,
                                            ToneScore = QTPToneScore,
                                            StraiveTotalScore = totalScore,
                                            Remarks = QTPRemarks,
                                            QTPName = scncTeam,
                                            Variance = QTPVariance,
                                            OverallExperience = QTPOverallExp
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                using (FileStream stream = new FileStream(fileInput.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            if (reader.Depth != 0 && reader.Depth != 1)
                            {
                                string month = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : string.Empty;
                                string date = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                                string teamLead = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                                var agent = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                                var employeeId = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                                if (string.IsNullOrEmpty(employeeId) || string.IsNullOrEmpty(agent))
                                    break;
                                var cf1_ptsEarned = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                                var cf1_totalEarned = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                                var cf2_ptsEarned = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;
                                var cf2_totalEarned = reader.GetValue(8) != null ? reader.GetValue(8).ToString().Trim() : string.Empty;
                                var cf3_ptsEarned = reader.GetValue(9) != null ? reader.GetValue(9).ToString().Trim() : string.Empty;
                                var cf3_totalEarned = reader.GetValue(10) != null ? reader.GetValue(10).ToString().Trim() : string.Empty;
                                var cf4_ptsEarned = reader.GetValue(11) != null ? reader.GetValue(11).ToString().Trim() : string.Empty;
                                var cf4_totalEarned = reader.GetValue(12) != null ? reader.GetValue(12).ToString().Trim() : string.Empty;
                                var sf1_ptsEarned = reader.GetValue(13) != null ? reader.GetValue(13).ToString().Trim() : string.Empty;
                                var sf1_totalEarned = reader.GetValue(14) != null ? reader.GetValue(14).ToString().Trim() : string.Empty;
                                var sf2_ptsEarned = reader.GetValue(15) != null ? reader.GetValue(15).ToString().Trim() : string.Empty;
                                var sf2_totalEarned = reader.GetValue(16) != null ? reader.GetValue(16).ToString().Trim() : string.Empty;
                                var sf3_ptsEarned = reader.GetValue(17) != null ? reader.GetValue(17).ToString().Trim() : string.Empty;
                                var sf3_totalEarned = reader.GetValue(18) != null ? reader.GetValue(18).ToString().Trim() : string.Empty;
                                var bp1_ptsEarned = reader.GetValue(19) != null ? reader.GetValue(19).ToString().Trim() : string.Empty;
                                var bp1_totalEarned = reader.GetValue(20) != null ? reader.GetValue(20).ToString().Trim() : string.Empty;
                                var bp2_ptsEarned = reader.GetValue(21) != null ? reader.GetValue(21).ToString().Trim() : string.Empty;
                                var bp2_totalEarned = reader.GetValue(22) != null ? reader.GetValue(22).ToString().Trim() : string.Empty;
                                var bp3_ptsEarned = reader.GetValue(23) != null ? reader.GetValue(23).ToString().Trim() : string.Empty;
                                var bp3_totalEarned = reader.GetValue(24) != null ? reader.GetValue(24).ToString().Trim() : string.Empty;
                                var ic1_ptsEarned = reader.GetValue(25) != null ? reader.GetValue(25).ToString().Trim() : string.Empty;
                                var ic1_totalEarned = reader.GetValue(26) != null ? reader.GetValue(26).ToString().Trim() : string.Empty;
                                var ic2_ptsEarned = reader.GetValue(27) != null ? reader.GetValue(27).ToString().Trim() : string.Empty;
                                var ic2_totalEarned = reader.GetValue(28) != null ? reader.GetValue(28).ToString().Trim() : string.Empty;
                                var ic3_ptsEarned = reader.GetValue(29) != null ? reader.GetValue(29).ToString().Trim() : string.Empty;
                                var ic3_totalEarned = reader.GetValue(30) != null ? reader.GetValue(30).ToString().Trim() : string.Empty;
                                var ic4_ptsEarned = reader.GetValue(31) != null ? reader.GetValue(31).ToString().Trim() : string.Empty;
                                var ic4_totalEarned = reader.GetValue(32) != null ? reader.GetValue(32).ToString().Trim() : string.Empty;
                                var passiveSurvey = reader.GetValue(33) != null ? reader.GetValue(33).ToString().Trim() : string.Empty;
                                if(passiveSurvey.ToUpper().Contains("N/A"))
                                {
                                    passiveSurvey = passiveSurvey.ToUpper().Replace("N/A", string.Empty).Trim();
                                }
                                if(passiveSurvey.ToUpper().Contains("%"))
                                {
                                    passiveSurvey = passiveSurvey.ToUpper().Replace("%", string.Empty).Trim();
                                }
                                var csatScore = reader.GetValue(34) != null ? reader.GetValue(34).ToString().Trim() : string.Empty;
                                if (csatScore.ToUpper().Contains("N/A"))
                                {
                                    csatScore = csatScore.ToUpper().Replace("N/A", string.Empty).Trim();
                                }
                                if (csatScore.ToUpper().Contains("%"))
                                {
                                    csatScore = csatScore.ToUpper().Replace("%", string.Empty).Trim();
                                }
                                var noOfPplOpportunity = reader.GetValue(35) != null ? reader.GetValue(35).ToString().Trim() : string.Empty;
                                var remarks = reader.GetValue(36) != null ? reader.GetValue(36).ToString().Trim() : string.Empty;
                                double doubleValue = 0;
                                int intValue = 0;

                                string Month = month;
                                DateTime Date = Convert.ToDateTime(date);
                                string TeamLead = teamLead;
                                string AgentName = agent;
                                string EmployeeId = employeeId;
                                int CF1_PointsEarned = Int32.TryParse(cf1_ptsEarned, out intValue) ? Convert.ToInt32(cf1_ptsEarned) : 0;
                                int CF1_TotalPoints = Int32.TryParse(cf1_totalEarned, out intValue) ? Convert.ToInt32(cf1_totalEarned) : 0;
                                int CF2_PointsEarned = Int32.TryParse(cf2_ptsEarned, out intValue) ? Convert.ToInt32(cf2_ptsEarned) : 0;
                                int CF2_TotalPoints = Int32.TryParse(cf2_totalEarned, out intValue) ? Convert.ToInt32(cf2_totalEarned) : 0;
                                int CF3_PointsEarned = Int32.TryParse(cf3_ptsEarned, out intValue) ? Convert.ToInt32(cf3_ptsEarned) : 0;
                                int CF3_TotalPoints = Int32.TryParse(cf3_totalEarned, out intValue) ? Convert.ToInt32(cf3_totalEarned) : 0;
                                int CF4_PointsEarned = Int32.TryParse(cf4_ptsEarned, out intValue) ? Convert.ToInt32(cf4_ptsEarned) : 0;
                                int CF4_TotalPoints = Int32.TryParse(cf4_totalEarned, out intValue) ? Convert.ToInt32(cf4_totalEarned) : 0;
                                int SF1_PointsEarned = Int32.TryParse(sf1_ptsEarned, out intValue) ? Convert.ToInt32(sf1_ptsEarned) : 0;
                                int SF1_TotalPoints = Int32.TryParse(sf1_totalEarned, out intValue) ? Convert.ToInt32(sf1_totalEarned) : 0;
                                int SF2_PointsEarned = Int32.TryParse(sf2_ptsEarned, out intValue) ? Convert.ToInt32(sf2_ptsEarned) : 0;
                                int SF2_TotalPoints = Int32.TryParse(sf2_totalEarned, out intValue) ? Convert.ToInt32(sf2_totalEarned) : 0;
                                int SF3_PointsEarned = Int32.TryParse(sf3_ptsEarned, out intValue) ? Convert.ToInt32(sf3_ptsEarned) : 0;
                                int SF3_TotalPoints = Int32.TryParse(sf3_totalEarned, out intValue) ? Convert.ToInt32(sf3_totalEarned) : 0;
                                int BP1_PointsEarned = Int32.TryParse(bp1_ptsEarned, out intValue) ? Convert.ToInt32(bp1_ptsEarned) : 0;
                                int BP1_TotalPoints = Int32.TryParse(bp1_totalEarned, out intValue) ? Convert.ToInt32(bp1_totalEarned) : 0;
                                int BP2_PointsEarned = Int32.TryParse(bp2_ptsEarned, out intValue) ? Convert.ToInt32(bp2_ptsEarned) : 0;
                                int BP2_TotalPoints = Int32.TryParse(bp2_totalEarned, out intValue) ? Convert.ToInt32(bp2_totalEarned) : 0;
                                int BP3_PointsEarned = Int32.TryParse(bp3_ptsEarned, out intValue) ? Convert.ToInt32(bp3_ptsEarned) : 0;
                                int BP3_TotalPoints = Int32.TryParse(bp3_totalEarned, out intValue) ? Convert.ToInt32(bp3_totalEarned) : 0;
                                int IC1_PointsEarned = Int32.TryParse(ic1_ptsEarned, out intValue) ? Convert.ToInt32(ic1_ptsEarned) : 0;
                                int IC1_TotalPoints = Int32.TryParse(ic1_totalEarned, out intValue) ? Convert.ToInt32(ic1_totalEarned) : 0;
                                int IC2_PointsEarned = Int32.TryParse(ic2_ptsEarned, out intValue) ? Convert.ToInt32(ic2_ptsEarned) : 0;
                                int IC2_TotalPoints = Int32.TryParse(ic2_totalEarned, out intValue) ? Convert.ToInt32(ic2_totalEarned) : 0;
                                int IC3_PointsEarned = Int32.TryParse(ic3_ptsEarned, out intValue) ? Convert.ToInt32(ic3_ptsEarned) : 0;
                                int IC3_TotalPoints = Int32.TryParse(ic3_totalEarned, out intValue) ? Convert.ToInt32(ic3_totalEarned) : 0;
                                int IC4_PointsEarned = Int32.TryParse(ic4_ptsEarned, out intValue) ? Convert.ToInt32(ic4_ptsEarned) : 0;
                                int IC4_TotalPoints = Int32.TryParse(ic4_totalEarned, out intValue) ? Convert.ToInt32(ic4_totalEarned) : 0;
                                double PassiveSurvey = Double.TryParse(passiveSurvey, out doubleValue) ? Convert.ToDouble(passiveSurvey) : 0;
                                double CSATScore = Double.TryParse(csatScore, out doubleValue) ? Convert.ToDouble(csatScore) : 0;
                                int NoOfPplOpportunity = Int32.TryParse(noOfPplOpportunity, out intValue) ? Convert.ToInt32(noOfPplOpportunity) : 0;
                                string Remarks = remarks;

                                importAndSaveQuality.QualityRatings3.Add(new vwQualityRating3
                                {
                                    Month = Month,
                                    Date = Date,
                                    TeamLead = TeamLead,
                                    AgentName = AgentName,
                                    EmployeeId = EmployeeId,
                                    CF1_PointsEarned = CF1_PointsEarned,
                                    CF1_TotalPoints = CF1_TotalPoints,
                                    CF2_PointsEarned = CF2_PointsEarned,
                                    CF2_TotalPoints = CF2_TotalPoints,
                                    CF3_PointsEarned = CF3_PointsEarned,
                                    CF3_TotalPoints = CF3_TotalPoints,
                                    CF4_PointsEarned = CF4_PointsEarned,
                                    CF4_TotalPoints = CF4_TotalPoints,
                                    SF1_PointsEarned = SF1_PointsEarned,
                                    SF1_TotalPoints = SF1_TotalPoints,
                                    SF2_PointsEarned = SF2_PointsEarned,
                                    SF2_TotalPoints = SF2_TotalPoints,
                                    SF3_PointsEarned = SF3_PointsEarned,
                                    SF3_TotalPoints = SF3_TotalPoints,
                                    BP1_PointsEarned = BP1_PointsEarned,
                                    BP1_TotalPoints = BP1_TotalPoints,
                                    BP2_PointsEarned = BP2_PointsEarned,
                                    BP2_TotalPoints = BP2_TotalPoints,
                                    BP3_PointsEarned = BP3_PointsEarned,
                                    BP3_TotalPoints = BP3_TotalPoints,
                                    IC1_PointsEarned = IC1_PointsEarned,
                                    IC1_TotalPoints = IC1_TotalPoints,
                                    IC2_PointsEarned = IC2_PointsEarned,
                                    IC2_TotalPoints = IC2_TotalPoints,
                                    IC3_PointsEarned = IC3_PointsEarned,
                                    IC3_TotalPoints = IC3_TotalPoints,
                                    IC4_PointsEarned = IC4_PointsEarned,
                                    IC4_TotalPoints = IC4_TotalPoints,
                                    PassiveSurvey = Math.Round((PassiveSurvey * 100),2),
                                    CSATScore = Math.Round((CSATScore * 100),2),
                                    NoOfPplOpportunity = NoOfPplOpportunity,
                                    Remarks = Remarks
                                });
                            }
                        }
                    }
                }
            }
            return importAndSaveQuality;
        }

        public void SaveQualityRatings(FileInput fileInput)
        {
            var importAndSave = GetUploadedQualityRating(fileInput);
            if (fileInput.AccountType == AccountType.SpringerNature.ToString())
            {
                if (fileInput.Department == Department.CompCopy.ToString() || fileInput.Department == Department.OrderManagement.ToString())
                {
                    List<QualityRating2> qualityRatings = new List<QualityRating2>();
                    foreach (var qualityRating in importAndSave.QualityRatings2)
                    {
                        QualityRating2 rating = new QualityRating2();
                        rating.AccountType = fileInput.AccountType;
                        rating.Department = fileInput.Department;
                        rating.Name = qualityRating.Name;
                        rating.EmployeeId = qualityRating.EmployeeId;
                        rating.Group = qualityRating.Group;
                        rating.TeamLeader = qualityRating.TeamLeader;
                        rating.TaskCompletionDate = qualityRating.TaskCompletionDate;
                        rating.AuditedDate = qualityRating.AuditedDate;
                        rating.Process = qualityRating.Process;
                        rating.ErrorType = qualityRating.ErrorType;
                        rating.CheckerRemarks = qualityRating.CheckerRemarks;
                        rating.Modified = qualityRating.Modified;
                        rating.TicketNumber = qualityRating.TicketNumber;
                        rating.Shift = qualityRating.Shift;
                        rating.Lines = Convert.ToInt32(qualityRating.Lines);
                        rating.IssueType = qualityRating.IssueType;
                        rating.TLAnalysis = qualityRating.TLAnalysis;
                        rating.Level1Opportunity = qualityRating.Level1Opportunity;
                        rating.Level2Opportunity = qualityRating.Level2Opportunity;
                        rating.RootCause = qualityRating.RootCause;
                        rating.CorrectiveAction = qualityRating.CorrectiveAction;
                        rating.PreventiveAction = qualityRating.PreventiveAction;
                        rating.ProcessChange = qualityRating.ProcessChange;
                        rating.EffectivenessVerification = qualityRating.EffectivenessVerification;
                        rating.AuditResult = qualityRating.AuditResult;
                        rating.DOIVerification = qualityRating.DOIVerification;
                        rating.IsCorrect = Convert.ToBoolean(Convert.ToInt32(qualityRating.IsCorrect));
                        rating.IsError = Convert.ToBoolean(Convert.ToInt32(qualityRating.IsError));
                        rating.WeekRange = qualityRating.WeekRange;
                        rating.Date = qualityRating.Date;
                        rating.Volume = string.IsNullOrEmpty(qualityRating.Volume) ? 0 : Convert.ToDouble(qualityRating.Volume);
                        rating.Counter = Convert.ToInt32(qualityRating.Counter);
                        rating.EmpIdDate = qualityRating.EmpIdDate;
                        rating.Date = qualityRating.Date;
                        rating.RecordDate = Convert.ToDateTime(fileInput.RecordDate).Date;
                        rating.CreatedDate = DateTime.Now;
                        qualityRatings.Add(rating);
                    }
                    if (qualityRatings.Count > 0)
                    {
                        _skillMatrixRepository.SaveQualityRating(qualityRatings);
                    }
                }
                else
                {
                    List<QualityRating> qualityRatings = new List<QualityRating>();
                    foreach (var qualityRating in importAndSave.QualityRatings)
                    {
                        QualityRating rating = new QualityRating();
                        rating.AccountType = fileInput.AccountType;
                        rating.Department = fileInput.Department;
                        rating.Team = qualityRating.Team;
                        rating.AgentName = qualityRating.AgentName;
                        rating.EmployeeId = qualityRating.EmployeeId;
                        rating.TaskCompletionDate = qualityRating.TaskCompletionDate;
                        rating.QADate = qualityRating.QADate;
                        rating.Region = qualityRating.Region;
                        rating.TicketNumber = qualityRating.TicketNumber;
                        rating.TicketStatus = qualityRating.TicketStatus;
                        rating.RequestReason = qualityRating.RequestReason;
                        rating.CustomerType = qualityRating.CustomerType;
                        rating.ProcessAdheranceScore = Convert.ToDouble(qualityRating.ProcessAdheranceScore);
                        rating.EmailHandlingScore = Convert.ToDouble(qualityRating.EmailHandlingScore);
                        rating.ResolutionScore = Convert.ToDouble(qualityRating.ResolutionScore);
                        rating.ToneScore = Convert.ToDouble(qualityRating.ToneScore);
                        rating.Remarks = qualityRating.Remarks;
                        rating.TotalScore = (rating.ProcessAdheranceScore + rating.EmailHandlingScore + rating.ResolutionScore + rating.ToneScore);
                        rating.StraiveTotalScore = Convert.ToDouble(qualityRating.StraiveTotalScore);
                        rating.QTPName = qualityRating.QTPName;
                        rating.QTPEmployeeId = qualityRating.QTPEmployeeId;
                        rating.Variance = !string.IsNullOrEmpty(qualityRating.Variance) ? Convert.ToDouble(qualityRating.Variance) : 0;
                        rating.OverallExperience = qualityRating.OverallExperience;
                        rating.RecordDate = Convert.ToDateTime(fileInput.RecordDate).Date;
                        rating.CreatedDate = DateTime.Now;
                        qualityRatings.Add(rating);
                    }
                    if (qualityRatings.Count > 0)
                    {
                        _skillMatrixRepository.SaveQualityRating(qualityRatings);
                    }
                }
            }
            else
            {
                List<QualityRating3> qualityRatings = new List<QualityRating3>();
                foreach (var qualityRating in importAndSave.QualityRatings3)
                {
                    QualityRating3 rating = new QualityRating3();
                    rating.AccountType = fileInput.AccountType;
                    rating.Date = qualityRating.Date;
                    rating.Month = qualityRating.Month;
                    rating.TeamLead = qualityRating.TeamLead;
                    rating.AgentName = qualityRating.AgentName;
                    rating.EmployeeId = qualityRating.EmployeeId;
                    rating.CF1_PointsEarned = qualityRating.CF1_PointsEarned;
                    rating.CF1_TotalPoints = qualityRating.CF1_TotalPoints;
                    rating.CF2_PointsEarned = qualityRating.CF2_PointsEarned;
                    rating.CF2_TotalPoints = qualityRating.CF2_TotalPoints;
                    rating.CF3_PointsEarned = qualityRating.CF3_PointsEarned;
                    rating.CF3_TotalPoints = qualityRating.CF3_TotalPoints;
                    rating.CF4_PointsEarned = qualityRating.CF4_PointsEarned;
                    rating.CF4_TotalPoints = qualityRating.CF4_TotalPoints;
                    rating.SF1_PointsEarned = qualityRating.SF1_PointsEarned;
                    rating.SF1_TotalPoints = qualityRating.SF1_TotalPoints;
                    rating.SF2_PointsEarned = qualityRating.SF2_PointsEarned;
                    rating.SF2_TotalPoints = qualityRating.SF2_TotalPoints;
                    rating.SF3_PointsEarned = qualityRating.SF3_PointsEarned;
                    rating.SF3_TotalPoints = qualityRating.SF3_TotalPoints;
                    rating.BP1_PointsEarned = qualityRating.BP1_PointsEarned;
                    rating.BP1_TotalPoints = qualityRating.BP1_TotalPoints;
                    rating.BP2_PointsEarned = qualityRating.BP2_PointsEarned;
                    rating.BP2_TotalPoints = qualityRating.BP2_TotalPoints;
                    rating.BP3_PointsEarned = qualityRating.BP3_PointsEarned;
                    rating.BP3_TotalPoints = qualityRating.BP3_TotalPoints;
                    rating.IC1_PointsEarned = qualityRating.IC1_PointsEarned;
                    rating.IC1_TotalPoints = qualityRating.IC1_TotalPoints;
                    rating.IC2_PointsEarned = qualityRating.IC2_PointsEarned;
                    rating.IC2_TotalPoints = qualityRating.IC2_TotalPoints;
                    rating.IC3_PointsEarned = qualityRating.IC3_PointsEarned;
                    rating.IC3_TotalPoints = qualityRating.IC3_TotalPoints;
                    rating.IC4_PointsEarned = qualityRating.IC4_PointsEarned;
                    rating.IC4_TotalPoints = qualityRating.IC4_TotalPoints;
                    rating.PassiveSurvey = qualityRating.PassiveSurvey;
                    rating.CSATScore = qualityRating.CSATScore;
                    rating.NoOfPplOpportunity = qualityRating.NoOfPplOpportunity;
                    rating.Remarks = qualityRating.Remarks;                    
                    rating.RecordDate = Convert.ToDateTime(fileInput.RecordDate).Date;
                    rating.CreatedDate = DateTime.Now;
                    qualityRatings.Add(rating);
                }
                if (qualityRatings.Count > 0)
                {
                    _skillMatrixRepository.SaveQualityRating(qualityRatings);
                }
            }
        }

        public vwImportAndSaveTicketingTool GetUploadedTicketingRecords(string fileName)
        {
            vwImportAndSaveTicketingTool importAndSaveTicketingRecords = new vwImportAndSaveTicketingTool();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth != 0)
                        {
                            string date = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : string.Empty;
                            string status = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                            string ticketNumber = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                            if (string.IsNullOrEmpty(ticketNumber) && string.IsNullOrEmpty(status))
                                break;
                            var team = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                            var comment = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                            var additionalComments = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                            var concernedRep = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                            var remarks = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;

                            importAndSaveTicketingRecords.TicketingTools.Add(new vwTicketingTool
                            {
                                Date = Convert.ToDateTime(date),
                                Status = status,
                                TicketNumber = Convert.ToInt32(ticketNumber),
                                Team = team,
                                Comment = comment,
                                AdditionalComments = additionalComments,
                                ConcernedRep = concernedRep,
                                Remarks = remarks,                                
                            });
                        }
                    }
                }
            }
            return importAndSaveTicketingRecords;
        }

        public void SaveTicketingRecords(string fileName, string recordDate)
        {
            var importAndSave = GetUploadedTicketingRecords(fileName);
            List<TicketingTool> ticketingRecords = new List<TicketingTool>();
            foreach (var ticketingRecord in importAndSave.TicketingTools)
            {
                TicketingTool record = new TicketingTool();
                record.AccountType = AccountType.SpringerNature.ToString();
                record.Date = ticketingRecord.Date;
                record.Status = ticketingRecord.Status;
                record.TicketNumber = ticketingRecord.TicketNumber;
                record.Team = ticketingRecord.Team;
                record.Comment = ticketingRecord.Comment;
                record.AdditionalComments = ticketingRecord.AdditionalComments;
                record.ConcernedRep = ticketingRecord.ConcernedRep;
                record.Remarks = ticketingRecord.Remarks;
                record.RecordDate = Convert.ToDateTime(recordDate).Date;
                record.CreatedDate = DateTime.Now;
                ticketingRecords.Add(record);
            }
            if (ticketingRecords.Count > 0)
            {
                _skillMatrixRepository.SaveTicketingRecords(ticketingRecords);
            }
        }

        public vwImportAndSaveBusinessPartner GetUploadedBusinessPartnerRecords(string fileName)
        {
            vwImportAndSaveBusinessPartner importAndSaveBusinessPartnerRecords = new vwImportAndSaveBusinessPartner();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth != 0)
                        {
                            string date = reader.GetValue(0) != null ? reader.GetValue(0).ToString().Trim() : DateTime.MinValue.ToString();
                            var team = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                            if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(team))
                                break;

                            string comments = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                            string modified = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                            var valid = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                            var TLRemark = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                            var bpNumber = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                            var partnerCatagory = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;
                            var partnerType = reader.GetValue(8) != null ? reader.GetValue(8).ToString().Trim() : string.Empty;

                            var title = reader.GetValue(9) != null ? reader.GetValue(9).ToString().Trim() : string.Empty;
                            var name1 = reader.GetValue(10) != null ? reader.GetValue(10).ToString().Trim() : string.Empty;
                            var name2 = reader.GetValue(11) != null ? reader.GetValue(11).ToString().Trim() : string.Empty;
                            var name3 = reader.GetValue(12) != null ? reader.GetValue(12).ToString().Trim() : string.Empty;
                            var lastName = reader.GetValue(13) != null ? reader.GetValue(13).ToString().Trim() : string.Empty;
                            var firstName = reader.GetValue(14) != null ? reader.GetValue(14).ToString().Trim() : string.Empty;
                            var institute1 = reader.GetValue(15) != null ? reader.GetValue(15).ToString().Trim() : string.Empty;
                            var institute2 = reader.GetValue(16) != null ? reader.GetValue(16).ToString().Trim() : string.Empty;
                            var street = reader.GetValue(17) != null ? reader.GetValue(17).ToString().Trim() : string.Empty;
                            var houseNumber = reader.GetValue(18) != null ? reader.GetValue(18).ToString().Trim() : string.Empty;
                            var postalCode1 = reader.GetValue(19) != null ? reader.GetValue(19).ToString().Trim() : string.Empty;
                            var poBox = reader.GetValue(20) != null ? reader.GetValue(20).ToString().Trim() : string.Empty;
                            var postalCode2 = reader.GetValue(21) != null ? reader.GetValue(21).ToString().Trim() : string.Empty;
                            var city = reader.GetValue(22) != null ? reader.GetValue(22).ToString().Trim() : string.Empty;
                            var countryKey = reader.GetValue(23) != null ? reader.GetValue(23).ToString().Trim() : string.Empty;
                            var emailAddress = reader.GetValue(24) != null ? reader.GetValue(24).ToString().Trim() : string.Empty;
                            var salesOrganization1 = reader.GetValue(25) != null ? reader.GetValue(25).ToString().Trim() : string.Empty;
                            var salesOrganization2 = reader.GetValue(26) != null ? reader.GetValue(26).ToString().Trim() : string.Empty;
                            var createdBy = reader.GetValue(27) != null ? reader.GetValue(27).ToString().Trim() : string.Empty;
                            var CreatedOn = reader.GetValue(28) != null ? reader.GetValue(28).ToString().Trim() : DateTime.MinValue.ToString();
                            var changedBy = reader.GetValue(29) != null ? reader.GetValue(29).ToString().Trim() : string.Empty;
                            var changedOn = reader.GetValue(30) != null ? reader.GetValue(30).ToString().Trim() : DateTime.MinValue.ToString();
                            var remarks = reader.GetValue(31) != null ? reader.GetValue(31).ToString().Trim() : string.Empty;

                            DateTime changedOnDate;
                            importAndSaveBusinessPartnerRecords.BusinessPartners.Add(new vwBusinessPartner
                            {
                                Date = Convert.ToDateTime(date),
                                Comments = comments,
                                Modified = modified,
                                Valid = valid,
                                TLRemarks = TLRemark,
                                Team = team,
                                BusinessPartnerNumber = Convert.ToDouble(bpNumber),
                                PartnerCategory = Convert.ToInt32(partnerCatagory),
                                PartnerType = partnerType,
                                Title = title,
                                Name1 = name1,
                                Name2 = name2,
                                Name3 = name3,
                                LastName = lastName,
                                FirstName = firstName,
                                Institute1 = institute1,
                                Institute2 = institute2,
                                Street = street,
                                HouseNumber = houseNumber,
                                PostalCode1 = postalCode1,
                                POBox = poBox,
                                PostalCode2 = postalCode2,
                                City = city,
                                CountryKey = countryKey,
                                EmailAddress = emailAddress,
                                SalesOrganization1 = salesOrganization1,
                                SalesOrganization2 = salesOrganization2,
                                CreatedBy = createdBy,
                                CreatedOn = Convert.ToDateTime(CreatedOn),
                                ChangedBy = changedBy,
                                ChangedOn = DateTime.TryParse(changedOn, out changedOnDate) ? Convert.ToDateTime(changedOn) : DateTime.MinValue,
                                Remarks = remarks,
                            });
                        }
                    }
                }
            }
            return importAndSaveBusinessPartnerRecords;
        }

        public void SaveBusinessPartnerRecords(string fileName, string recordDate)
        {
            var importAndSave = GetUploadedBusinessPartnerRecords(fileName);
            List<BusinessPartner> businessPartnerRecords = new List<BusinessPartner>();
            foreach (var bpRecord in importAndSave.BusinessPartners)
            {
                BusinessPartner record = new BusinessPartner();
                record.AccountType = AccountType.SpringerNature.ToString();
                record.Date = bpRecord.Date;
                record.Comments = bpRecord.Comments;
                record.Modified = bpRecord.Modified;
                record.Valid = bpRecord.Valid;
                record.TLRemarks = bpRecord.TLRemarks;

                record.Team = bpRecord.Team;
                record.BusinessPartnerNumber = bpRecord.BusinessPartnerNumber;
                record.PartnerCategory = Convert.ToUInt16(bpRecord.PartnerCategory);
                record.PartnerType = bpRecord.PartnerType;
                record.Title = bpRecord.Title;
                record.Name1 = bpRecord.Name1;
                record.Name2 = bpRecord.Name2;
                record.Name3 = bpRecord.Name3;
                record.LastName = bpRecord.LastName;
                record.FirstName = bpRecord.FirstName;
                record.Institute1 = bpRecord.Institute1;
                record.Institute2 = bpRecord.Institute2;
                record.Street = bpRecord.Street;
                record.HouseNumber = bpRecord.HouseNumber;
                record.PostalCode1 = bpRecord.PostalCode1;
                record.POBox = bpRecord.POBox;
                record.PostalCode2 = bpRecord.PostalCode2;
                record.City = bpRecord.City;
                record.CountryKey = bpRecord.CountryKey;
                record.EmailAddress = bpRecord.EmailAddress;
                record.SalesOrganization1 = bpRecord.SalesOrganization1;
                record.SalesOrganization2 = bpRecord.SalesOrganization2;
                record.CreatedBy = bpRecord.CreatedBy;
                record.CreatedOn = bpRecord.CreatedOn;
                record.ChangedBy = bpRecord.ChangedBy;
                record.ChangedOn = bpRecord.ChangedOn;
                record.Remarks = bpRecord.Remarks;
                record.RecordDate = Convert.ToDateTime(recordDate).Date;
                record.CreatedDate = DateTime.Now;
                businessPartnerRecords.Add(record);
            }
            if (businessPartnerRecords.Count > 0)
            {
                _skillMatrixRepository.SaveBusinessPartnersRecords(businessPartnerRecords);
            }
        }
    }
}
