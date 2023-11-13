namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class TeacherResource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SaveTeacherResource
    {
        public string Name { get; set; }
        public string TeacherCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
