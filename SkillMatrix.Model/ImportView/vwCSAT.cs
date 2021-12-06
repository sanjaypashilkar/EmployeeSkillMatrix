using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwCSAT
    {
        public virtual string Month { get; set; }
        public virtual int Year { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual double CSATScore { get; set; }
        public virtual double Effort { get; set; }
        public virtual double FTR { get; set; }
        public virtual double ComprNAccurate { get; set; }
        public virtual double ProfessionalNHelpful { get; set; }
        public virtual double Timely { get; set; }
        public virtual int NoOfRedFlags { get; set; }
        public virtual int NoOfSurveys { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }

    public class vwImportAndSaveCSAT
    {
        public virtual List<vwCSAT> CSATs { get; set; }
        public virtual CSATFilter CSATFilter { get; set; }

        public vwImportAndSaveCSAT()
        {
            CSATs = new List<vwCSAT>();
            CSATFilter = new CSATFilter();
        }
    }
}

