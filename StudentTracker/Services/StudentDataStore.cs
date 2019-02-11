using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class StudentDataStore : IDataStore<Student>
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

        public async Task<bool> AddItemAsync(Student item)
        {
            _students.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _students.FirstOrDefault((Student arg) => arg.Id == id);
            _students.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Student> GetItemAsync(string id)
        {
            return await Task.FromResult(_students.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Student>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_students);
        }

        public async Task<bool> UpdateItemAsync(Student item)
        {
            var oldItem = _students.FirstOrDefault((Student arg) => arg.Id == item.Id);
            _students.Remove(oldItem);
            _students.Add(item);

            return await Task.FromResult(true);
        }
    }
}
