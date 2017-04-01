using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;

namespace WebApplication.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FeedItem, FeedBoxViewModel>();
            CreateMap<FeedItem, FeedPostViewModel>();

        }
        
    }
}
