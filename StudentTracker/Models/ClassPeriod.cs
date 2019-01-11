using System;
namespace StudentTracker.Models
{
    public class ClassPeriod
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int SortOrder { get; set; }
        public string Period
        {
            get
            {
                return Name + " " + StartTime.ToString(@"hh\:mm") + " - " + EndTime.ToString(@"hh\:mm");
            }
        }
    }
}
