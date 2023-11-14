using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class StudentService : IStudentService
    {
        public Task<StudentResponse> DeleteAsync(string studentCode)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResource> FindByStudentCodeAsync(string studentCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentResource>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ListTopStudentsAsync(int top = 10)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> SaveAsync(SaveStudentResource studentResource)
        {
            throw new NotImplementedException();
        }

        public Task<StudentResponse> UpdateAsync(string studentCode, SaveStudentResource studentResource)
        {
            throw new NotImplementedException();
        }
    }
}
