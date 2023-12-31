using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        public Task<Course> GetCourseByCode(string code);
        public Task<bool> DeleteCourseByCode(string code);
    }
}