using FilmAdvice.Domain.Api;
using FluentValidation;
using FilmAdvice.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Validation
{
    public class AdviceFilmApiRequestValidator : AbstractValidator<AdviceFilmApiRequest>
    {
        public AdviceFilmApiRequestValidator()
        {
            RuleFor(m => m.Email)
               .NotEmpty().WithMessage(ValidationMessage.Required).EmailAddress().WithMessage(ValidationMessage.RequiredEmail);
        }
    }
}
