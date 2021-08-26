﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwSkillReport
    {
        public virtual List<EmployeeSkillMatrix> SkillMatrix { get; set; }
        public virtual List<EmployeeSkillMatrix> PaginatedSkills { get; set; }
        public virtual SkillMatrixFilter SkillMatrixFilter { get; set; }
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
            SkillMatrixFilter = new SkillMatrixFilter();
            lstYears = new Dictionary<string,string>();
            lstQuarters = new Dictionary<string, string>();
            lstTeams = new Dictionary<string, string>();
            lstCompetencyLevel = new Dictionary<string, string>();
            lstTenureLevel = new Dictionary<string, string>();
            Pager = new Pager();
        }
    }
}
