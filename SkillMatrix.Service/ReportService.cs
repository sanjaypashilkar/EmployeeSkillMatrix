using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SkillMatrix.Service
{
    public class ReportService : IReportService
    {
        public ISkillMatrixRepository _skillMatrixRepository { get; set; }

        public ReportService(ISkillMatrixRepository skillMatrixRepository)
        {
            _skillMatrixRepository = skillMatrixRepository;
        }

        public vwSkillReport GetSkillMatrixReport()
        {
            vwSkillReport report = new vwSkillReport();
            int currentQuarter = (DateTime.Today.Month - 1) / 3 + 1;
            int selectedQuarter = currentQuarter != 1 ? currentQuarter - 1 : 4;
            int currentYear = DateTime.Today.Year;
            int selectedYear = currentQuarter != 1 ? currentYear : currentYear - 1;
            report.SkillMatrixFilter.Year = selectedYear;
            report.SkillMatrixFilter.Quarter = selectedQuarter;
            report.lstYears = mtdGetYears();
            report.lstQuarters = mtdGetQuarters();
            report.lstTeams = mtdGetTeams(selectedYear,selectedQuarter);
            report.lstCompetencyLevel = mtdGetCompetencyLevel();
            report.lstTenureLevel = mtdGetTenureLevel();
            var skillMatrices = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(selectedYear,selectedQuarter).ToList();
            if (skillMatrices.Count > 0)
            {
                report.SkillMatrix = skillMatrices;
            }
            return report;
        }

        public vwSkillReport GetSkillMatrixReport(SkillMatrixFilter skillMatrixFilter)
        {
            vwSkillReport report = new vwSkillReport();
            report.lstCompetencyLevel = mtdGetCompetencyLevel();
            report.lstTenureLevel = mtdGetTenureLevel();
            var skillMatrices = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(skillMatrixFilter.Year, skillMatrixFilter.Quarter).ToList();            
            if(!string.IsNullOrEmpty(skillMatrixFilter.Team))
            {
                skillMatrices = skillMatrices.Where(s => s.Team.ToLower() == skillMatrixFilter.Team.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(skillMatrixFilter.CompetencyLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.CompetencyLevel.ToLower() == skillMatrixFilter.CompetencyLevel.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(skillMatrixFilter.TenureLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.TenureLevel.ToLower() == skillMatrixFilter.TenureLevel.ToLower()).ToList();
            }
            if (skillMatrices.Count > 0)
            {
                report.SkillMatrix = skillMatrices;
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
    }
}
