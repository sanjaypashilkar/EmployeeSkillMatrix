using SkillMatrix.Model;
using SkillMatrix.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var skillMatrices = _skillMatrixRepository.GetSkillMatrix().ToList();
            if (skillMatrices.Count > 0)
            {
                report.SkillMatrix = skillMatrices;
            }
            return report;
        }
    }
}
