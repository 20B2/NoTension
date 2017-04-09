using System.ComponentModel.DataAnnotations;

namespace WebApplication.Core.Domains.Feed
{
    public class FeedItemType : BaseEntity
    {
        [Required]
        public string Text { get; set; }
    }
}