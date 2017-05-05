using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Areas.Positive.Controllers
{
    public class PositiveController : Controller
    {
        private readonly IPositiveItemRepository _positiveRepository;

        public PositiveController(IPositiveItemRepository positiveRepository)
        {
            _positiveRepository = positiveRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
