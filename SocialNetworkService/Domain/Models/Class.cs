using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Class : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("ClassCode")]
        public string ClassCode { get; set; } = string.Empty;
        [BsonElement("TeacherId")]
        public string TeacherId { get; set; } = string.Empty;
        [BsonElement("TeacherCode")]
        public string TeacherCode { get; set; } = string.Empty;
        [BsonElement("StudentsEnrolledId")]
        public IEnumerable<string> StudentsEnrolledId { get; set; } = new List<string>();
        [BsonElement("StudentsEnrolledCode")]
        public IEnumerable<string> StudentsEnrolledCode { get; set; } = new List<string>();
        [BsonElement("CourseId")]
        public string CourseId { get; set; } = string.Empty;
        [BsonElement("CourseCode")]
        public string CourseCode { get; set; } = string.Empty;
        [BsonElement("AverageClassScore")]
        public float AverageClassScore { get; set; }
    }
}