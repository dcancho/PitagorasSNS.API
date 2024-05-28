
namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class ScoresRecord : IEntity
    {
        public string Id { get; set; } = string.Empty;

        public string StudentId { get; set; } = string.Empty;

        public string StudentCode { get; set; } = string.Empty;

        public string ClassId { get; set; } = string.Empty;

        public string ClassCode { get; set; } = string.Empty;

        public string CourseId { get; set; } = string.Empty;

        public string CourseCode { get; set; } = string.Empty;

        public float Score { get; set; }
    }
}
