namespace PitagorasSNS.API.Shared.Domain.Repositories
{
	public interface IBaseRepository<TEntity>
	{
		Task AddAsync(TEntity entity);
		Task<TEntity?> FindByIdAsync(string id);
		Task UpdateAsync(TEntity entity);
		Task RemoveAsync(TEntity entity);
		Task<IEnumerable<TEntity>> ListAsync();
	}
}