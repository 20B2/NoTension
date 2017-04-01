using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains.Feed
{
    public class FeedItem : BaseEntity
    {
        public bool IsPublished { get; set; }

        public FeedItemType Type { get; set; }
        public string Text { get; set; }

        public string OperationStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
             ApplyFormatInEditMode = true)]
        public DateTimeKind PublishedDate { get; set; } = DateTimeKind.Utc;

        public string PublishedUserId { get; set; } // need fill this userid

        public byte[] Image { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }


        public string PreciseText { get; set; }

        public string PreciseTextByUserId { get; set; }
        //public List<PreciseHistory> History { get; set; }


    }
}
