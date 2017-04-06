using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;
using WebApplication.Core.Domains.Feed;
using WebApplication.Identity;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.Repository;
using WebApplication.Infrastructure.Services;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Areas.Feed.Controllers
{
    [Area("Feed")]
    [Route("Feed")]
    public class FeedController : Controller
    {
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly IFeedItemRepository _feedItemRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public FeedController(IStatusTypeRepository statusTypeRepository,
            IFeedItemRepository feedItemRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _statusTypeRepository = statusTypeRepository;
            _feedItemRepository = feedItemRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            ViewBag.StatusType = await _statusTypeRepository.FindAll();
                        
            return View();
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult PublishedPost(FeedPostViewModel model)
        {             
             var feed = _mapper.Map<FeedPostViewModel,FeedItem>(model);

            feed.PublishedUserId = GetCurrentUserId();
            _feedItemRepository.Save(feed);

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Default(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var u = await _feedItemRepository.FindAll();

            var users = from m in u
                        select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Text.Contains(searchString)
                                       || s.StatusType
                                       .Contains(searchString));
            }
            switch (sortOrder)
            {
                case "statustype_desc":
                    users = users.OrderByDescending(s => s.StatusType);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.PublishedDate);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.Likes);
                    break;
                default:
                    users = users.OrderBy(s => s.PreciseText);
                    break;
            }
            

            int pageSize = 3;
            return View(await PaginatedList<FeedItem>.CreateAsync(users.ToList(), page ?? 1, pageSize));

        }
        [Route("[action]")]
        public async Task<IActionResult> IncrementLike(Like model)
        {           
            var feed = await _feedItemRepository.Get(GetCurrentUserId()); //feedId

            //if (feed.Likes.Contains(feed))
            //{
            //    model.UserId = GetCurrentUserId();
            //    _feedItemRepository.IncrementLike(model);
            //}
                return View();
        }
        [Route("[action]")]
        public IActionResult DecrementLike(Like model)
        {
            model.UserId = GetCurrentUserId();
            _feedItemRepository.DecrementLike(model);
            return View();
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult PublishComment(Comment model)
        {
            _feedItemRepository.PublishComment(model);
            return View();
        }
        [Route("[action]")]
        public IActionResult DePublishComment(string id)
        {
            _feedItemRepository.DePublishComment(id);
            return View();
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

        [Route("[action]")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedItem =await _feedItemRepository.Get(id);
            if (feedItem == null)
            {
                return NotFound();
            }
            return View(feedItem);
        }
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Text,IsPublished,Image")] FeedItem feedItem)
        {
            if (id != feedItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _feedItemRepository.Update(feedItem);
                }
                catch (Exception ex)
                {
                    if (!(FeedItemExists(feedItem.Id))){ return NotFound(); }
                    else { throw ex; }

                }
                return RedirectToAction("Index");
            }
            return View(feedItem);
        }

        [Route("[action]")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedItem = await  _feedItemRepository.Get(id);
            if (feedItem == null)
            {
                return NotFound();
            }

            return View(feedItem);
        }
        [Route("[action]")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var feedItem = await _feedItemRepository.Get(id);
            await _feedItemRepository.Delete(feedItem);

            return RedirectToAction("Index");
        }

        private bool FeedItemExists(string id)
        {
            return _feedItemRepository.FindAll().Result.Any(e => e.Id == id);
        }




    }
}
