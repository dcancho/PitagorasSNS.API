using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context, context.Teachers)
        {
        }
        public async Task<Teacher> GetTeacherByCodeAsync(string code)
        {
            return await _context.Teachers.Find(c => c.TeacherCode == code).FirstOrDefaultAsync();
        }
    }
}