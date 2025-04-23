using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        private readonly AppDbContext _context;

        public BlogCommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCommentAsync(int postId, Comment comment)
        {
            var postExists = await _context.BlogPosts.AnyAsync(p => p.Id == postId);
            if (!postExists)
                return false;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllAsync() =>
            await _context.Comments.Include(c => c.BlogPost).ToListAsync();

        public async Task<Comment?> GetByIdAsync(int commentId)
        {
            return await _context.Comments
                                 .Include(c => c.BlogPost)
                                 .FirstOrDefaultAsync(c => c.Id == commentId);
        }


    }
}
