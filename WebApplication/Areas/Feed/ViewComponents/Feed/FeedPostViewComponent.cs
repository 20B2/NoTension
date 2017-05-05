using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.Services;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Areas.Feed.ViewComponents.Feed
{
    [ViewComponent(Name = "FeedPost")]
    public class FeedPostViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
