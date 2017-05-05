using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class RoleStatusTypeMappingController : Controller
    {
        private IRoleStatusTypeMappingRepository _roleStatusTypeMapping;

        public RoleStatusTypeMappingController(IRoleStatusTypeMappingRepository roleStatusTypeMapping)
        {
            _roleStatusTypeMapping = roleStatusTypeMapping;
        }

        public IActionResult Index()
        {
           var item =  _roleStatusTypeMapping.FindAll();

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
