using Microsoft.AspNetCore.Mvc.Formatters;


namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Post : IEntity
    {

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public IEnumerable<string>? AttachedMedia { get; set; }         // ObjectId of the media in MongoDB
        public string Content { get; set; } = string.Empty;
        public string AuthorCode { get; set; } = string.Empty;
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public IEnumerable<string>? Comments { get; set; }
    }
}
