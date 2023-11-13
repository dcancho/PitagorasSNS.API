using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context, context.Classes)
        {

        }
        public async Task<Class> GetClassByCode(string code)
        {
            return await _context.Classes.Find(c => c.ClassCode == code).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Class>> GetClassesByTeacherCode(string code)
        {
            return await _context.Classes.Find(c => c.TeacherCode == code).ToListAsync();
        }
        public async Task<IEnumerable<Course>> GetCoursesByStudentCodeAsync(string studentCode)
        {
            var classes = await _context.Classes
                .Find(c => c.StudentsEnrolledCode.Contains(studentCode))
                .ToListAsync();

            var courseIds = classes.Select(c => c.CourseId);

            var courses = await _context.Courses
                .Find(c => courseIds.Contains(c.Id))
                .ToListAsync();

            return courses;
        }
    }
}