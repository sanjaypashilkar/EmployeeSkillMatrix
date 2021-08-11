using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class TenureLevel
    {
        public int Id { get; set; }
        public int LowerScore { get; set; }
        public int UpperScore { get; set; }
        public string Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public TenureLevel()
        {
            Id = 0;
            LowerScore = 0;
            UpperScore = 0;
            Level = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}
