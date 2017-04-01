using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Repository;
using WebApplication.Infrastructure.Services;

namespace WebApplication.ViewComponents.Feed
{
    [ViewComponent(Name = "FeedBox")]
    public class FeedBoxViewComponent : ViewComponent
    {
        private readonly IFeedItemRepository _feedItemReposioty;

        public FeedBoxViewComponent(IFeedItemRepository feedItemReposioty)
        {
            _feedItemReposioty = feedItemReposioty;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _feedItemReposioty.FindAll();

            return View(item);
        }
    }
}
