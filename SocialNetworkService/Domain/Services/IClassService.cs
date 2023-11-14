using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface IClassService
    {
        public Task<IEnumerable<ClassResource>> ListAllAsync();
        public Task<ClassResource> FindByClassCodeAsync(string classCode);
        public Task<IEnumerable<ClassResource>> ListByTeacherCodeAsync(string teacherCode);
        public Task<IEnumerable<ClassResource>> ListByStudentCodeAsync(string studentCode);
        public Task<ClassResponse> SaveAsync(SaveClassResource classResource);
        public Task<ClassResponse> UpdateAsync(string classCode, SaveClassResource classResource);
        public Task<ClassResponse> DeleteAsync(string classCode);
    }
}