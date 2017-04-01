using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.MessageTemplate;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Infrastructure.Repository
{
    public class MessageRepository : IMessageRepository
    {
        protected readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<MessageTemplate> Get(string _id)
        {
            //ObjectId _id = ObjectId.Parse(id);
            return await _context.MessageTemplateCollection.FindSync(x => x.Id == _id).SingleAsync();
        }

        public async Task Save(MessageTemplate MessageTemplate)
        {
            await _context.MessageTemplateCollection.InsertOneAsync(MessageTemplate);
        }
         
        public async Task Delete(MessageTemplate MessageTemplate)
        {
            await _context.MessageTemplateCollection.DeleteOneAsync(x => x.Id == MessageTemplate.Id);
        }

        public async Task Update(MessageTemplate MessageTemplate)
        {

            await _context.MessageTemplateCollection.ReplaceOneAsync(x => x.Id == MessageTemplate.Id, MessageTemplate);

        }

        public async Task<List<MessageTemplate>> FindAll()
        {

            var MessageTemplates = await _context.MessageTemplateCollection.Find("{}").ToListAsync();
            return MessageTemplates;
        }



        public virtual Task<MessageTemplate> FindByMessageTemplateTypeByID(string ID)
        {
            if (string.IsNullOrWhiteSpace(ID)) return Task.FromResult((MessageTemplate)null);

            var filter = Builders<MessageTemplate>.Filter.Eq(x => x.MessageTemplateTypeID, ID);
            var options = new FindOptions { AllowPartialResults = false };

            return _context.MessageTemplateCollection.Find(filter, options).SingleOrDefaultAsync();

        }

        public async Task UpdateMsg(MessageTemplate msg)
        {
            await _context.MessageTemplateCollection.ReplaceOneAsync(x => x.Id == msg.Id, msg);
        }

    }
}
