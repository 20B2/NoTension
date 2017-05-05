using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;
using WebApplication.Identity;
using WebApplication.Infrastructure.ViewModels;
using WebApplication.Infrastructure.ViewModels.FeedViewModels;
using WebApplication.Infrastructure.ViewModels.ProfileViewModels;

namespace WebApplication.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FeedItem, FeedBoxViewModel>().ReverseMap();
            CreateMap<FeedItem, FeedPostViewModel>().ReverseMap();
            CreateMap<FeedItem, IndexViewModel>().ReverseMap();
            CreateMap<FeedItem, Comment>().ReverseMap();
            CreateMap<CommentViewModel, Comment>().ReverseMap();
            CreateMap<FeedItem, Like>().ReverseMap();
            CreateMap<Like, LikeViewModel>().ReverseMap();
           


            CreateMap<FeedPostViewModel, FeedItem>().ReverseMap();
            CreateMap<IdentityUser, UserViewModel>();
            CreateMap<IdentityRole, RoleViewModel>();

            CreateMap<IdentityUser, AccountSettingViewModel>();
            CreateMap<IdentityUser, ProfileViewModel>().ReverseMap(); ;
            CreateMap<IdentityUser, EditProfileViewModel>().ReverseMap();
               


        }
        
    }
}
