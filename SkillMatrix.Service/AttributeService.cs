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
            var selectList = Enum.GetNames(typeof(Department)).ToList().Select(i => new { key = i.ToString(), value = i.ToString() }).ToDictionary(x => x.key, x => x.value);
            return selectList;
        }

        public vwImportAndSaveQualityRating GetUploadedQualityRating(string fileName)
        {
            vwImportAndSaveQualityRating importAndSaveQuality = new vwImportAndSaveQualityRating();
            importAndSaveQuality.lstDepartments = mtdGetDepartments();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if(fileName.ToLowerInvariant().Contains("compcopy") || fileName.ToLowerInvariant().Contains("order"))
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
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
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
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
            return importAndSaveQuality;
        }

        public void SaveQualityRatings(string fileName, string department, string recordDate)
        {
            var importAndSave = GetUploadedQualityRating(fileName);
            if (department == Department.ComCopy.ToString() || department == Department.OrderManagement.ToString())
            {
                List<QualityRating2> qualityRatings = new List<QualityRating2>();
                foreach (var qualityRating in importAndSave.QualityRatings2)
                {
                    QualityRating2 rating = new QualityRating2();
                    rating.Department = department;
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
                    rating.Volume = string.IsNullOrEmpty(qualityRating.Volume)? 0 : Convert.ToDouble(qualityRating.Volume);
                    rating.Counter = Convert.ToInt32(qualityRating.Counter);
                    rating.EmpIdDate = qualityRating.EmpIdDate;
                    rating.Date = qualityRating.Date;
                    rating.RecordDate = Convert.ToDateTime(recordDate).Date;
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
                    rating.Department = department;
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
                    rating.RecordDate = Convert.ToDateTime(recordDate).Date;
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
            importAndSaveTicketingRecords.lstDepartments = mtdGetDepartments();
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
                                Team = TeamForReviews.Straive.ToString(),
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
    }
}
