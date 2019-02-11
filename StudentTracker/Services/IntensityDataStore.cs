using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class IntensityDataStore :IDataStore<Intensity>
    {
        List<Intensity> _intensities;

        public IntensityDataStore()
        {
            _intensities = new List<Intensity>();

            var intensities = new List<Intensity>
            {
                new Intensity{Id = Guid.NewGuid().ToString(), Name ="Low"},
                new Intensity{Id = Guid.NewGuid().ToString(), Name ="Medium"},
                new Intensity{Id = Guid.NewGuid().ToString(), Name ="High"},
            };

            foreach (var intensity in intensities)
            {
                _intensities.Add(intensity);
            }
        }

        public async Task<bool> AddItemAsync(Intensity item)
        {
            _intensities.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _intensities.FirstOrDefault((Intensity arg) => arg.Id == id);
            _intensities.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Intensity> GetItemAsync(string id)
        {
            return await Task.FromResult(_intensities.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Intensity>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_intensities);
        }

        public async Task<bool> UpdateItemAsync(Intensity item)
        {
            var oldItem = _intensities.FirstOrDefault((Intensity arg) => arg.Id == item.Id);
            _intensities.Remove(oldItem);
            _intensities.Add(item);

            return await Task.FromResult(true);
        }
    }
}
