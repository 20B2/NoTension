using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Infrastructure.Repository
{
    public class FeedItemRepository : IFeedItemRepository
    {
        protected readonly ApplicationDbContext _context;
        public FeedItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FeedItem> Get(string _id)
        {

            return await _context.FeedItemCollection.FindSync<FeedItem>(x => x.Id == _id).SingleAsync();
        }

        public async Task Save(FeedItem item)
        {
            await _context.FeedItemCollection.InsertOneAsync(item);
        }

        public async Task Delete(FeedItem item)
        {
            await _context.FeedItemCollection.DeleteOneAsync(x => x.Id == item.Id);
        }

        public async Task Update(FeedItem item)
        {
            await _context.FeedItemCollection.ReplaceOneAsync(x => x.Id == item.Id, item);

        }

        public async Task<List<FeedItem>> FindAll()
        {
            var item = await _context.FeedItemCollection.Find("{}").ToListAsync();
            return item;
        }



    }
}
