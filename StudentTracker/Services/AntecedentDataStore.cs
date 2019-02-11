using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;

namespace StudentTracker.Services
{
    public class AntecedentDataStore : IDataStore<Antecedent>
    {
        List<Antecedent> _antecedents;

        public AntecedentDataStore()
        {
            _antecedents = new List<Antecedent>();

            var antecedents = new List<Antecedent>
            {
                new Antecedent{Id =Guid.NewGuid().ToString(), Name = "Peer interaction"},
                new Antecedent{Id =Guid.NewGuid().ToString(), Name = "Perceived different work"},
                new Antecedent{Id =Guid.NewGuid().ToString(), Name = "Given Prompt/task"},
                new Antecedent{Id =Guid.NewGuid().ToString(), Name = "Transition; change in activity"},
                new Antecedent{Id =Guid.NewGuid().ToString(), Name = "Other"},
            };

            foreach(Antecedent antecedent in antecedents)
            {
                _antecedents.Add(antecedent);
            }
        }

        public async Task<bool> AddItemAsync(Antecedent item)
        {
            _antecedents.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _antecedents.FirstOrDefault((Antecedent arg) => arg.Id == id);
            _antecedents.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Antecedent> GetItemAsync(string id)
        {
            return await Task.FromResult(_antecedents.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Antecedent>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_antecedents);
        }

        public async Task<bool> UpdateItemAsync(Antecedent item)
        {
            var oldItem = _antecedents.FirstOrDefault((Antecedent arg) => arg.Id == item.Id);
            _antecedents.Remove(oldItem);
            _antecedents.Add(item);

            return await Task.FromResult(true);
        }
    }
}
