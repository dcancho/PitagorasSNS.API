namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class ScoresRecordResource
    {
        public string Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public float Score { get; set; }
    }

    public class SaveScoresRecordResource
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public float Score { get; set; }
    }
}
