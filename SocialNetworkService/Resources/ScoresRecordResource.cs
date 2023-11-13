namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class ScoresRecordResource
    {
        public string Id { get; set; }
        public string StudentCode { get; set; }
        public string CourseCode { get; set; }
        public string ClassCode { get; set; }
        public float Score { get; set; }
    }

    public class SaveScoresRecordResource
    {
        public string StudentCode { get; set; }
        public string ClassCode { get; set; }
        public string CourseCode { get; set; }
        public float Score { get; set; }
    }
}
