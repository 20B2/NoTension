using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains
{
    public class RoleStatusTypeMapping :BaseEntity
    {
        public string RoleName { get; set; }
        public List<string> StatusTypes { get; set; }
    }
}
