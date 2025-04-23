using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _context;

        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPost>> GetAllAsync() =>
            await _context.BlogPosts.Include(p => p.Comments).ToListAsync();

        public async Task<BlogPost?> GetByIdAsync(int id) =>
            await _context.BlogPosts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
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
    }

}
