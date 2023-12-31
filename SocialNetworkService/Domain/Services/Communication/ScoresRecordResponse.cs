using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class ScoresRecordResponse : BaseResponse<ScoresRecordResource>
    {
        public ScoresRecordResponse(ScoresRecordResource resource) : base(resource)
        {
        }
        public ScoresRecordResponse(string message) : base(message)
        {
        }
    }
}
