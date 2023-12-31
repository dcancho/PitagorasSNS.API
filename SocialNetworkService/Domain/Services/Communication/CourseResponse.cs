using PitagorasSNS.API.Shared.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication
{
    public class CourseResponse : BaseResponse<CourseResource>
    {
        public CourseResponse(CourseResource resource) : base(resource)
        {
        }
        public CourseResponse(string message) : base(message)
        {
        }
    }
}
