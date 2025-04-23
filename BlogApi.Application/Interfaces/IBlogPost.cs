using BlogApi.Application.Dtos;
using BlogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Interfaces
{
    public interface IBlogPost
    {
        Task<List<BlogPost>> GetAllPostsAsync();
        Task<BlogPost?> GetPostByIdAsync(int id);
        Task<BlogPost> AddPostAsync(BlogPostCreateDto dto);
    }
}
