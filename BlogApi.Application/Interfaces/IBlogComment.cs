using BlogApi.Application.Dtos;

namespace BlogApi.Application.Interfaces
{
    public interface IBlogComment
    {
        Task<bool> AddCommentAsync(int postId, BlogCommentCreateDto dto);
    }
}
