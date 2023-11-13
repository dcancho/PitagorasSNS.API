using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class ScoresRecordRepository : BaseRepository<ScoresRecord>, IScoresRecordRepository
    {
        public ScoresRecordRepository(AppDbContext context) : base(context, context.ScoresRecords)
        {
        }
        public async Task<IEnumerable<ScoresRecord>> FindRecordsByStudentCode(string code)
        {
            return await _context.ScoresRecords.Find(c => c.StudentCode == code).ToListAsync();
        }
        public async Task<IEnumerable<ScoresRecord>> FindRecordsByClassCode(string code)
        {
            return await _context.ScoresRecords.Find(c => c.ClassCode == code).ToListAsync();
        }
        public async Task<IEnumerable<ScoresRecord>> FindRecordsByCourseCode(string code)
        {
            return await _context.ScoresRecords.Find(c => c.CourseCode == code).ToListAsync();
        }
    }
}