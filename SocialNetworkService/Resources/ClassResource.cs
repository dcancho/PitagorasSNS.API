namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class ClassResource
    {
        public string Id {get; set;}
        public string ClassCode {get; set;}
        public string TeacherCode {get; set;}
        public IEnumerable<string> StudentsEnrolledCode {get; set;}
        public string CourseCode {get; set;}
        public float AverageClassScore {get; set;}
    }

    public class SaveClassResource
    {
        public string ClassCode {get; set;}
        public string TeacherCode {get; set;}
        public IEnumerable<string> StudentsEnrolledCode {get; set;}
        public string CourseCode {get; set;}
    }
}
