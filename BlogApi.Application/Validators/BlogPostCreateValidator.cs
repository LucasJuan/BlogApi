using BlogApi.Application.Dtos;
using FluentValidation;

namespace BlogApi.Application.Validators
{
    public class BlogPostCreateValidator : AbstractValidator<BlogPostCreateDto>
    {
        public BlogPostCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must be at most 100 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MinimumLength(10).WithMessage("Content must be at least 5 characters.");
        }
    }
}
