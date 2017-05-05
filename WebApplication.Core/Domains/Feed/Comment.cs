using System;

namespace WebApplication.Core.Domains.Feed
{
    public class Comment :BaseEntity
    {
        public string StatusId { get; set; }

        public string UserId { get; set; }

        public DateTimeOffset Time { get; set; } = DateTimeOffset.UtcNow ;

        public string Text { get; set; }


    }
}