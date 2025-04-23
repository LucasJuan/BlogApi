using BlogApi.Application.Dtos;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Serilog;
namespace BlogApi.Application
{
    public class BlogService
    {
        private readonly ILogger _logger;
        private readonly IBlogPostRepository _repository;

        public BlogService(IBlogPostRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<List<BlogPost>> GetAllPostsAsync() => _repository.GetAllAsync();

        public Task<BlogPost?> GetPostByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<BlogPost> AddPostAsync(BlogPostCreateDto dto)
        {
            try
            {
                var post = new BlogPost
                {
                    Title = dto.Title,
                    Content = dto.Content
                };

                await _repository.AddAsync(post);
                return post;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to add blog post.");
                throw;
            }
        }

        public async Task<bool> AddCommentAsync(int postId, CommentCreateDto dto)
        {
            try
            {
                var comment = new Comment
                {
                    Content = dto.Content,
                    Author = dto.Author,
                    BlogPostId = postId
                };

                return await _repository.AddCommentAsync(postId, comment);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to add comment to post with ID {PostId}", postId);
                throw;
            }
        }
    }
}
