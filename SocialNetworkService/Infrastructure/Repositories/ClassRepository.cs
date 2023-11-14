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

        public async Task<bool> DeleteClassByCode(string code)
        {
            // Returns true if the resource was deleted. False if there wasn't a resource to delete.
            var result = await _context.Classes.DeleteOneAsync(c => c.ClassCode == code);
            return result.DeletedCount > 0;
        }

        public async Task<Class> GetClassByCode(string code)
        {
            return await _context.Classes.Find(c => c.ClassCode == code).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Class>> GetClassesByTeacherCode(string code)
        {
            return await _context.Classes.Find(c => c.TeacherCode == code).ToListAsync();
        }
        public async Task<IEnumerable<Class>> GetClassesByStudentCodeAsync(string studentCode)
        {
            var classes = await _context.Classes.Find(c => c.StudentsEnrolledCode.Any(c => c == studentCode)).ToListAsync();
            return classes;
        }
    }
}