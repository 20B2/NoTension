using System;

namespace WebApplication.Core.Domains.Feed
{
    public class Like : BaseEntity
    {
        public string UserId { get; set; }
        public DateTimeOffset Time { get; set; }


    }
}