using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Core.Domains.MessageTemplate;
using WebApplication.Core.Domains.StatusType;
using WebApplication.Identity;

namespace WebApplication.Infrastructure
{
    public class ApplicationDbContext : IdentityDatabaseContext<IdentityUser, IdentityRole, string>
    {

        public string FeedItemCollectionName { get; set; } = $"FeedItem";
        
        public virtual IMongoCollection<FeedItem> FeedItemCollection
        {
            get
            {
                if (_feedItemCollection == null)
                {                                    
                    _feedItemCollection = Database.GetCollection<FeedItem>(FeedItemCollectionName, CollectionSettings);
                }
                return _feedItemCollection;
                           }
            set { _feedItemCollection = value; }
        }
        private IMongoCollection<FeedItem> _feedItemCollection;


        public string MessageTemplateCollectionName { get; set; } = $"Message Template";

        public virtual IMongoCollection<MessageTemplate> MessageTemplateCollection
        {
            get
            {
                if (_messageTemplateCollection == null)
                {
                    _messageTemplateCollection = Database.GetCollection<MessageTemplate>(MessageTemplateCollectionName, CollectionSettings);
                }
                return _messageTemplateCollection;
            }
            set { _messageTemplateCollection = value; }
        }
        private IMongoCollection<MessageTemplate> _messageTemplateCollection;


        public string StatusTypeCollectionName { get; set; } = $"Status Type";

        public virtual IMongoCollection<StatusType> StatusTypeCollection
        {
            get
            {
                if (_statusTypeCollection == null)
                {
                    _statusTypeCollection = Database.GetCollection<StatusType>(StatusTypeCollectionName, CollectionSettings);
                }
                return _statusTypeCollection;
            }
            set { _statusTypeCollection = value; }
        }
        private IMongoCollection<StatusType> _statusTypeCollection;



    }
}
