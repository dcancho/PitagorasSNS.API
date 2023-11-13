﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PitagorasSNS.API.SocialNetworkService.Domain.Models
{
    public class Teacher : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("TeacherId")]
        public int TeacherId { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("Password")]
        public string Password { get; set; } = string.Empty;
    }
}