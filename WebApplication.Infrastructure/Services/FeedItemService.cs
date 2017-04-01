using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Infrastructure.Repository;

namespace WebApplication.Infrastructure.Services
{
    
    public class FeedItemService : IFeedItemService
    {
        private readonly FeedItemRepository _feedItem;

        public FeedItemService(FeedItemRepository feedItem)
        {
            _feedItem = feedItem;
        }


        public async Task Create(FeedItem entity)
        {
            await _feedItem.Save(entity);
        }


        public async Task<List<FeedItem>> GetAll()
        {  
            return await _feedItem.FindAll();

        }
        public void Dispose()
        {

        }

        public async void Update(FeedItem feedItem)
        {
            await _feedItem.Update(feedItem);
            
        }

        public async void Remove(FeedItem feedItem)
        {
            await _feedItem.Delete(feedItem);
        }


    }
}
