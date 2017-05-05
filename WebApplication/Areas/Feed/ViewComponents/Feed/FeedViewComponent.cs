using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;
using WebApplication.Core.Domains.Feed;
using WebApplication.Infrastructure.Extensions;
using WebApplication.Infrastructure.Repository;
using WebApplication.Infrastructure.Services;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Areas.Feed.ViewComponents.Feed
{
    [ViewComponent(Name = "Feed")]
    public class FeedViewComponent : ViewComponent
    {
        private readonly IFeedItemRepository _feedItemReposioty;
        private readonly IMapper _mapper;

        public FeedViewComponent(IFeedItemRepository feedItemReposioty,IMapper mapper)
        {
            _feedItemReposioty = feedItemReposioty;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = _feedItemReposioty.FindAll().ToListViewModel();
                     
            //await PaginatedList<FeedBoxViewModel>.CreateAsync(item.ToList(), page ?? 1, pageSize)


            return View(item); //.OrderByDescending(x=>x.Feed.PublishedDate)
        }
    }
}
