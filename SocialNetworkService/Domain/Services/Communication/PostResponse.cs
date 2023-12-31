using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class PostResponse : BaseResponse<PostResource>
    {
        public PostResponse(PostResource resource) : base(resource)
        {
        }
        public PostResponse(string message) : base(message)
        {
        }
    }
}
