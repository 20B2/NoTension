using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.Positive;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Infrastructure.Repository
{
    public class PositiveItemRepository : IPositiveItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PositiveItemRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PositiveItem Get(string _id)
        {
            return _context.PositiveItemCollection.Find(x => x.Id == _id).FirstOrDefault();
        }

        public async Task Save(PositiveItem item)
        {
            await _context.PositiveItemCollection.InsertOneAsync(item);
        }

        public async Task Delete(PositiveItem item)
        {
            await _context.PositiveItemCollection.DeleteOneAsync(x => x.Id == item.Id);
        }

        public async Task Update(PositiveItem item)
        {
            await _context.PositiveItemCollection.ReplaceOneAsync(x => x.Id == item.Id, item);

        }

        public async Task<List<PositiveItem>> FindAll()
        {
            var item = await _context.PositiveItemCollection.Find("{}").ToListAsync();
            return item;
        }
    }
}
