using FluentValidation;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Validation;

namespace FilmAdvice.Domain.Validation
{
    public class LoginApiRequestValidator : AbstractValidator<LoginApiRequest>
    {
        public LoginApiRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty().WithMessage(ValidationMessage.Required).EmailAddress().WithMessage(ValidationMessage.RequiredEmail);

            RuleFor(m => m.Password)
                .NotEmpty().WithMessage(ValidationMessage.Required);

        }
    }
}
