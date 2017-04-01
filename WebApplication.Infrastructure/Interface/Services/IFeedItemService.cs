using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Infrastructure.Services
{
    public interface IFeedItemService
    {
        Task Create(FeedItem entity);
        void Dispose();
        Task<List<FeedItem>> GetAll();
        void Remove(FeedItem feedItem);
        void Update(FeedItem feedItem);
    }
}