using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class ScoresRecord : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("StudentId")]
        public string StudentId { get; set; } = string.Empty;

        [BsonElement("StudentCode")]
        public string StudentCode { get; set; } = string.Empty;

        [BsonElement("ClassId")]
        public string ClassId { get; set; } = string.Empty;

        [BsonElement("ClassCode")]
        public string ClassCode { get; set; } = string.Empty;

        [BsonElement("CourseId")]
        public string CourseId { get; set; } = string.Empty;

        [BsonElement("CourseCode")]
        public string CourseCode { get; set; } = string.Empty;

        [BsonElement("Score")]
        public float Score { get; set; }
    }
}
