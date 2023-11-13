using Microsoft.AspNetCore.Mvc.Formatters;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Post : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("Title")]
        public string Title { get; set; } = string.Empty;
        [BsonElement("AttachedMedia")]
        public IEnumerable<string>? AttachedMedia { get; set; }         // ObjectId of the media in MongoDB
        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty;
        [BsonElement("AuthorId")]
        public int AuthorId { get; set; }
        [BsonElement("Likes")]
        public int Likes { get; set; }
        [BsonElement("Dislikes")]
        public int Dislikes { get; set; }
        [BsonElement("Comments")]
        public IEnumerable<string>? Comments { get; set; }
    }
}
