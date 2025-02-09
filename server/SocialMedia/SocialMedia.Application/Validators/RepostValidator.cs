using FluentValidation;
using SocialMedia.Domain.DTO;


namespace SocialMedia.Application.Validators
{
    internal class RepostValidator : AbstractValidator<CreateRepostDTO>
    {
        public RepostValidator()
        {   
            RuleFor(p => p.AuthorUserId)
               .NotEmpty().WithMessage("Author nickname is required.");
        }
    }
}
