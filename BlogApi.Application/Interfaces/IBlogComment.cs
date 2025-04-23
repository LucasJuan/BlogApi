using BlogApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Interfaces
{
    public interface IBlogComment
    {
        Task<bool> AddCommentAsync(int postId, BlogCommentCreateDto dto);
    }
}
