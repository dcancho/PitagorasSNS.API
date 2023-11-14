using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseResource>> ListAllAsync();
        public Task<CourseResource> FindByCourseCodeAsync(string courseCode);
        public Task<IEnumerable<CourseResource>> ListByCreditAmountAsync(int credits);
        public Task<CourseResponse> SaveAsync(SaveCourseResource courseResource);
        public Task<CourseResponse> UpdateAsync(string courseCode, SaveCourseResource courseResource);
        public Task<CourseResponse> DeleteAsync(string courseCode);
    }
}