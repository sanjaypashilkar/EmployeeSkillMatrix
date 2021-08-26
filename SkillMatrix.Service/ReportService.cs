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
                if (filter.PageNumber < 1)
                    filter.PageNumber = 1;

                int rescCount = skillMatrices.Count();
                int recSkip = (filter.PageNumber - 1) * pageSize;
                var pager = new Pager(rescCount, recSkip, filter.PageNumber, pageSize);
                report.Pager = pager;
                
                var paginatedData = skillMatrices.Skip(recSkip).Take(pager.PageSize).ToList();
                report.PaginatedSkills = paginatedData;
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
