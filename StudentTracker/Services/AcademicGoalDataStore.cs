using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class AcademicGoalDataStore : IDataStore<AcademicGoal>
    {
        readonly List<AcademicGoal> _academics;

        public AcademicGoalDataStore()
        {
            _academics = new List<AcademicGoal>();
            var mockItems = new List<AcademicGoal>
            {
                new AcademicGoal { Id = Guid.NewGuid().ToString(), Name = "Stay on task for 15 minutes with less than 1 prompt", Date = DateTime.Now, DayOfWeek = "Monday", Percentage=20 },
                new AcademicGoal { Id = Guid.NewGuid().ToString(), Name = "Reads quietly without any cues", Date = DateTime.Now, DayOfWeek = "Wednesday", Percentage=70 },

            };

            foreach (var academic in mockItems)
            {
                _academics.Add(academic);
            }
        }

        public async Task<bool> AddItemAsync(AcademicGoal academic)
        {
            _academics.Add(academic);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(AcademicGoal academic)
        {
            var oldItem = _academics.FirstOrDefault((AcademicGoal arg) => arg.Id == academic.Id);
            _academics.Remove(oldItem);
            _academics.Add(academic);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _academics.FirstOrDefault((AcademicGoal arg) => arg.Id == id);
            _academics.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<AcademicGoal> GetItemAsync(string id)
        {
            return await Task.FromResult(_academics.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<AcademicGoal>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_academics);
        }
    }
}
