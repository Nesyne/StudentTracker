using System;
namespace StudentTracker.Models
{
    public class BehaviorDetail
    {
        public string Id { get; set; }
        public string ClassPeriodId { get; set; }
        public DateTime StartTime { get; set; }
        public string LocationId { get; set; }
        public string ActivityId { get; set; }
        public string AntecedentId { get; set; }
        public string BehaviorId { get; set; }
        public string ConsequenceId { get; set; }
        public string IntensityId { get; set; }
        public int Duration { get; set; }
    }
}
