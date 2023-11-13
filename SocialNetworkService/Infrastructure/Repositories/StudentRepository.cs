using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context, context.Students)
        {
        }
        public async Task<Student> GetStudentByCodeAsync(string code)
        {
            return await _context.Students.Find(c => c.StudentCode == code).FirstOrDefaultAsync();
        }
    }
}