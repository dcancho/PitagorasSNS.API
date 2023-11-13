using MongoDB.Bson.Serialization.Attributes;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Course : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("CourseCode")]
        public string CourseCode { get; set; } = string.Empty;
        [BsonElement("CourseName")]
        public string CourseName { get; set; } = string.Empty;
        [BsonElement("CourseDescription")]
        public string CourseDescription { get; set; } = string.Empty;
        [BsonElement("CourseCredits")]
        public int CourseCredits { get; set; }
    }
}