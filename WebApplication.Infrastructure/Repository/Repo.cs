//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime;
//using System.Text;
//using System.Threading.Tasks;

//namespace WebApplication.Infrastructure.Repository
//{
//    public class Repo<T> : IRepo<T> where T:class

//    {
//        private readonly ApplicationDbContext _context = null;
//        public Repo(IOptions<Settings> setting)
//        {
//            _context = new ApplicationDbContext(setting);

//        }

//        IQueryable<T> GetAll() {
//            return _context.Database.GetCollection<T>(T.GetType()).Find(x => true).ToList();
//        }
//        public async Task<IEnumerable<T>> GetAllNotes()
//        {
//            var documents = await _context..Database.GetCollection<T>().Find(_ => true)
//                            .ToListAsync();
//            return documents;
//        }

//        public async Task<T> Get(string id)
//        {
//            var filter = Builders<T>.Filter.Eq("Id", id);
//            var document = await _context.Database.GetCollection<T>().Find(filter).FirstOrDefaultAsync();
//            return document;
//        }

//        public async void Add(T item)
//        {
//            await _context.Database.GetCollection<T>().InsertOneAsync(item);
//        }

//        public async Task<bool> Remove(string id)
//        {
//            var result = await _context.Database.GetCollection<T>().DeleteOneAsync(
//                 Builders<T>.Filter.Eq("Id", id));

//            return result.DeletedCount > 0;
//        }

//        public async void Update(string id, string body)
//        {
//            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
//            var update = Builders<T>.Update
//                            .Set(s => s.Body, body)
//                            .CurrentDate(s => s.UpdatedOn);
//            var result = await _context.Database.GetCollection<T>().UpdateOneAsync(filter, update);
//        }

//        public void RemoveAll()
//        {
//            _context.Database.GetCollection<T>().DeleteManyAsync(new BsonDocument());
//        }
//    }
//}
