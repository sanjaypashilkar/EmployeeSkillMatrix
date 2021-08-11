using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    [Serializable]
    public class vwSkillReport
    {
        public virtual List<EmployeeSkillMatrix> SkillMatrix { get; set; }     
        
        public vwSkillReport()
        {
            SkillMatrix = new List<EmployeeSkillMatrix>();
        }
    }
}
