using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Infrastructure.Repository;
using WebApplication.Infrastructure.Services;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Controllers
{
    public class FeedController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FeedPostViewModel item)
        {
            //await _feedItemService.Save(new FeedItem { Text = item.Text });
            return View();
        }

        [HttpPost]
        public IActionResult PublishedPost([FromBody]FeedPostViewModel model)
        {
            return RedirectToAction("Index");

        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PublishedPost([Bind("Text, Image")] FeedItem feedItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _feedItemService.Create(feedItem);
        //         return RedirectToAction("Index");
        //    }
        //    return View(feedItem);
        //}

        //public IActionResult EditPost(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var feedItem = _feedItemService.GetAll().Result.Single(m => m.Id == id);
        //    if (feedItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(feedItem);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Text,IsPublished,Image")] FeedItem feedItem)
        //{
        //    if (id != feedItem.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _feedItemService.Update(feedItem);
        //                      }
        //        catch (Exception ex)
        //        {
        //            if (!FeedItemExists(feedItem.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(feedItem);
        //}


        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var feedItem = _feedItemService.GetAll().Result.Single(m => m.Id == id);
        //    if (feedItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(feedItem);
        //}

        //// POST: FeedItems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var feedItem = _feedItemService.GetAll().Result.Single(m => m.Id == id);
        //    _feedItemService.Remove(feedItem);

        //    return RedirectToAction("Index");
        //}

        //private bool FeedItemExists(string id)
        //{
        //    return _feedItemService.GetAll().Result.Any(e => e.Id == id);
        //}




    }
}
