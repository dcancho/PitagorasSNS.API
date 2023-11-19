
using Microsoft.AspNetCore.Mvc;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/v1/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResource>>> Get()
        {
            var posts = await _postService.ListAllAsync();
            return Ok(posts);
        }

        // GET: api/v1/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostResource>> Get(string id)
        {
            var postResource = await _postService.FindByIdAsync(id);
            return Ok(postResource);
        }

        // PUT api/v1/Post/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PostResponse>> Put(string id, [FromBody] SavePostResource value)
        {
            var response = await _postService.UpdateAsync(id, value);
            return Ok(response);
        }

        // PUT api/v1/Post/5/like
        [HttpPut("{id}/like")]
        public async Task<ActionResult<PostResponse>> PutLike(string id)
        {
            var response = await _postService.AddLikeAsync(id);
            return Ok(response);
        }

        // PUT api/v1/Post/5/comment
        [HttpPut("{id}/comment")]
        public async Task<ActionResult<PostResponse>> PutComment(string id, [FromBody] string comment)
        {
            var response = await _postService.AddCommentAsync(id, comment);
            return Ok(response);
        }

        // POST: api/v1/Post
        [HttpPost]
        public async Task<ActionResult<PostResponse>> Post([FromBody] SavePostResource value)
        {
            var response = await _postService.SaveAsync(value);
            return Ok(response);
        }

        // DELETE: api/v1/Post/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassResponse>> Delete(string id)
        {
            var response = await _postService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
