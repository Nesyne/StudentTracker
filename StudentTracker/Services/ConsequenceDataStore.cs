using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class ConsequenceDataStore : IDataStore<Consequence>
    {
        List<Consequence> _consequences;

        public ConsequenceDataStore()
        {
            _consequences = new List<Consequence>();

            var consequences = new List<Consequence>
            {
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Adult Attention"},
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Peer Attention"},
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Avoided task"},
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Avoided Environment"},
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Gained preferred activity or item"},
                new Consequence{Id = Guid.NewGuid().ToString(),Name = "Other"},
            };

            foreach (var consequence in consequences)
            {
                _consequences.Add(consequence);
            }
        }

        public async Task<bool> AddItemAsync(Consequence item)
        {
            _consequences.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _consequences.FirstOrDefault((Consequence arg) => arg.Id == id);
            _consequences.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Consequence> GetItemAsync(string id)
        {
            return await Task.FromResult(_consequences.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Consequence>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_consequences);
        }

        public async Task<bool> UpdateItemAsync(Consequence item)
        {
            var oldItem = _consequences.FirstOrDefault((Consequence arg) => arg.Id == item.Id);
            _consequences.Remove(oldItem);
            _consequences.Add(item);

            return await Task.FromResult(true);
        }
    }
}
