using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure;
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

}
