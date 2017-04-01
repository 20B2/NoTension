using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.StatusType;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Infrastructure.Repository
{
    public class StatusTypeRepository : IStatusTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StatusType> Get(string _id)
        {
             return await _context.StatusTypeCollection.FindSync(x => x.Id == _id).SingleAsync();
        }

        public async Task Save(StatusType statusType)
        {
            await _context.StatusTypeCollection.InsertOneAsync(statusType);
        }

        public async Task Delete(string statusType)
        {
            await _context.StatusTypeCollection.DeleteOneAsync(x => x.TypeName == statusType);
        }

        public async Task Update(StatusType statusType)
        {

            await _context.StatusTypeCollection.ReplaceOneAsync(x => x.TypeName == statusType.TypeName, statusType);

        }

        public async Task<List<StatusType>> FindAll()
        {

            var item = await _context.StatusTypeCollection.Find("{}").ToListAsync();
            return item;
        }

        public Task Delete(StatusType statusType)
        {
            throw new NotImplementedException();
        }
    }
}