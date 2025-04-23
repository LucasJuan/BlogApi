namespace BlogApi.Domain.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
        Task AddAsync(BlogPost post);
        Task AddCommentAsync(int postId, Comment comment);
    }

}
