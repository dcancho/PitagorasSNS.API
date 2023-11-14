using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
public Task<IEnumerable<Post>> FindPostsByAuthorCodeAsync(string code);
public Task<IEnumerable<Post>> ListTopPostsAsync(int limit = 10);
    }
}