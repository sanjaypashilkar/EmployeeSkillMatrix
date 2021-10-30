using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SkillMatrix.Model
{
    public class SkillMatrixFilter
    {
        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Quarter is required.")]
        public int Quarter { get; set; }
        public string Team { get; set; }
        public string CompetencyLevel { get; set; }
        public string TenureLevel { get; set; }
        public int PageNumber { get; set; }
    }
}
