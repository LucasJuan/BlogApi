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
        public Task AddPostAsync(BlogPost post) => _repository.AddAsync(post);
        public Task AddCommentAsync(int postId, Comment comment) => _repository.AddCommentAsync(postId, comment);
    }

}
