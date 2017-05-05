using System;

namespace WebApplication.Core.Domains.Feed
{
    public class Like : BaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string StatusId { get; set; }
        public DateTimeOffset Time { get; set; }


    }
}