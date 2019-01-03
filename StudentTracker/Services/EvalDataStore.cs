using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentTracker.Models;
namespace StudentTracker.Services
{
    public class EvalDataStore : IDataStore<Eval>
    {
        List<Eval> evals;

        public EvalDataStore()
        {
            evals = new List<Eval>();
            var mockItems = new List<Eval>
            {
                new Eval { Id = Guid.NewGuid().ToString(), Name = "Complete Work On Time", Description="This is an item description." },
                new Eval { Id = Guid.NewGuid().ToString(), Name = "Safety", Description="This is an item description." },
                new Eval { Id = Guid.NewGuid().ToString(), Name = "Communicates need for a break when in the yellow zone", Description="This is an item description." },
                new Eval { Id = Guid.NewGuid().ToString(), Name = "Communicates appropriately when others are bothering", Description="This is an item description." },

            };

            foreach (var eval in mockItems)
            {
                evals.Add(eval);
            }
        }

        public async Task<bool> AddItemAsync(Eval eval)
        {
            evals.Add(eval);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Eval eval)
        {
            var oldItem = evals.Where((Eval arg) => arg.Id == eval.Id).FirstOrDefault();
            evals.Remove(oldItem);
            evals.Add(eval);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = evals.Where((Eval arg) => arg.Id == id).FirstOrDefault();
            evals.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Eval> GetItemAsync(string id)
        {
            return await Task.FromResult(evals.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Eval>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(evals);
        }
    }
}
