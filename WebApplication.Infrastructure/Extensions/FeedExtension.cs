using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Identity;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Infrastructure.Extensions
{
    public static partial class FeedExtension
    {
        public static List<FeedBoxViewModel> ToListViewModel(this Task<List<FeedItem>> source)
        {
            var destination = new List<FeedBoxViewModel>();

            if (source != null)
            {
                foreach (var item in source.Result)
                {
                    destination.Add(item.ToFeedBoxViewModel());

                }
            }
            return destination;
        }       
        public static FeedBoxViewModel ToFeedBoxViewModel(this FeedItem source)
        {
            var destination = new FeedBoxViewModel();
            destination.Feed = new FeedViewModel();
            destination.FeedComments = new CommentViewModel();
            destination.Likes = new LikeViewModel();
            
           
            destination.FeedComments.StatusId = source.Id;
            
            destination.Feed.IsPublished = source.IsPublished;
            destination.Feed.OperationStatus = source.OperationStatus;
            destination.Feed.PublishedDate = source.PublishedDate;
            destination.Feed.StatusType = source.StatusType;

            destination.Feed.Text = source.Text;
            destination.Feed.Comments = new List<Comment>();

            if (source.Comments != null)
            {
                foreach (var comment in source.Comments)
                {
                    destination.Feed.Comments.Add(comment);

                }
            }


            return destination;
        }        
    }
    

}
