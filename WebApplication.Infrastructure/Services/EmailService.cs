using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Infrastructure.Interface.Repository;
using WebApplication.Infrastructure.Interface.Services;

namespace WebApplication.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMessageRepository _messageRepository;

        public EmailService(IMessageRepository imessageRepository)
        {
            _messageRepository = imessageRepository;
        }

    }
}
