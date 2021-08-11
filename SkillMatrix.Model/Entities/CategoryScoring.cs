using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class CategoryScoring
    {
        public int Id { get; set; }
        public int LowerScore { get; set; }
        public int UpperScore { get; set; }
        public double Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public CategoryScoring()
        {
            Id = 0;
            LowerScore = 0;
            UpperScore = 0;
            Score = 0.0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now; 
        }
    }
}
