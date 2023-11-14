using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class ClassResponse : BaseResponse<ClassResource>
    {
        public ClassResponse(ClassResource resource) : base(resource)
        {
        }
        public ClassResponse(string message) : base(message)
        {
        }
    }
}