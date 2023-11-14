using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;


namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentResource>> ListAllAsync();
        
        public Task<StudentResource> FindByStudentCodeAsync(string studentCode);

        public Task<StudentResponse> SaveAsync(SaveStudentResource studentResource);

        public Task<StudentResponse> UpdateAsync(string studentCode, SaveStudentResource studentResource);

        public Task<StudentResponse> DeleteAsync(string studentCode);

        public Task<IEnumerable<string>> ListTopStudentsAsync(int top=10);
    }
}
