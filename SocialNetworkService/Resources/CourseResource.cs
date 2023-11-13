namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class CourseResource
    {
        public string Id {get; set;}
        public string CourseCode {get; set;}
        public string CourseName {get; set;}
        public string CourseDescription {get; set;}
        public int CourseCredits {get; set;}
    }

    public class SaveCourseResource
    {
        public string CourseCode {get; set;}
        public string CourseName {get; set;}
        public string CourseDescription {get; set;}
        public int CourseCredits {get; set;}
    }
}
