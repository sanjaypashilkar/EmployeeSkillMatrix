using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class QualityRating3
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public string Month { get; set; }
        public DateTime Date { get; set; }
        public string TeamLead { get; set; }
        public string AgentName { get; set; }
        public string EmployeeId { get; set; }
        public int CF1_PointsEarned { get; set; }
        public int CF1_TotalPoints { get; set; }
        public int CF2_PointsEarned { get; set; }
        public int CF2_TotalPoints { get; set; }
        public int CF3_PointsEarned { get; set; }
        public int CF3_TotalPoints { get; set; }
        public int CF4_PointsEarned { get; set; }
        public int CF4_TotalPoints { get; set; }
        public int SF1_PointsEarned { get; set; }
        public int SF1_TotalPoints { get; set; }
        public int SF2_PointsEarned { get; set; }
        public int SF2_TotalPoints { get; set; }
        public int SF3_PointsEarned { get; set; }
        public int SF3_TotalPoints { get; set; }
        public int BP1_PointsEarned { get; set; }
        public int BP1_TotalPoints { get; set; }
        public int BP2_PointsEarned { get; set; }
        public int BP2_TotalPoints { get; set; }
        public int BP3_PointsEarned { get; set; }
        public int BP3_TotalPoints { get; set; }
        public int IC1_PointsEarned { get; set; }
        public int IC1_TotalPoints { get; set; }
        public int IC2_PointsEarned { get; set; }
        public int IC2_TotalPoints { get; set; }
        public int IC3_PointsEarned { get; set; }
        public int IC3_TotalPoints { get; set; }
        public int IC4_PointsEarned { get; set; }
        public int IC4_TotalPoints { get; set; }
        public double PassiveSurvey { get; set; }
        public double CSATScore { get; set; }
        public int NoOfPplOpportunity { get; set; }
        public string Remarks { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
