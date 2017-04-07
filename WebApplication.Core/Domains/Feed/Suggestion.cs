using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains.Feed
{
    public class Suggestion : BaseEntity
    {
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        //expertid
        //thumbup

    }
}
