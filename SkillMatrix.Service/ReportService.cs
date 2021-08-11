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
                report.lstCompetencyLevel.ToList().ForEach(c => { if (c.Text == skillMatrixFilter.CompetencyLevel) { c.Selected = true; } });
            }
            if (!string.IsNullOrEmpty(skillMatrixFilter.TenureLevel))
            {
                skillMatrices = skillMatrices.Where(s => s.TenureLevel.ToLower() == skillMatrixFilter.TenureLevel.ToLower()).ToList();
                report.lstTenureLevel.ToList().ForEach(c => { if (c.Text == skillMatrixFilter.TenureLevel) { c.Selected = true; } });
            }
            if (skillMatrices.Count > 0)
            {
                report.SkillMatrix = skillMatrices;
            }
            return report;
        }

        public List<SelectListItem> mtdGetYears()
        {
            var selectList = Enumerable.Range(DateTime.Now.Year, 10).Reverse().Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            //var selected = selectList.Where(x => x.Value == selectedYear.ToString()).First();
            //selected.Selected = true;
            return selectList.ToList();
        }

        public List<SelectListItem> mtdGetQuarters()
        {
            var selectList = Enumerable.Range(1, 4).Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            //var selected = selectList.Where(x => x.Value == selectedQuarter.ToString()).First();
            //selected.Selected = true;
            return selectList.ToList();
        }

        public List<SelectListItem> mtdGetTeams(int year, int quarter)
        {
            var skillMatrix = _skillMatrixRepository.GetSkillMatrixByYearAndQuarter(year, quarter);
            var teams = skillMatrix.Select(i => i.Team).ToList();
            teams.Insert(0, "- Select Item -");
            IEnumerable<SelectListItem> lstFilterEnum = teams.Select(x => new SelectListItem
            {
                Value = x,
                Text = x
            });
            return lstFilterEnum.ToList();
        }

        public List<SelectListItem> mtdGetCompetencyLevel()
        {
            List<CompetencyLevelScoring> lstCompetencyLevel = _skillMatrixRepository.GetCompetencyLevelScoring().Select(m => new CompetencyLevelScoring
            {
                Id = m.Id,
                Level = m.Level
            }).ToList();
            lstCompetencyLevel.Insert(0, new CompetencyLevelScoring { Id = 0, Level = "- Select Item -" });

            IEnumerable<SelectListItem> lstFilterEnum = lstCompetencyLevel.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Level
            });

            return lstFilterEnum.ToList();
        }

        public List<SelectListItem> mtdGetTenureLevel()
        {
            List<TenureLevel> lstTenureLevel = _skillMatrixRepository.GetTenureLevel().Select(m => new TenureLevel
            {
                Id = m.Id,
                Level = m.Level
            }).ToList();
            lstTenureLevel.Insert(0, new TenureLevel { Id = 0, Level = "- Select Item -" });

            IEnumerable<SelectListItem> lstFilterEnum = lstTenureLevel.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Level
            });

            return lstFilterEnum.ToList();
        }
    }
}
