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
        public int StudentId { get; set; }

        [BsonElement("ClassId")]
        public int ClassId { get; set; }

        [BsonElement("Score")]
        public float Score { get; set; }

        public ScoresRecord(string Id, int StudentId, int ClassId, float Score)
        {
            this.Id = Id;
            this.StudentId = StudentId;
            this.ClassId = ClassId;
            this.Score = Score;
        }

        public ScoresRecord() : this(string.Empty, 0, 0, 0) { }

        public ScoresRecord(int StudentId, int ClassId, float Score) : this(string.Empty, StudentId, ClassId, Score) { }

        public ScoresRecord(string Id, int StudentId, int ClassId) : this(Id, StudentId, ClassId, 0) { }
    }
}
