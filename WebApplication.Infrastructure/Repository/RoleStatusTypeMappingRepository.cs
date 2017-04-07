using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Infrastructure.Repository
{
    public class RoleStatusTypeMappingRepository : IRoleStatusTypeMappingRepository
    {


        private readonly ApplicationDbContext _context;

        public RoleStatusTypeMappingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RoleStatusTypeMapping> Get(string _id)
        {
            return await _context.RoleStatusTypeMappingCollection.FindSync(x => x.Id == _id).SingleAsync();
        }

        public async Task Save(RoleStatusTypeMapping statusType)
        {
            await _context.RoleStatusTypeMappingCollection.InsertOneAsync(statusType);
        }

        public async Task Delete(string statusType)
        {
            await _context.RoleStatusTypeMappingCollection.DeleteOneAsync(x => x.RoleName == statusType);
        }

        public async Task Update(RoleStatusTypeMapping statusType)
        {

            await _context.RoleStatusTypeMappingCollection.ReplaceOneAsync(x => x.RoleName == statusType.RoleName, statusType);

        }

        public async Task<List<RoleStatusTypeMapping>> FindAll()
        {

            var item = await _context.RoleStatusTypeMappingCollection.Find("{}").ToListAsync();
            return item;
        }

        public Task Delete(RoleStatusTypeMapping item)
        {
            throw new NotImplementedException();
        }



    }
}
