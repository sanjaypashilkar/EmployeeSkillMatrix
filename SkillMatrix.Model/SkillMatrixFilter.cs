using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class SkillMatrixFilter
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public string Team { get; set; }
        public string CompetencyLevel { get; set; }
        public string TenureLevel { get; set; }
    }
}
