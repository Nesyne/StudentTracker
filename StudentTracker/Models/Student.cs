using System;
namespace StudentTracker.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInit { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return LastName + " " + FirstName + ", " + MiddleInit;
            }
        }
    }
}
