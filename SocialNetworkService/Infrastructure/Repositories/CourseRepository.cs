using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context, context.Courses)
        {
        }
        public async Task<Course> GetCourseByCode(string code)
        {
            return await _context.Courses.Find(c => c.CourseCode == code).FirstOrDefaultAsync();
        }
    }
}