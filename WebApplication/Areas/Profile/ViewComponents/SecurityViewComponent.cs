using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Services;
using WebApplication.Infrastructure.Services;

namespace WebApplication.Areas.Profile.ViewComponents
{
    [ViewComponent(Name = "Security")]
    public class SecurityViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
