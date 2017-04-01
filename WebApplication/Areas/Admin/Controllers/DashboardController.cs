using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Services;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IViewModelService _viewModelService;

        public DashboardController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Dashboard";

            return View(_viewModelService.GetUserDashboardViewModel());
        }

    }
}
