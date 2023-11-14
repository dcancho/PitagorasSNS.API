using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostResource>> ListAllAsync();
        Task<IEnumerable<PostResource>> ListByAuthorCodeAsync(string authorCode);
        Task<IEnumerable<PostResource>> ListTopPostsAsync(int limit = 10);
        Task<PostResponse> SaveAsync(SavePostResource post);
        Task<PostResponse> UpdateAsync(string id, SavePostResource post);
        Task<PostResponse> DeleteAsync(string id);
    }
}