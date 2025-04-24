using BlogApi.Application.Dtos;
using FluentValidation;

namespace BlogApi.Application.Validators
{
    public class CommentCreateDtoValidator : AbstractValidator<BlogCommentCreateDto>
    {
        public CommentCreateDtoValidator()
        {
            RuleFor(c => c.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(50).WithMessage("Author must be at most 50 characters.");

            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MinimumLength(5).WithMessage("Content must be at least 5 characters.");
        }
    }
}
