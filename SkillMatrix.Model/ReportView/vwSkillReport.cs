using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwSkillReport
    {
        public virtual List<EmployeeSkillMatrix> SkillMatrix { get; set; }
        public virtual List<EmployeeSkillMatrix> PaginatedSkills { get; set; }
        public virtual List<EmployeeCompetencyLevel> EmployeeCompetencyLevels { get; set; }
        public virtual List<EmployeeCompetencyLevel> PaginatedCompetencyLevels { get; set; }
        public virtual SkillMatrixFilter SkillMatrixFilter { get; set; }
        public virtual Dictionary<string, string> lstAccountTypes { get; set; }
        public virtual Dictionary<string, string> lstYears { get; set; }
        public virtual Dictionary<string, string> lstQuarters { get; set; }
        public virtual Dictionary<string, string> lstTeams { get; set; }
        public virtual Dictionary<string, string> lstCompetencyLevel { get; set; }
        public virtual Dictionary<string, string> lstTenureLevel { get; set; }
        public virtual Pager Pager { get;set;}

        public vwSkillReport()
        {
            SkillMatrix = new List<EmployeeSkillMatrix>();
            PaginatedSkills = new List<EmployeeSkillMatrix>();
            EmployeeCompetencyLevels = new List<EmployeeCompetencyLevel>();
            PaginatedCompetencyLevels = new List<EmployeeCompetencyLevel>();
            SkillMatrixFilter = new SkillMatrixFilter();
            lstAccountTypes = new Dictionary<string, string>();
            lstYears = new Dictionary<string,string>();
            lstQuarters = new Dictionary<string, string>();
            lstTeams = new Dictionary<string, string>();
            lstCompetencyLevel = new Dictionary<string, string>();
            lstTenureLevel = new Dictionary<string, string>();
            Pager = new Pager();
        }
    }
}
