using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Identity;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.Repository;

namespace WebApplication.Areas.Feed.Controllers
{
    [Authorize()]
    [Area("Feed")]
     public class MyExpertController : Controller
    {
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly IFeedItemRepository _feedItemRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public MyExpertController(IStatusTypeRepository statusTypeRepository,
            IFeedItemRepository feedItemRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _statusTypeRepository = statusTypeRepository;
            _feedItemRepository = feedItemRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var domainExpertType = await _userManager.GetRolesAsync(user);

            var ItemByType = new List<FeedItem>();

            foreach (string item in domainExpertType)
            {
                ItemByType = await _feedItemRepository.FindAllByType(item);

            }

            var recentStatus = ItemByType
                               .OrderByDescending(x => x.PublishedDate)
                               .Take(10)
                               .ToList();
            
            return View(recentStatus);
        }


      
    
        /// Make Precise
        /// Suggest


        public async Task<IActionResult> MakeSuggestion(string id)
        {
            var feedItem = _feedItemRepository.Get(id);
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MakeSuggestion(string id,Suggestion suggestion)
        {
            var feedItem = _feedItemRepository.Get(id);

           // await _feedItemRepository.Suggestion();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PreciseText(string id)
        {
            var feedItem = _feedItemRepository.Get(id);

            return RedirectToAction("Index");
        }

        protected string GetCurrentUserId()
        {
            var task = GetCurrentUserAsync();

            var user = task.Result;

            if (user == null)
            {
                throw new Exception("Unable to get id of current user.");
            }

            return user.Id;
        }
        protected async Task<IdentityUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }


    }
}
