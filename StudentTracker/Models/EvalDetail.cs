using System;
namespace StudentTracker.Models
{
    public class EvalDetail
    {
        public string EvalId { get; set; }
        public string ClassPeriodId { get; set; }
        public int Level { get; set; }
        public string ReasonCodeId { get; set; }
        public string Notes { get; set; }
        public int TimeMissed { get; set; }
    }
}
