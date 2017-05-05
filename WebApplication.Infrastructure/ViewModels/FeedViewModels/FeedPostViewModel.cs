using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Infrastructure.ViewModels.FeedViewModels
{
    public class FeedPostViewModel
    {
        [Required]
        public string StatusType { get; set; }
        [Required]
        public string Text { get; set; }

    }
}
