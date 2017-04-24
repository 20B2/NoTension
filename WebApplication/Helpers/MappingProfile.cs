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
            CreateMap<FeedItem, FeedBoxViewModel>();
            CreateMap<FeedItem, FeedPostViewModel>();
            CreateMap<FeedItem, IndexViewModel>();
            CreateMap<FeedPostViewModel, FeedItem>().ReverseMap();
            CreateMap<IdentityUser, UserViewModel>();
            CreateMap<IdentityRole, RoleViewModel>();

            //CreateMap<IdentityUser, ProfileViewModel>();
            //CreateMap<ProfileViewModel, IdentityUser>();

            CreateMap<IdentityUser, AccountSettingViewModel>();
            CreateMap<IdentityUser, ProfileViewModel>().ReverseMap();
            CreateMap<IdentityUser, IndexViewModel>().ReverseMap();
            CreateMap<IdentityUser, EditProfileViewModel>().ReverseMap();
               


        }
        
    }
}
