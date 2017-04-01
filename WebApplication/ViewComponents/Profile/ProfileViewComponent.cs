using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Services;
using WebApplication.Infrastructure.Services;

namespace WebApplication.ViewComponents.Profile
{
    [ViewComponent(Name = "Profile")]
    public class ProfileViewComponent : ViewComponent
    {

      
        public async Task<IViewComponentResult> Invoke()
        {            
            return View();
        }
    }
}
