using BlogApi.Application;
using BlogApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogService _service;

        public PostsController(BlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _service.GetAllPostsAsync();
            return Ok(posts.Select(p => new {
                p.Id,
                p.Title,
                CommentCount = p.Comments.Count
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _service.GetPostByIdAsync(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogPost post)
        {
            await _service.AddPostAsync(post);
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> AddComment(int id, [FromBody] Comment comment)
        {
            await _service.AddCommentAsync(id, comment);
            return NoContent();
        }
    }
}
