using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwImportAndSave
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
