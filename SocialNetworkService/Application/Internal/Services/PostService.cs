using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class PostService : IPostService
    {
        public Task<PostResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostResource>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostResource>> ListByAuthorCodeAsync(string authorCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostResource>> ListTopPostsAsync(int limit = 10)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> SaveAsync(SavePostResource post)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> UpdateAsync(string id, SavePostResource post)
        {
            throw new NotImplementedException();
        }
    }
}
