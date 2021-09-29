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
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth != 0 && reader.Depth != 1)
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
            return importAndSaveQuality;
        }

        public void SaveQualityRatings(string fileName, string department, string recordDate)
        {
            var importAndSave = GetUploadedQualityRating(fileName);
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
                rating.Variance = !string.IsNullOrEmpty(qualityRating.Variance)? Convert.ToDouble(qualityRating.Variance) : 0;
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
}
