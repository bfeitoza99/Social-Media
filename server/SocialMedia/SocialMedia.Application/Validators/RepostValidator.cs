using FluentValidation;
using SocialMedia.Application.DTO;

namespace SocialMedia.Application.Validators
{
    internal class RepostValidator : AbstractValidator<CreateRepostDTO>
    {
        public RepostValidator()
        {   
            RuleFor(p => p.AuthorUserId)
               .NotEmpty().WithMessage("AuthorUserId  is required.");
        }
    }
}
