using Microsoft.AspNetCore.Identity;
using WebApplication.Identity;
using WebApplication.Infrastructure.Interface.Services;
using WebApplication.Infrastructure.ViewModels.ProfileViewModels;

namespace WebApplication.Infrastructure.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<IdentityUser> _user;
       
        public ProfileService(UserManager<IdentityUser> user)
        {
            _user = user;
        }
        
        public  ProfileViewModel GetProfileViewModel()
        {
           
            return new ProfileViewModel
            {

            };
        }
    }
}
