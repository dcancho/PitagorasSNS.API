using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Services
{
    public interface IScoresRecordService
    {
        Task<IEnumerable<ScoresRecordResource>> ListAllAsync();
        Task<ScoresRecordResource> FindByStudentCodeAndCourseCodeAsync(string studentCode, string courseCode);
        Task<IEnumerable<ScoresRecordResource>> ListByStudentCodeAsync(string studentCode);
        Task<IEnumerable<ScoresRecordResource>> ListByClassCodeAsync(string classCode);
        Task<IEnumerable<ScoresRecordResource>> ListByCourseCodeAsync(string courseCode);
        Task<ScoresRecordResponse> SaveAsync(SaveScoresRecordResource scoresRecord);
        Task<ScoresRecordResponse> UpdateAsync(string id, SaveScoresRecordResource scoresRecord);
        Task<ScoresRecordResponse> DeleteAsync(string id);
    }
}