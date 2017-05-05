using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;
using WebApplication.Core.Domains.Feed;
using WebApplication.Core.Domains.MessageTemplate;
using WebApplication.Core.Domains.Positive;
using WebApplication.Core.Domains.StatusType;
using WebApplication.Core.Domains.Tech;
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


        public string RoleStatusTypeMappingCollectionName { get; set; } = $"RoleStatusTypeMapping";

        public virtual IMongoCollection<RoleStatusTypeMapping> RoleStatusTypeMappingCollection
        {
            get
            {
                if (_roleStatusTypeMappingCollection == null)
                {
                    _roleStatusTypeMappingCollection = Database.GetCollection<RoleStatusTypeMapping>(RoleStatusTypeMappingCollectionName, CollectionSettings);
                }
                return _roleStatusTypeMappingCollection;
            }
            set { _roleStatusTypeMappingCollection = value; }
        }
        private IMongoCollection<RoleStatusTypeMapping> _roleStatusTypeMappingCollection;

        #region techitem
        public string TechItemCollectionName { get; set; } = $"TechItem";

        public virtual IMongoCollection<TechItem> TechItemCollection
        {
            get
            {
                if (_techItemCollection == null)
                {
                    _techItemCollection = Database.GetCollection<TechItem>(TechItemCollectionName, CollectionSettings);
                }
                return _techItemCollection;
            }
            set { _techItemCollection = value; }
        }
        private IMongoCollection<TechItem> _techItemCollection;

        #endregion


        #region positiveItem
        public string PositiveItemCollectionName { get; set; } = $"PositiveItem";

        public virtual IMongoCollection<PositiveItem> PositiveItemCollection
        {
            get
            {
                if (_PositiveItemCollection == null)
                {
                    _PositiveItemCollection = Database.GetCollection<PositiveItem>(PositiveItemCollectionName, CollectionSettings);
                }
                return _PositiveItemCollection;
            }
            set { _PositiveItemCollection = value; }
        }
        private IMongoCollection<PositiveItem> _PositiveItemCollection;

        #endregion

        #region techntype
        public string TechTypeCollectionName { get; set; } = $"Tech Type";

        public virtual IMongoCollection<TechType> TechTypeCollection
        {
            get
            {
                if (_techTypeCollection == null)
                {
                    _techTypeCollection = Database.GetCollection<TechType>(TechTypeCollectionName, CollectionSettings);
                }
                return _techTypeCollection;
            }
            set { _techTypeCollection = value; }
        }
        private IMongoCollection<TechType> _techTypeCollection;

        #endregion


        



    }
}
