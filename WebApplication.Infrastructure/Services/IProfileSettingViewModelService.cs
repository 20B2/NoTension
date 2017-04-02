using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Services;
using WebApplication.Infrastructure.ViewModels.ProfileViewModels;

namespace WebApplication.Infrastructure.Services
{
    public class ProfileSettingViewModelService : IProfileSettingViewModelService
    {
         public General GetGeneralSetting()
        {
            return new General { };
        }
        public Security GetSecuritySetting()
        {
            return new Security { };
        }
    }
}
