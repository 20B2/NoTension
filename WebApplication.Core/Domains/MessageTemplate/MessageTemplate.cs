using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Domains.MessageTemplate
{
    public class MessageTemplate : BaseEntity
    {
        [Required]
        public string MessageTemplateTypeID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]

        public string Body { get; set; }

        [EmailAddress]
        public string MailFrom { get; set; }
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
        public bool IsModifield { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset AddedOn { get; set; } = DateTime.UtcNow;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset UpdatedOn { get; set; }

        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
