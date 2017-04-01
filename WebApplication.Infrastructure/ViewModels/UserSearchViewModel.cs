using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Identity;

namespace WebApplication.Infrastructure.ViewModels
{
    public class UserSearchViewModel
    {
        public List<IdentityUser> Users { get; set; }
        //public SelectList selectList { get; set; }
        public string User { get; set; }

    }
}
