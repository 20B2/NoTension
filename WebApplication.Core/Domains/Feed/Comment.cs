using System;

namespace WebApplication.Core.Domains.Feed
{
    public class Comment :BaseEntity
    {
        public string UserId { get; set; }

        public DateTimeOffset Time { get; set; }

        public string Text { get; set; }


    }
}