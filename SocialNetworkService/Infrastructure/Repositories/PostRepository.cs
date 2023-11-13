using MongoDB.Driver;
using PitagorasSNS.API.Shared.Infrastructure.Configuration;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;

namespace PitagorasSNS.API.Shared.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context, context.Posts)
        {
        }
        public async Task<IEnumerable<Post>> FindPostsByAuthorCodeAsync(string code)
        {
            return await _context.Posts.Find(c => c.AuthorCode == code).ToListAsync();
        }
        public async Task<IEnumerable<Post>> ListTopPostsAsync(int limit = 10)
        {
            // Return most liked posts
            var likedPosts = await _context.Posts.Find(c => c.Likes > 0).ToListAsync();
            likedPosts.Sort((a, b) => b.Likes.CompareTo(a.Likes));
            var topLikedPosts = likedPosts.Take(limit);
            return topLikedPosts;
        
        }
    }
}