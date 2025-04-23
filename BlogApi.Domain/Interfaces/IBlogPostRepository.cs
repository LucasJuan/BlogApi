namespace BlogApi.Domain.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
        Task AddAsync(BlogPost post);
        Task<bool> AddCommentAsync(int postId, Comment comment);
        Task<bool> UpdateAsync(BlogPost post);
    }
}
