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
    [ViewComponent(Name = "General")]
    public class GeneralViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
