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

        public void IncrementLike(Like model)
        {

            //var filter = Builders<FeedItem>.Filter.Eq(x =>x.Likes, model);
            //var update = Builders<FeedItem>.Update.Push(x => x.Likes, model);

            //_context.FeedItemCollection.UpdateOneAsync(filter, update);
        }

        public void DecrementLike(Like model)
        {
            //_context.FeedItemCollection.DeleteOne(model);
        }

        public void PublishComment(Comment model)
        {
            var filter = Builders<FeedItem>.Filter.Eq(x => x.Id, model.Id);
            var update = Builders<FeedItem>.Update.Push(x => x.Comments, model);

            _context.FeedItemCollection.UpdateOneAsync(filter, update);
        }

        public void DePublishComment(object model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetCommentById(string statusId)
        {
            if (string.IsNullOrWhiteSpace(statusId)) await Task.FromResult((Comment)null);

            var status = Get(statusId);
            var result = status.Result.Comments.ToList();

            return result;

        }


        public async Task<List<FeedItem>> FindAllByType(string Type)
        {
            if (string.IsNullOrWhiteSpace(Type)) await Task.FromResult((FeedItem)null);

            var filter = Builders<FeedItem>.Filter.Eq(x => x.StatusType, Type);
            var options = new FindOptions { AllowPartialResults = false };

            return await _context.FeedItemCollection.Find(filter, options).ToListAsync();
        }


    }
}
