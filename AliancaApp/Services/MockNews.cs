using AliancaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliancaApp.Services
{
    public class MockNews : IDataStore<News>
    {
        readonly List<News> items;

        public MockNews()
        {
            items = new List<News>()
            {
                new News { Id = Guid.NewGuid().ToString(), Text = "First News", Description="This is an News description." },
                new News { Id = Guid.NewGuid().ToString(), Text = "Second News", Description="This is an News description." },
                new News { Id = Guid.NewGuid().ToString(), Text = "Third News", Description="This is an News description." },
                new News { Id = Guid.NewGuid().ToString(), Text = "Fourth News", Description="This is an News description." },
                new News { Id = Guid.NewGuid().ToString(), Text = "Fifth News", Description="This is an News description." },
                new News { Id = Guid.NewGuid().ToString(), Text = "Sixth News", Description="This is an News description." }
            };
        }

        public async Task<bool> AddItemAsync(News item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(News item)
        {
            var oldItem = items.Where((News arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((News arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<News> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<News>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}