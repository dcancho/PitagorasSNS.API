using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class StudentResponse : BaseResponse<StudentResource>
    {
        public StudentResponse(StudentResource resource) : base(resource)
        {
        }
        public StudentResponse(string message) : base(message)
        {
        }
    }
}
