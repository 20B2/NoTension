using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Infrastructure.ViewModels.FeedViewModels
{
    public class IndexViewModel
    {
        public List<FeedPostViewModel> FeedPost { get; set; }

        public List<FeedBoxViewModel> FeedBox { get; set; }

     
    }
}
