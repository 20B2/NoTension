using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Infrastructure.ViewModels.FeedViewModels
{
    public class FeedViewModel
    {
        public string StatusType { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }

        public string OperationStatus { get; set; }

        public DateTimeOffset PublishedDate { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
        public int LikesCounts { get { return Likes.Count(); } }
        public int CommentsCounts { get { return Comments.Count(); } }
        public string UpdatedAgo { get { return ((DateTimeOffset.Now) - (PublishedDate)).ToString(); } }


    }
}
