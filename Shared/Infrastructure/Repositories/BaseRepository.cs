using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.Shared.Infrastructure.Configuration
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
    where TEntity : IEntity
    {
        protected readonly AppDbContext _context;
        protected readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(AppDbContext context, IMongoCollection<TEntity> collection)
        {
            _context = context;
            _collection = collection;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<TEntity?> FindByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }
 
        public void Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            _collection.ReplaceOne(filter, entity);
        }

        public void Remove(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            _collection.DeleteOne(filter);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }
    }
}