using BlogApi.Application;
using BlogApi.Application.Dtos;
using BlogApi.Domain;
using BlogApi.Domain.Interfaces;
using Moq;
using Xunit;
using System.Threading.Tasks;
using BlogApi.Application.Interfaces;

namespace BlogApi.Tests.BlogCommentServiceTests;
public class BlogCommentServiceTests
{
    private readonly Mock<IBlogCommentRepository> _repositoryMock;
    private readonly IBlogComment _service;

    public BlogCommentServiceTests()
    {
        _repositoryMock = new Mock<IBlogCommentRepository>();
        _service = new BlogCommentService(_repositoryMock.Object);
    }

    [Fact]
    public async Task AddCommentAsync_ShouldReturnTrue_WhenCommentIsAdded()
    {
        var dto = new BlogCommentCreateDto { Author = "LucasSodre", Content = "Nice post!" };
        int postId = 1;

        _repositoryMock.Setup(r => r.AddCommentAsync(postId, It.IsAny<Comment>())).ReturnsAsync(true);

        var result = await _service.AddCommentAsync(postId, dto);

        Assert.True(result);
        _repositoryMock.Verify(r => r.AddCommentAsync(postId, It.IsAny<Comment>()), Times.Once);
    }
}
