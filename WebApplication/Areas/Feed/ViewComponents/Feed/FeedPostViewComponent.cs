using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Services;

namespace WebApplication.Areas.Feed.ViewComponents.Feed
{
    [ViewComponent(Name = "FeedPost")]
    public class FeedPostViewComponent : ViewComponent
    {
     // private readonly FeedItemService _feedItemService;
     
        public IViewComponentResult Invoke()
        {            
            return View();
        }
    }
}
