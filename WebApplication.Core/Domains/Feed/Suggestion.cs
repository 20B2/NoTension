using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains.Feed
{
    public class Suggestion : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }

        public string UserId { get; set; }

        public List<Like> Likes { get; set; }

    }
}
