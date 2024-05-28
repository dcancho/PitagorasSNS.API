namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Teacher : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string TeacherCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}