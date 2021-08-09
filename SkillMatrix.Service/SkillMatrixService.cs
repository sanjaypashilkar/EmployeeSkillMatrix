using ExcelDataReader;
using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SkillMatrix.Service
{
    public class SkillMatrixService : ISkillMatrixService
    {
        public ISkillMatrixRepository _skillMatrixrepository { get; set; }

        public SkillMatrixService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixrepository = skillMatrixRepository;
        }

        public List<vwImportAndSave> GetUploadedSkillMatrix(string fileName)
        {
            List<vwImportAndSave> employeeSkillMatrices = new List<vwImportAndSave>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if(reader.Depth != 0 && reader.Depth != 1)
                        {
                            string team = reader.GetValue(0)!=null ? reader.GetValue(0).ToString():string.Empty;
                            string employeeName = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : string.Empty;
                            if (string.IsNullOrEmpty(team) && string.IsNullOrEmpty(employeeName))
                                break;
                            var dateHired = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : string.Empty;
                            var dateCompleted = reader.GetValue(3) != null ? reader.GetValue(3).ToString() : string.Empty;
                            var processSpecific_PR = reader.GetValue(4) != null ? reader.GetValue(4).ToString() : string.Empty;
                            var starAndOSvC_PR = reader.GetValue(5) != null ? reader.GetValue(5).ToString() : string.Empty;
                            var processSpecific_TS = reader.GetValue(6) != null ? reader.GetValue(6).ToString() : string.Empty;
                            var starAndOSvC_TS = reader.GetValue(7) != null ? reader.GetValue(7).ToString() : string.Empty;
                            var processSpecific_QSR = reader.GetValue(8) != null ? reader.GetValue(8).ToString() : string.Empty;
                            var starAndOSvC_QSR = reader.GetValue(9) != null ? reader.GetValue(9).ToString() : string.Empty;
                            var csatScore = reader.GetValue(10) != null ? reader.GetValue(10).ToString() : string.Empty;
                            var qcScore = reader.GetValue(11) != null ? reader.GetValue(11).ToString() : string.Empty;

                            employeeSkillMatrices.Add(new vwImportAndSave
                            {
                                Team = team,
                                Name = employeeName,
                                DateHired = dateHired,
                                DateCompleted = dateCompleted,
                                ProcessSpecific_PR = (!string.IsNullOrEmpty(processSpecific_PR)) ? (Convert.ToDouble(processSpecific_PR) * 100).ToString("#.##"): string.Empty,
                                StarAndOSvC_PR = (!string.IsNullOrEmpty(starAndOSvC_PR)) ? (Convert.ToDouble(starAndOSvC_PR) * 100).ToString("#.##") : string.Empty,
                                ProcessSpecific_TS = processSpecific_TS,
                                StarAndOSvC_TS = starAndOSvC_TS,
                                ProcessSpecific_QSR = (!string.IsNullOrEmpty(processSpecific_QSR)) ? (Convert.ToDouble(processSpecific_QSR) * 100).ToString("#.##") : string.Empty,
                                StarAndOSvC_QSR = (!string.IsNullOrEmpty(starAndOSvC_QSR)) ? (Convert.ToDouble(starAndOSvC_QSR) * 100).ToString("#.##") : string.Empty,
                                CSATScore = (!string.IsNullOrEmpty(csatScore)) ? (Convert.ToDouble(csatScore) * 100).ToString("#.##") : string.Empty,
                                QCScore = (!string.IsNullOrEmpty(qcScore)) ? (Convert.ToDouble(qcScore) * 100).ToString("#.##") : string.Empty,                             
                            });
                        }                        
                    }
                }
            }
            return employeeSkillMatrices;
        }

        public void SaveSkillMatrix(string fileName, string year, string quarter)
        {
            var employeeSkills = GetUploadedSkillMatrix(fileName);
            var categoryScoring = _skillMatrixrepository.GetCategoryScoring().ToList();
            var competencyLevelScoring = _skillMatrixrepository.GetCompetencyLevelScoring().ToList();
            var tenureScoringLevel = _skillMatrixrepository.GetCompetencyLevelScoring().ToList(); 
            List<EmployeeSkillMatrix> employeeSkillMatrices = new List<EmployeeSkillMatrix>();
            foreach(var employeeSkill in employeeSkills)
            {
                EmployeeSkillMatrix employeeSkillMatrix = new EmployeeSkillMatrix();
                employeeSkillMatrix.Year = Convert.ToInt32(year);
                employeeSkillMatrix.Quarter = Convert.ToInt32(quarter);
                employeeSkillMatrix.Team = employeeSkill.Team;
                employeeSkillMatrix.Name = employeeSkill.Name;
                employeeSkillMatrix.DateHired = Convert.ToDateTime(employeeSkill.DateHired);
                var tenure = Math.Round(((DateTime.Today - Convert.ToDateTime(employeeSkill.DateHired)).TotalDays/365),2);
                employeeSkillMatrix.Tenure = tenure;
                employeeSkillMatrix.DateCompleted = Convert.ToDateTime(employeeSkill.DateCompleted);
                employeeSkillMatrix.ProcessSpecific_PR = Convert.ToDouble(employeeSkill.ProcessSpecific_PR);
                employeeSkillMatrix.StarAndOSvC_PR = Convert.ToDouble(employeeSkill.StarAndOSvC_PR);
                employeeSkillMatrix.ProcessSpecific_TS = employeeSkill.ProcessSpecific_TS;
                employeeSkillMatrix.StarAndOSvC_TS = employeeSkill.StarAndOSvC_TS;
                employeeSkillMatrix.TotalTimeSpent = Convert.ToString(TimeSpan.Parse(employeeSkill.ProcessSpecific_TS) + TimeSpan.Parse(employeeSkill.StarAndOSvC_TS));
                employeeSkillMatrix.ProcessSpecific_QSR = Convert.ToDouble(employeeSkill.ProcessSpecific_QSR);
                employeeSkillMatrix.StarAndOSvC_QSR = Convert.ToDouble(employeeSkill.StarAndOSvC_QSR);

                double[] QSRArray = { Convert.ToDouble(employeeSkill.ProcessSpecific_QSR), Convert.ToDouble(employeeSkill.StarAndOSvC_QSR) };
                var avgQSR = Math.Round(QSRArray.Average(), 2);
                employeeSkillMatrix.AvgQuestionsStatisticsReport = avgQSR;

                var certificationScore = categoryScoring.Where(c=> avgQSR>=c.LowerScore && avgQSR <= c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.CertificationScore = certificationScore;

                var certificationLevel = competencyLevelScoring.Where(cl => certificationScore >= cl.LowerScore && certificationScore <= cl.UpperScore).FirstOrDefault().Level;
                employeeSkillMatrix.CertificationLevel = certificationLevel;

                var csatScore = Convert.ToDouble(employeeSkill.CSATScore);
                employeeSkillMatrix.CSATScore = csatScore;

                var csatLevel = categoryScoring.Where(c => csatScore >= c.LowerScore && csatScore <= c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.CSATLevel = csatLevel.ToString();

                var qcScore = Convert.ToDouble(employeeSkill.QCScore);
                employeeSkillMatrix.QCScore = qcScore;

                var qcLevel = categoryScoring.Where(c => qcScore >= c.LowerScore && qcScore <= c.UpperScore).FirstOrDefault().Score;
                employeeSkillMatrix.QCLevel = qcLevel.ToString();

                double[] score = { certificationScore, csatLevel, qcLevel };
                employeeSkillMatrix.ScoreSum = score.Sum();                
                employeeSkillMatrix.ScoreCount = score.Count();
                var overallScore = Math.Round((employeeSkillMatrix.ScoreSum/ employeeSkillMatrix.ScoreCount),2);
                employeeSkillMatrix.OverallScore = overallScore;
                employeeSkillMatrix.CompetencyLevel = competencyLevelScoring.Where(cl => overallScore >= cl.LowerScore && overallScore <= cl.UpperScore).FirstOrDefault().Level;
                employeeSkillMatrix.TenurePlusCompetency = tenureScoringLevel.Where(t=>tenure>= t.LowerScore && tenure<=t.UpperScore).FirstOrDefault().Level;
                employeeSkillMatrix.CreatedDate = DateTime.Today;
                employeeSkillMatrices.Add(employeeSkillMatrix);
            }
        }
    }
}
