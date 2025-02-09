using FluentValidation;
using SocialMedia.Domain.DTO;

namespace SocialMedia.Application.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDTO>
    {
        public CreatePostValidator()
        {

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(777).WithMessage("Content cannot exceed 777 characters.");

            RuleFor(p => p.AuthorNickname)
                .NotEmpty().WithMessage("Author nickname is required.");

            RuleFor(p => p.AuthorUserId)
               .NotEmpty().WithMessage("Author nickname is required.");
        }
    }
}
