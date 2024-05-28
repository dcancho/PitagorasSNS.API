using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.Shared.Infrastructure.Configuration
{
	/// <summary>
	/// Represents the MongoDB context for the application.
	/// </summary>
	using Microsoft.Azure.Cosmos;

	public class AppDbContext
	{
		private readonly CosmosClient _client;
		private readonly Database _database;

		public AppDbContext(CosmosClient client, string databaseName)
		{
			_client = client;
			_database = _client.GetDatabase(databaseName);
		}

		public Container GetContainer<TEntity>() where TEntity : IEntity
		{
			return _database.GetContainer(typeof(TEntity).Name);
		}
	}
}