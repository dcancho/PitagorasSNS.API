using PitagorasSNS.API.Shared.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Repositories
{
    public interface IScoresRecordRepository : IBaseRepository<ScoresRecord>
    {
        public Task<IEnumerable<ScoresRecord>> FindRecordsByStudentCode(string code);
        public Task<IEnumerable<ScoresRecord>> FindRecordsByClassCode(string code);
        public Task<IEnumerable<ScoresRecord>> FindRecordsByCourseCode(string code);
    }
}