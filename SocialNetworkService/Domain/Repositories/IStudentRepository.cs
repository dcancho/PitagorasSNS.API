using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Task<Student> GetStudentByCodeAsync(string code);
    }
}