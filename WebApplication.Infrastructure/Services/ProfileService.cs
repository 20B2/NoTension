using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        public async  Task<ProfileViewModel> GetProfileViewModel()
        {
           
            return new ProfileViewModel
            {

            };
        }
    }
}
