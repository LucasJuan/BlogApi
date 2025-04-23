using BlogApi.Application;
using BlogApi.Application.Dtos;
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

        /// <summary>
        /// Retrieves all blog posts with their comment count.
        /// </summary>
        /// <returns>A list of blog posts with comment statistics.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _service.GetAllPostsAsync();
            var result = posts.Select(p => new {
                p.Id,
                p.Title,
                CommentCount = p.Comments.Count
            });

            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific blog post by ID, including its comments.
        /// </summary>
        /// <param name="id">The ID of the blog post.</param>
        /// <returns>The blog post with comments or 404 if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _service.GetPostByIdAsync(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Creates a new blog post.
        /// </summary>
        /// <param name="dto">The post data to be created.</param>
        /// <returns>The created post with its generated ID.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] BlogPostCreateDto dto)
        {
            var createdPost = await _service.AddPostAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdPost.Id }, createdPost);
        }

        /// <summary>
        /// Adds a new comment to the specified blog post.
        /// </summary>
        /// <param name="id">The ID of the blog post.</param>
        /// <param name="dto">The comment to be added.</param>
        /// <returns>204 No Content if successful, 404 if post not found.</returns>
        [HttpPost("{id}/comments")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddComment(int id, [FromBody] CommentCreateDto dto)
        {
            var success = await _service.AddCommentAsync(id, dto);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
