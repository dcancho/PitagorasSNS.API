using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq;

namespace PitagorasSNS.API.Shared.Infrastructure.Configuration
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>
	where TEntity : IEntity
	{
		protected readonly AppDbContext _context;
		protected readonly Container _container;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
			_container = _context.GetContainer<TEntity>();
		}

		public async Task AddAsync(TEntity entity)
		{
			await _container.CreateItemAsync(entity, new PartitionKey(entity.Id));
		}

		public async Task<TEntity?> FindByIdAsync(string id)
		{
			try
			{
				ItemResponse<TEntity> response = await _container.ReadItemAsync<TEntity>(id, new PartitionKey(id));
				return response.Resource;
			}
			catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return default;
			}
		}

		public async Task UpdateAsync(TEntity entity)
		{
			await _container.UpsertItemAsync(entity, new PartitionKey(entity.Id));
		}

		public async Task RemoveAsync(TEntity entity)
		{
			await _container.DeleteItemAsync<TEntity>(entity.Id, new PartitionKey(entity.Id));
		}

		public async Task<IEnumerable<TEntity>> ListAsync()
		{
			var query = _container.GetItemLinqQueryable<TEntity>();
			var iterator = query.ToFeedIterator();
			var results = new List<TEntity>();

			while (iterator.HasMoreResults)
			{
				var response = await iterator.ReadNextAsync();
				results.AddRange(response);
			}

			return results;
		}
	}
}