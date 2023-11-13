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
    }
}