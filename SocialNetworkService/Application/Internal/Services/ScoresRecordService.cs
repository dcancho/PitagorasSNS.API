using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class ScoresRecordService : IScoresRecordService
    {
        public Task<ScoresRecordResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ScoresRecordResource> FindByStudentCodeAndCourseCodeAsync(string studentCode, string courseCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScoresRecordResource>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScoresRecordResource>> ListByClassCodeAsync(string classCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScoresRecordResource>> ListByCourseCodeAsync(string courseCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScoresRecordResource>> ListByStudentCodeAsync(string studentCode)
        {
            throw new NotImplementedException();
        }

        public Task<ScoresRecordResponse> SaveAsync(SaveScoresRecordResource scoresRecord)
        {
            throw new NotImplementedException();
        }

        public Task<ScoresRecordResponse> UpdateAsync(string id, SaveScoresRecordResource scoresRecord)
        {
            throw new NotImplementedException();
        }
    }
}
