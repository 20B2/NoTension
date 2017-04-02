using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.Services;

namespace WebApplication.Areas.Feed.ViewComponents.Feed
{
    [ViewComponent(Name = "FeedPost")]
    public class FeedPostViewComponent : ViewComponent
    {
        //private IStatusTypeRepository _statusTypeRepository;

        //public FeedPostViewComponent(IStatusTypeRepository statusTypeRepository)
        //{
        //    _statusTypeRepository = statusTypeRepository;
        //}

        public IViewComponentResult Invoke()
        {
            //ViewBag.StatusType = _statusTypeRepository.FindAll();

            return View();
        }
    }
}
