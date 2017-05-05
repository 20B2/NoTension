using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Tech;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Infrastructure.Repository
{
    public class TechItemRepository : ITechItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TechItemRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TechItem Get(string _id)
        {
            return _context.TechItemCollection.Find(x => x.Id == _id).FirstOrDefault();
        }

        public async Task Save(TechItem item)
        {
            await _context.TechItemCollection.InsertOneAsync(item);
        }

        public async Task Delete(TechItem item)
        {
            await _context.TechItemCollection.DeleteOneAsync(x => x.Id == item.Id);
        }

        public async Task Update(TechItem item)
        {
            await _context.TechItemCollection.ReplaceOneAsync(x => x.Id == item.Id, item);

        }

        public async Task<List<TechItem>> FindAll()
        {
            var item = await _context.TechItemCollection.Find("{}").ToListAsync();
            return item;
        }
    }
}
