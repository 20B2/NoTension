using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Areas.Feed.ViewComponents.Feed
{
    [ViewComponent(Name ="CommentDetails")]
    public class FeedBoxCommentDetailViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Comment> items)
        {
            
           return View();

        }
    }
}
