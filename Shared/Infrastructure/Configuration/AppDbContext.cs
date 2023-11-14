using MongoDB.Driver;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;

namespace PitagorasSNS.API.Shared.Infrastructure.Configuration
{
    /// <summary>
    /// Represents the MongoDB context for the application.
    /// </summary>
    public class AppDbContext
    {
        private readonly IMongoDatabase _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The MongoDB connection string.</param>
        /// <param name="databaseName">The name of the database.</param>
        public AppDbContext(IMongoClient mongoClient, string databaseName)
        {
            var client = mongoClient;
            _db = client.GetDatabase(databaseName);
        }

        /// <summary>
        /// Gets the collection of Courses.
        /// </summary>
        public IMongoCollection<Course> Courses => _db.GetCollection<Course>("Courses");

        /// <summary>
        /// Gets the collection of Classes.
        /// </summary>
        public IMongoCollection<Class> Classes => _db.GetCollection<Class>("Classes");

        /// <summary>
        /// Gets the collection of ScoresRecords.
        /// </summary>
        public IMongoCollection<ScoresRecord> ScoresRecords => _db.GetCollection<ScoresRecord>("ScoresRecords");

        /// <summary>
        /// Gets the collection of Students.
        /// </summary>
        public IMongoCollection<Student> Students => _db.GetCollection<Student>("Students");

        /// <summary>
        /// Gets the collection of Teachers.
        /// </summary>
        public IMongoCollection<Teacher> Teachers => _db.GetCollection<Teacher>("Teachers");

        /// <summary>
        /// Gets the collection of Posts.
        /// </summary>
        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Posts");
    }
}