using AutoMapper;
using PitagorasSNS.API.SocialNetworkService.Domain.Models;
using PitagorasSNS.API.SocialNetworkService.Domain.Repositories;
using PitagorasSNS.API.SocialNetworkService.Domain.Services;
using PitagorasSNS.API.SocialNetworkService.Domain.Services.Communication;
using PitagorasSNS.API.SocialNetworkService.Resources;

namespace PitagorasSNS.API.SocialNetworkService.Application.Internal.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostResponse> DeleteAsync(string id)
        {
            var post = await _postRepository.FindByIdAsync(id);
            if (post == null)
            {
                return new PostResponse("Post not found.");
            }
            try
            {
                _postRepository.Remove(post);
                return new PostResponse(_mapper.Map<Post, PostResource>(post));
            }
            catch
            {
                return new PostResponse("An error occurred when deleting the post.");
            }
        }

        public async Task<IEnumerable<PostResource>> ListAllAsync()
        {
            var posts = await _postRepository.ListAsync();
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
        }

        public async Task<IEnumerable<PostResource>> ListByAuthorCodeAsync(string authorCode)
        {
            var posts = await _postRepository.FindPostsByAuthorCodeAsync(authorCode);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        public async Task<IEnumerable<PostResource>> ListTopPostsAsync(int limit = 10)
        {
            var posts = await _postRepository.ListTopPostsAsync(limit);
            var resources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return resources;
        }

        public async Task<PostResponse> SaveAsync(SavePostResource post)
        {
            var postModel = _mapper.Map<SavePostResource, Post>(post);
            try
            {
                await _postRepository.AddAsync(postModel);
                return new PostResponse(_mapper.Map<Post, PostResource>(postModel));
            }
            catch
            {
                return new PostResponse("An error occurred when saving the post.");
            }
        }

        public async Task<PostResponse> UpdateAsync(string id, SavePostResource post)
        {
            var resource = await _postRepository.FindByIdAsync(id);
            if (resource == null)
                return new PostResponse("Post not found.");

            resource.Content = post.Content;

            try
            {
                _postRepository.Update(resource);
                return new PostResponse(_mapper.Map<Post, PostResource>(resource));
            }
            catch
            {
                return new PostResponse("An error occurred when updating the post.");
            }
        }

        public async Task<PostResource> FindByIdAsync(string id)
        {
            var post = await _postRepository.FindByIdAsync(id);
            if (post == null)
            {
                return null;
            }
            return _mapper.Map<Post, PostResource>(post);
        }

        public async Task<PostResponse> AddLikeAsync(string id)
        {
            var post = await _postRepository.FindByIdAsync(id);
            if (post == null)
            {
                return new PostResponse("Post not found.");
            }
            try
            {
                post.Likes++;
                _postRepository.Update(post);
                return new PostResponse(_mapper.Map<Post, PostResource>(post));
            }
            catch
            {
                return new PostResponse("An error occurred when adding the like.");
            }
        }

        public async Task<PostResponse> AddCommentAsync(string id, string comment)
        {
            var post = await _postRepository.FindByIdAsync(id);
            if (post == null)
            {
                return new PostResponse("Post not found.");
            }
            try
            {
                if (post.Comments == null)
                {
                    post.Comments = new List<string> { comment };
                }
                else
                {
                    post.Comments = post.Comments.Append(comment).ToList();
                }

                _postRepository.Update(post);
                return new PostResponse(_mapper.Map<Post, PostResource>(post));
            }
            catch
            {
                return new PostResponse("An error occurred when adding the comment.");
            }
        }
    }
}

