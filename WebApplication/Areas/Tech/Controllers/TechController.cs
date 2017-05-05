using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Areas.Tech.Controllers
{
    public class TechController : Controller
    {
        private readonly ITechItemRepository _techRepository;

        public TechController(ITechItemRepository techRepository)
        {
            _techRepository = techRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
