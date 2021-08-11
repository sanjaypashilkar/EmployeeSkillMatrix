using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwSkillReport
    {
        public virtual List<EmployeeSkillMatrix> SkillMatrix { get; set; }
        public virtual SkillMatrixFilter SkillMatrixFilter { get; set; }
        public virtual List<SelectListItem> lstYears { get; set; }
        public virtual List<SelectListItem> lstQuarters { get; set; }
        public virtual List<SelectListItem> lstTeams { get; set; }
        public virtual List<SelectListItem> lstCompetencyLevel { get; set; }
        public virtual List<SelectListItem> lstTenureLevel { get; set; }

        public vwSkillReport()
        {
            SkillMatrix = new List<EmployeeSkillMatrix>();
            SkillMatrixFilter = new SkillMatrixFilter();
            lstYears = new List<SelectListItem>();
            lstQuarters = new List<SelectListItem>();
            lstTeams = new List<SelectListItem>();
            lstCompetencyLevel = new List<SelectListItem>();
            lstTenureLevel = new List<SelectListItem>();
        }
    }
}
