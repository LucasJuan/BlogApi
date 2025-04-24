using BlogApi.Application.Dtos;
using BlogApi.Domain;

namespace BlogApi.Application.Interfaces
{
    public interface IBlogPost
    {
        Task<List<BlogPost>> GetAllPostsAsync();
        Task<BlogPost?> GetPostByIdAsync(int id);
        Task<BlogPost> AddPostAsync(BlogPostCreateDto dto);
    }
}
