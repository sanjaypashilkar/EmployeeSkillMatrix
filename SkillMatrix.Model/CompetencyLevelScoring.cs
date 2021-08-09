using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class CompetencyLevelScoring
    {
        public int Id { get; set; }
        public double LowerScore { get; set; }
        public double UpperScore { get; set; }
        public string Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public CompetencyLevelScoring()
        {
            Id = 0;
            LowerScore = 0.0;
            UpperScore = 0.0;
            Level = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}
