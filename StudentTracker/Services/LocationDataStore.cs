using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class LocationDataStore :IDataStore<Location>
    {
        List<Location> _locations;

        public LocationDataStore()
        {
            _locations = new List<Location>();

            var locations = new List<Location>
            {
                new Location{Id = Guid.NewGuid().ToString(), Name = "Classroom"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Hallway"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Outside"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Focus Room"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Arts Block"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Cafeteria"},
                new Location{Id = Guid.NewGuid().ToString(), Name = "Other"},

            };

            foreach(Location location in locations)
            {
                _locations.Add(location);
            }
        }

        public async Task<bool> AddItemAsync(Location item)
        {
            _locations.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _locations.FirstOrDefault((Location arg) => arg.Id == id);
            _locations.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Location> GetItemAsync(string id)
        {
            return await Task.FromResult(_locations.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Location>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_locations);
        }

        public async Task<bool> UpdateItemAsync(Location item)
        {
            var oldItem = _locations.FirstOrDefault((Location arg) => arg.Id == item.Id);
            _locations.Remove(oldItem);
            _locations.Add(item);

            return await Task.FromResult(true);
        }
    }
}
