using BlogApi.Application;
using BlogApi.Application.Dtos;
using BlogApi.Application.Interfaces;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Moq;


namespace BlogApi.Tests.BlogPostServiceTests;
public class BlogPostServiceTests
{
    private readonly Mock<IBlogPostRepository> _repositoryMock;
    private readonly IBlogPost _service;

    public BlogPostServiceTests()
    {
        _repositoryMock = new Mock<IBlogPostRepository>();
        _service = new BlogPostService(_repositoryMock.Object, null!);
    }

    [Fact]
    public async Task AddPostAsync_ShouldAddAndReturnPost()
    {
        var dto = new BlogPostCreateDto { Title = "Lucas Test Title", Content = "Test Content" };

        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<BlogPost>())).Returns(Task.CompletedTask);

        var result = await _service.AddPostAsync(dto);

        Assert.Equal(dto.Title, result.Title);
        Assert.Equal(dto.Content, result.Content);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<BlogPost>()), Times.Once);
    }

    [Fact]
    public async Task GetAllPostsAsync_ShouldReturnPosts()
    {
        var posts = new List<BlogPost> { new BlogPost(), new BlogPost() };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(posts);

        var result = await _service.GetAllPostsAsync();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetPostByIdAsync_ShouldReturnPost()
    {
        var post = new BlogPost { Id = 1 };
        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(post);

        var result = await _service.GetPostByIdAsync(1);

        Assert.Equal(1, result?.Id);
    }
}