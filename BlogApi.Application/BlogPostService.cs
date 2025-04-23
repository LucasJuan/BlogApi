using BlogApi.Application.Dtos;
using BlogApi.Application.Interfaces;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Serilog;
namespace BlogApi.Application
{
    public class BlogPostService : IBlogPost
    {
        private readonly IBlogPostRepository _repository;

        public BlogPostService(IBlogPostRepository repository, ILogger logger)
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
                    Content = dto.Content
                };

                await _repository.AddAsync(post);
                return post;
        }
       
    }
}
