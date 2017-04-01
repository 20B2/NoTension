using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains.StatusType
{
    public class StatusType : BaseEntity
    {
        public string TypeName { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
