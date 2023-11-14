using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class CourseService : ICourseService
    {
        public Task<CourseResponse> DeleteAsync(string courseCode)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResource> FindByCourseCodeAsync(string courseCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseResource>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseResource>> ListByCreditAmountAsync(int credits)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse> SaveAsync(SaveCourseResource courseResource)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse> UpdateAsync(string courseCode, SaveCourseResource courseResource)
        {
            throw new NotImplementedException();
        }
    }
}
