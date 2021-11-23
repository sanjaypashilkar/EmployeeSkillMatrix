using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class vwQualityRating3
    {
        public virtual string Month { get; set; }
        public virtual string TeamLead { get; set; }
        public virtual string AgentName { get; set; }
        public virtual string EmployeeId { get; set; }
        public virtual int CF1_PointsEarned { get; set; }
        public virtual int CF1_TotalPoints { get; set; }
        public virtual int CF2_PointsEarned { get; set; }
        public virtual int CF2_TotalPoints { get; set; }
        public virtual int CF3_PointsEarned { get; set; }
        public virtual int CF3_TotalPoints { get; set; }
        public virtual int CF4_PointsEarned { get; set; }
        public virtual int CF4_TotalPoints { get; set; }
        public virtual int SF1_PointsEarned { get; set; }
        public virtual int SF1_TotalPoints { get; set; }
        public virtual int SF2_PointsEarned { get; set; }
        public virtual int SF2_TotalPoints { get; set; }
        public virtual int SF3_PointsEarned { get; set; }
        public virtual int SF3_TotalPoints { get; set; }
        public virtual int BP1_PointsEarned { get; set; }
        public virtual int BP1_TotalPoints { get; set; }
        public virtual int BP2_PointsEarned { get; set; }
        public virtual int BP2_TotalPoints { get; set; }
        public virtual int BP3_PointsEarned { get; set; }
        public virtual int BP3_TotalPoints { get; set; }
        public virtual int IC1_PointsEarned { get; set; }
        public virtual int IC1_TotalPoints { get; set; }
        public virtual int IC2_PointsEarned { get; set; }
        public virtual int IC2_TotalPoints { get; set; }
        public virtual int IC3_PointsEarned { get; set; }
        public virtual int IC3_TotalPoints { get; set; }
        public virtual int IC4_PointsEarned { get; set; }
        public virtual int IC4_TotalPoints { get; set; }
        public virtual double PassiveSurvey { get; set; }
        public virtual double CSATScore { get; set; }
        public virtual int NoOfPplOpportunity { get; set; }
        public virtual string Remarks { get; set; }        
        public virtual DateTime RecordDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
