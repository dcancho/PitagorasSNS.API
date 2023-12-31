using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class TeacherResponse : BaseResponse<TeacherResource>
    {
        public TeacherResponse(TeacherResource resource) : base(resource)
        {
        }
        public TeacherResponse(string message) : base(message)
        {
        }
    }
}
