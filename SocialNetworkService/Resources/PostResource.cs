namespace PitagorasSNS.API.SocialNetworkService.Resources
{
    public class PostResource
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public IEnumerable<string>? AttachedMedia { get; set; }      // ObjectId of the media in MongoDB
        public string Content { get; set; } = string.Empty;
        public string AuthorCode { get; set; } = string.Empty;
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public IEnumerable<string>? Comments { get; set; }
    }
    public class SavePostResource
    {
        public string Title { get; set; } = string.Empty;
        public IEnumerable<string>? AttachedMedia { get; set; }         // ObjectId of the media in MongoDB
        public string Content { get; set; } = string.Empty;
        public string AuthorCode { get; set; } = string.Empty;
    }
}
