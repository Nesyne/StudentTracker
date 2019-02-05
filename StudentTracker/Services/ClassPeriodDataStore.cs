using System;
using System.Collections.ObjectModel;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class ClassPeriodDataStore
    {
        ObservableCollection<ClassPeriod> _periods;

        public ClassPeriodDataStore()
        {


            _periods = new ObservableCollection<ClassPeriod>();

            var periodList = new ObservableCollection<ClassPeriod>
            {
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Morning Work", StartTime = new TimeSpan(8,30,0),EndTime = new TimeSpan(9,0,0),SortOrder=1},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="ELA", StartTime = new TimeSpan(9,0,0),EndTime = new TimeSpan(9,35,0),SortOrder=2},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Small Groups", StartTime = new TimeSpan(9,35,0),EndTime = new TimeSpan(10,0,0),SortOrder=3},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Independent Work", StartTime = new TimeSpan(10,0,0),EndTime = new TimeSpan(11,0,0),SortOrder=4},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Math", StartTime = new TimeSpan(11,50,0),EndTime = new TimeSpan(12,50,0),SortOrder=5},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="FAB", StartTime = new TimeSpan(12,50,0),EndTime = new TimeSpan(1,30,0),SortOrder=6},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Science/Social Studies", StartTime = new TimeSpan(1,30,0),EndTime = new TimeSpan(2,30,0),SortOrder=7},
                new ClassPeriod{Id = Guid.NewGuid().ToString(), Name="Clean Up", StartTime = new TimeSpan(2,30,0),EndTime = new TimeSpan(2,45,0),SortOrder=8},
        };

            foreach (var period in periodList)
            {
                _periods.Add(period);
            }

          

        }

        public ObservableCollection<ClassPeriod> GetClassPeriods()
        {
            return _periods;
        }
    }
}
