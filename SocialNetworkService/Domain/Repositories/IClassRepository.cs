using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        public Task<Class> GetClassByCode(string code);
        public Task<IEnumerable<Class>> GetClassesByTeacherCode(string code);
        public Task<IEnumerable<Class>> GetClassesByStudentCodeAsync(string studentCode);
        public Task<bool> DeleteClassByCode(string code);
    }
}