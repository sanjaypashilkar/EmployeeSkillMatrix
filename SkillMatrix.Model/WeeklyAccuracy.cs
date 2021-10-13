using System;
using System.Collections.Generic;
using System.Text;

namespace SkillMatrix.Model
{
    public class WeeklyAccuracy
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Week { get; set; }
        public double AccuracyRate { get; set; }
        public double AverageMTD { get; set; }
    }

    public class DailySampling
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public double SamplePercentage { get; set; }
        public double AvgSamplePercentage { get; set; }
    }
}
