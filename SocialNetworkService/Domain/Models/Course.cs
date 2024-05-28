namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Course : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public int CourseCredits { get; set; }
    }
}