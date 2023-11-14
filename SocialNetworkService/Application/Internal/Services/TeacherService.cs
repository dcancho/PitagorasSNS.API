using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class TeacherService : ITeacherService
    {
        public Task<TeacherResponse> DeleteAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResource> FindByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeacherResource>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponse> SaveAsync(SaveTeacherResource teacher)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherResponse> UpdateAsync(string code, SaveTeacherResource teacher)
        {
            throw new NotImplementedException();
        }
    }
}
