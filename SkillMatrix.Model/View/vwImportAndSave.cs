using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwImportAndSave
    {
        public List<vwImportSkill> ImportSkills { get; set; }
        public virtual Dictionary<string, string> lstYears { get; set; }
        public virtual Dictionary<string, string> lstQuarters { get; set; }
        public virtual SkillMatrixFilter SkillMatrixFilter { get; set; }

        public vwImportAndSave()
        {
            ImportSkills = new List<vwImportSkill>();
            lstYears = new Dictionary<string, string>();
            lstQuarters = new Dictionary<string, string>();
            SkillMatrixFilter = new SkillMatrixFilter();
        }
    }

    public class vwImportSkill
    {
        public virtual string Team { get; set; }
        public virtual string Name { get; set; }
        public virtual string DateHired { get; set; }
        public virtual string DateCompleted { get; set; }
        public virtual string ProcessSpecific_PR { get; set; }
        public virtual string StarAndOSvC_PR { get; set; }
        public virtual string ProcessSpecific_TS { get; set; }
        public virtual string StarAndOSvC_TS { get; set; }
        public virtual string ProcessSpecific_QSR { get; set; }
        public virtual string StarAndOSvC_QSR { get; set; }
        public virtual string CSATScore { get; set; }
        public virtual string QCScore { get; set; }
    }
}
