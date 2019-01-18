using System;
namespace StudentTracker.Models
{
    public class AcademicGoal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public int Percentage { get; set; }
    }
}
