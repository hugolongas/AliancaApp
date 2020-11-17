using AliancaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliancaApp.Services
{
    public class MockActivites : IDataStore<Activity>
    {
        readonly List<Activity> items;

        public MockActivites()
        {
            items = new List<Activity>()
            {
                new Activity { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Activity { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Activity { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Activity { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Activity { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Activity { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Activity item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Activity item)
        {
            var oldItem = items.Where((Activity arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Activity arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Activity> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Activity>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}