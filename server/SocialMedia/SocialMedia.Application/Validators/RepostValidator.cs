using FluentValidation;
using SocialMedia.Domain.DTO;


namespace SocialMedia.Application.Validators
{
    internal class RepostValidator : AbstractValidator<RepostDTO>
    {
        public RepostValidator()
        {   
            RuleFor(p => p.AuthorNickname)
                .NotEmpty().WithMessage("Author nickname is required.");

            RuleFor(p => p.AuthorUserId)
               .NotEmpty().WithMessage("Author nickname is required.");
        }
    }
}
