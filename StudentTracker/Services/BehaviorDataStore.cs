using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class BehaviorDataStore : IDataStore<Behavior>
    {
        List<Behavior> _behaviors;

        public BehaviorDataStore()
        {
            _behaviors = new List<Behavior>();

            var behaviors = new List<Behavior>
            {
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Elopement"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Yelling/Screaming"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Agg towards others"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Throwing item(s)"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Agg towards self"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Destruction of property"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Refusal"},
                new Behavior{Id = Guid.NewGuid().ToString(),Name ="Other"},
            };

            foreach (var behavior in behaviors)
            {
                _behaviors.Add(behavior);
            }
        }

        public async Task<bool> AddItemAsync(Behavior item)
        {
            _behaviors.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _behaviors.FirstOrDefault((Behavior arg) => arg.Id == id);
            _behaviors.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Behavior> GetItemAsync(string id)
        {
            return await Task.FromResult(_behaviors.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Behavior>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_behaviors);
        }

        public async Task<bool> UpdateItemAsync(Behavior item)
        {
            var oldItem = _behaviors.FirstOrDefault((Behavior arg) => arg.Id == item.Id);
            _behaviors.Remove(oldItem);
            _behaviors.Add(item);

            return await Task.FromResult(true);
        }
    }
}
