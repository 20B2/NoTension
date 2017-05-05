using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Infrastructure.ViewModels.FeedViewModels
{
    public class FeedBoxViewModel
    {
        public FeedViewModel Feed { get; set; }

        public CommentViewModel FeedComments { get; set; }
        public LikeViewModel Likes { get; set; }

    }
}
