using BlogApi.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Validators
{
    public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
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
