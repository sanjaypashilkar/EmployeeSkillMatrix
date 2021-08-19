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
    public class SkillMatrixService : ISkillMatrixService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }
        public IReportService _reportService { get; set; }

        public SkillMatrixService(ISkillMatrixRepository skillMatrixRepository, IReportService reportService)
        {
            _skillMatrixRepository = skillMatrixRepository;
            _reportService = reportService;
        }

        public vwImportAndSave GetYearAndQuarter()
        {
            vwImportAndSave importAndSave = new vwImportAndSave();
            int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
            int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
            int currentYear = DateTime.Today.Year;
            int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
            importAndSave.SkillMatrixFilter.Year = selectedYear;
            importAndSave.SkillMatrixFilter.Quarter = selectedQuarter;
            importAndSave.lstYears = _reportService.mtdGetYears();
            importAndSave.lstQuarters = _reportService.mtdGetQuarters();
            return importAndSave;
        }
        public vwImportAndSave GetUploadedSkillMatrix(string fileName)
        {
            vwImportAndSave importAndSave = new vwImportAndSave();
            int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
            int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
            int currentYear = DateTime.Today.Year;
            int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
            importAndSave.SkillMatrixFilter.Year = selectedYear;
            importAndSave.SkillMatrixFilter.Quarter = selectedQuarter;
            importAndSave.lstYears = _reportService.mtdGetYears();
            importAndSave.lstQuarters = _reportService.mtdGetQuarters();
            var employees = _skillMatrixRepository.GetEmployees();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if(reader.Depth != 0 && reader.Depth != 1)
                        {
                            string team = reader.GetValue(0)!=null ? reader.GetValue(0).ToString().Trim():string.Empty;
                            string employeeName = reader.GetValue(1) != null ? reader.GetValue(1).ToString().Trim() : string.Empty;
                            if (string.IsNullOrEmpty(team) && string.IsNullOrEmpty(employeeName))
                                break;
                            //var dateHired = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : string.Empty;
                            var dateCompleted = reader.GetValue(2) != null ? reader.GetValue(2).ToString().Trim() : string.Empty;
                            var processSpecific_PR = reader.GetValue(3) != null ? reader.GetValue(3).ToString().Trim() : string.Empty;
                            var starAndOSvC_PR = reader.GetValue(4) != null ? reader.GetValue(4).ToString().Trim() : string.Empty;
                            var processSpecific_TS = reader.GetValue(5) != null ? reader.GetValue(5).ToString().Trim() : string.Empty;
                            var starAndOSvC_TS = reader.GetValue(6) != null ? reader.GetValue(6).ToString().Trim() : string.Empty;
                            var processSpecific_QSR = reader.GetValue(7) != null ? reader.GetValue(7).ToString().Trim() : string.Empty;
                            var starAndOSvC_QSR = reader.GetValue(8) != null ? reader.GetValue(8).ToString().Trim() : string.Empty;
                            var csatScore = reader.GetValue(9) != null ? reader.GetValue(9).ToString().Trim() : string.Empty;
                            var qcScore = reader.GetValue(10) != null ? reader.GetValue(10).ToString().Trim() : string.Empty;

                            double csatScoreDbl, qcScoreDbl;
                            importAndSave.ImportSkills.Add(new vwImportSkill
                            {
                                Team = team,
                                Name = employeeName,
                                DateHired = employees.Where(e=>e.Name.ToLower() == employeeName.ToLower()).FirstOrDefault().DateHired.ToString(),
                                DateCompleted = dateCompleted,
                                ProcessSpecific_PR = (!string.IsNullOrEmpty(processSpecific_PR)) ? (Convert.ToDouble(processSpecific_PR) * 100).ToString("#.##"): string.Empty,
                                StarAndOSvC_PR = (!string.IsNullOrEmpty(starAndOSvC_PR)) ? (Convert.ToDouble(starAndOSvC_PR) * 100).ToString("#.##") : string.Empty,
                                ProcessSpecific_TS = processSpecific_TS,
                                StarAndOSvC_TS = starAndOSvC_TS,
                                ProcessSpecific_QSR = (!string.IsNullOrEmpty(processSpecific_QSR)) ? (Convert.ToDouble(processSpecific_QSR) * 100).ToString("#.##") : string.Empty,
                                StarAndOSvC_QSR = (!string.IsNullOrEmpty(starAndOSvC_QSR)) ? (Convert.ToDouble(starAndOSvC_QSR) * 100).ToString("#.##") : string.Empty,
                                CSATScore = (!string.IsNullOrEmpty(csatScore) && Double.TryParse(csatScore, out csatScoreDbl)) ? (Convert.ToDouble(csatScore) * 100).ToString("#.##") : string.Empty,
                                QCScore = (!string.IsNullOrEmpty(qcScore) && Double.TryParse(qcScore, out qcScoreDbl)) ? (Convert.ToDouble(qcScore) * 100).ToString("#.##") : string.Empty,                             
                            });

                        }                        
                    }
                }
            }
            return importAndSave;
        }

        public void SaveSkillMatrix(string fileName, string year, string quarter)
        {
            var importAndSave = GetUploadedSkillMatrix(fileName);
            var categoryScoring = _skillMatrixRepository.GetCategoryScoring().ToList();
            var competencyLevelScoring = _skillMatrixRepository.GetCompetencyLevelScoring().ToList();
            var tenureScoringLevel = _skillMatrixRepository.GetTenureLevel().ToList(); 
            List<EmployeeSkillMatrix> employeeSkillMatrices = new List<EmployeeSkillMatrix>();
            foreach(var employeeSkill in importAndSave.ImportSkills)
            {
                EmployeeSkillMatrix employeeSkillMatrix = new EmployeeSkillMatrix();
                employeeSkillMatrix.Year = Convert.ToInt32(year);
                employeeSkillMatrix.Quarter = Convert.ToInt32(quarter);
                employeeSkillMatrix.Team = employeeSkill.Team;
                employeeSkillMatrix.Name = employeeSkill.Name;
                employeeSkillMatrix.DateHired = Convert.ToDateTime(employeeSkill.DateHired);
                int tenureDays = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(employeeSkill.DateHired)).TotalDays);
                int tenureYears = tenureDays / 365;
                int tenuremonths = (tenureDays % 365)/30;
                employeeSkillMatrix.TenureYears = tenureYears;
                employeeSkillMatrix.TenureMonths = tenuremonths;
                employeeSkillMatrix.DateCompleted = Convert.ToDateTime(employeeSkill.DateCompleted);
                employeeSkillMatrix.ProcessSpecific_PR = Convert.ToDouble(employeeSkill.ProcessSpecific_PR);
                employeeSkillMatrix.StarAndOSvC_PR = Convert.ToDouble(employeeSkill.StarAndOSvC_PR);

                TimeSpan processSpecific_TS, starAndOSvC_TS;
                bool isProcessSpecific_TS = TimeSpan.TryParseExact(employeeSkill.ProcessSpecific_TS, "g", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out processSpecific_TS);
                if(!isProcessSpecific_TS)
                {
                    DateTime processSpecific_TS_DT;
                    bool isProcessSpecific_TS_DT = DateTime.TryParse(employeeSkill.ProcessSpecific_TS, out processSpecific_TS_DT);
                    if(isProcessSpecific_TS_DT)
                    {
                        processSpecific_TS = processSpecific_TS_DT.TimeOfDay;
                    }
                }
                bool isStarAndOSvC_TS = TimeSpan.TryParseExact(employeeSkill.StarAndOSvC_TS, "g", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative, out starAndOSvC_TS);
                if(!isStarAndOSvC_TS)
                {
                    DateTime starAndOSvC_TS_DT;
                    bool isStarAndOSvC_TS_DT = DateTime.TryParse(employeeSkill.StarAndOSvC_TS, out starAndOSvC_TS_DT);
                    if (isStarAndOSvC_TS_DT)
                    {
                        starAndOSvC_TS = starAndOSvC_TS_DT.TimeOfDay;
                    }
                }
                employeeSkillMatrix.ProcessSpecific_TS = processSpecific_TS.ToString();
                employeeSkillMatrix.StarAndOSvC_TS = starAndOSvC_TS.ToString();                
                employeeSkillMatrix.TotalTimeSpent = (processSpecific_TS + starAndOSvC_TS).ToString();

                employeeSkillMatrix.ProcessSpecific_QSR = Convert.ToDouble(employeeSkill.ProcessSpecific_QSR);
                employeeSkillMatrix.StarAndOSvC_QSR = Convert.ToDouble(employeeSkill.StarAndOSvC_QSR);

                double[] QSRArray = { Convert.ToDouble(employeeSkill.ProcessSpecific_QSR), Convert.ToDouble(employeeSkill.StarAndOSvC_QSR) };
                var avgQSR = Math.Round(QSRArray.Average(), 2);
                employeeSkillMatrix.AvgQuestionsStatisticsReport = avgQSR;

                var certificationScore = categoryScoring.Where(c=> avgQSR>=c.LowerScore && avgQSR < c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.CertificationScore = certificationScore;

                var certificationLevel = competencyLevelScoring.Where(cl => certificationScore >= cl.LowerScore && certificationScore <= cl.UpperScore).FirstOrDefault().Level;
                employeeSkillMatrix.CertificationLevel = certificationLevel;

                var csatScore = string.IsNullOrEmpty(employeeSkill.CSATScore)?0.0:Convert.ToDouble(employeeSkill.CSATScore);
                employeeSkillMatrix.CSATScore = csatScore;

                var csatLevel = categoryScoring.Where(c => csatScore >= c.LowerScore && csatScore < c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.CSATLevel = csatLevel.ToString();

                var qcScore = string.IsNullOrEmpty(employeeSkill.QCScore) ? 0.0 : Convert.ToDouble(employeeSkill.QCScore);
                employeeSkillMatrix.QCScore = qcScore;

                var qcLevel = categoryScoring.Where(c => qcScore >= c.LowerScore && qcScore < c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.QCLevel = qcLevel.ToString();

                double[] score = { certificationScore, csatLevel, qcLevel };
                employeeSkillMatrix.ScoreSum = score.Sum();                
                employeeSkillMatrix.ScoreCount = score.Count();
                var overallScore = Math.Round((employeeSkillMatrix.ScoreSum/ employeeSkillMatrix.ScoreCount),2);
                employeeSkillMatrix.OverallScore = overallScore;
                employeeSkillMatrix.CompetencyLevel = competencyLevelScoring.Where(cl => overallScore >= cl.LowerScore && overallScore <= cl.UpperScore).FirstOrDefault().Level;
                var tenure = ((tenureYears * 12) + tenuremonths);
                employeeSkillMatrix.TenureLevel = tenureScoringLevel.Where(t=> tenure >= t.LowerScore && tenure<= t.UpperScore).FirstOrDefault().Level;
                employeeSkillMatrix.TenurePlusCompetency = (employeeSkillMatrix.CompetencyLevel.ToLower() == employeeSkillMatrix.TenureLevel.ToLower()) ? "Matched" : "For evaluation";
                employeeSkillMatrix.CreatedDate = DateTime.Today;
                employeeSkillMatrices.Add(employeeSkillMatrix);
            }
            if (employeeSkillMatrices.Count > 0)
            {
                _skillMatrixRepository.SaveSkillMatrix(employeeSkillMatrices);                
            }
        }
    }
}
