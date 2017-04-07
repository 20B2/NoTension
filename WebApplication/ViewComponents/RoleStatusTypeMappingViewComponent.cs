using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.ViewComponents
{
    [ViewComponent(Name="RoleStatusTypeMapping")]
    public class RoleStatusTypeMappingViewComponent : ViewComponent
    {
        private readonly IRoleStatusTypeMappingRepository _roleStatusTypeMappingRepository;

        public RoleStatusTypeMappingViewComponent(IRoleStatusTypeMappingRepository roleStatusTypeMappingRepository)
        {
            _roleStatusTypeMappingRepository = roleStatusTypeMappingRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
