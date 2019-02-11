using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class ActivityDataStore : IDataStore<Activity>
    {
        List<Activity> _activities;

        public ActivityDataStore()
        {
            _activities = new List<Activity>();

            var activities = new List<Activity>
            {
                new Activity{Id = Guid.NewGuid().ToString(),Name="Large Group"},
                new Activity{Id = Guid.NewGuid().ToString(),Name="Small Group"},
                new Activity{Id = Guid.NewGuid().ToString(),Name="Independent"},
                new Activity{Id = Guid.NewGuid().ToString(),Name="Transition"},
                new Activity{Id = Guid.NewGuid().ToString(),Name="Unstractured Time"},
                new Activity{Id = Guid.NewGuid().ToString(),Name="Other"},
            };

            foreach (Activity activity in activities)
            {
                _activities.Add(activity);
            }
        }

        public async Task<bool> AddItemAsync(Activity item)
        {
            _activities.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _activities.FirstOrDefault((Activity arg) => arg.Id == id);
            _activities.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Activity> GetItemAsync(string id)
        {
            return await Task.FromResult(_activities.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Activity>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_activities);
        }

        public async Task<bool> UpdateItemAsync(Activity item)
        {
            var oldItem = _activities.FirstOrDefault((Activity arg) => arg.Id == item.Id);
            _activities.Remove(oldItem);
            _activities.Add(item);

            return await Task.FromResult(true);
        }
    }
}
