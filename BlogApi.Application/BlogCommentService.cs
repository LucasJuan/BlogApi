using BlogApi.Application.Dtos;
using BlogApi.Application.Interfaces;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;

namespace BlogApi.Application
{
    public class BlogCommentService : IBlogComment
    {
        private readonly IBlogCommentRepository _repository;

        public BlogCommentService(IBlogCommentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> AddCommentAsync(int postId, BlogCommentCreateDto dto)
        {

                var comment = new Comment
                {
                    Content = dto.Content,
                    Author = dto.Author,
                    BlogPostId = postId
                };

                return await _repository.AddCommentAsync(postId, comment);
        }
    }
}
