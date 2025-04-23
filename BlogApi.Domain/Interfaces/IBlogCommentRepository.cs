namespace BlogApi.Domain.Interfaces
{
    public interface IBlogCommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<bool> AddCommentAsync(int postId, Comment comment);
    }
}
