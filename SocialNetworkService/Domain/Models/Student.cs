
namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Student : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public float AverageScore { get; set; }
    }
}
