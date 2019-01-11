using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class StudentDataStore 
    {
        ObservableCollection<Student> _students;

        public StudentDataStore()
        {
            _students = new ObservableCollection<Student>();

            var studentList = new ObservableCollection<Student>
            {
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "John",MiddleInit="T", LastName="Smith"},
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "Peter",MiddleInit="S", LastName="Flint"},
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "Corey",MiddleInit ="M",LastName ="Walker"},
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "Mandy",MiddleInit="A", LastName="Moore"},
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "Madisson",MiddleInit="L", LastName="Vasques"},
                new Student{ Id = Guid.NewGuid().ToString(), FirstName = "Karen",MiddleInit="V", LastName="Moreland"},
        };

            foreach (var student in studentList)
            {
                _students.Add(student);
            }
        }

        public ObservableCollection<Student> GetStudents()
        {
            return _students;
        }

    }
}
