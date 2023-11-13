namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class StudentResource
    {
        public string Id {get; set;}
        public string StudentCode {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public float AverageScore {get; set;}
    }

    public class SaveStudentResource
    {
        public string StudentCode {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
}
