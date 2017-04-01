using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.MessageTemplate;

namespace WebApplication.Infrastructure.Interface.Repository
{
    public interface IMessageRepository
    {
        Task Delete(MessageTemplate MessageTemplate);
        Task<List<MessageTemplate>> FindAll();
        Task<MessageTemplate> FindByMessageTemplateTypeByID(string Id);
        Task<MessageTemplate> Get(string _id);
        Task Save(MessageTemplate MessageTemplate);
        Task Update(MessageTemplate MessageTemplate);
        Task UpdateMsg(MessageTemplate msg);

    }
}
