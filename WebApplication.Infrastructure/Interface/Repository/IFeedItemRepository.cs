using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Infrastructure.Repository
{
    public interface IFeedItemRepository
    {
        Task Delete(FeedItem item);
        Task<List<FeedItem>> FindAll();
        Task<FeedItem> Get(string _id);
        Task Save(FeedItem item);
        Task Update(FeedItem item);
        void IncrementLike(Like model);
        void DecrementLike(Like model);
        void PublishComment(Comment model);
        void DePublishComment(object model);
        Task<List<Comment>> GetCommentById(string statusId);
        Task<List<FeedItem>> FindAllByType(string Type);
    }
}