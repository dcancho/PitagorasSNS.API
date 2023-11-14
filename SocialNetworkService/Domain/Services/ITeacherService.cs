using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherResource>> ListAllAsync();
        Task<TeacherResource> FindByCodeAsync(string code);
        Task<TeacherResponse> SaveAsync(SaveTeacherResource teacher);
        Task<TeacherResponse> UpdateAsync(string code, SaveTeacherResource teacher);
        Task<TeacherResponse> DeleteAsync(string code);
    }
}