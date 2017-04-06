using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Feed;

namespace WebApplication.Areas.Extensions
{
    public static partial class FeedExtension
    {

        public static Comment ToComment(this FeedItem source)
        {
            var destination = new Comment();

            return destination;
        }

    }
}


