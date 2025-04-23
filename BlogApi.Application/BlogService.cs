using BlogApi.Application.Dtos;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;

namespace BlogApi.Application
{
    public class BlogService
    {
        private readonly IBlogPostRepository _repository;

        public BlogService(IBlogPostRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<BlogPost>> GetAllPostsAsync() => _repository.GetAllAsync();

        public Task<BlogPost?> GetPostByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task<BlogPost> AddPostAsync(BlogPostCreateDto dto)
        {
            var post = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                Comments = new List<Comment>()
            };

            await _repository.AddAsync(post);
            return post;
        }

        public async Task<bool> AddCommentAsync(int postId, CommentCreateDto dto)
        {
            var post = await _repository.GetByIdAsync(postId);
            if (post == null)
                return false;

            var comment = new Comment
            {
                Author = dto.Author,
                Content = dto.Content,
                BlogPostId = postId
            };

            return await _repository.AddCommentAsync(postId, comment);
        }
    }

}
