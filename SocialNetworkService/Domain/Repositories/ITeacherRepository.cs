using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        public Task<Teacher> GetTeacherByCodeAsync(string code);
    }
}