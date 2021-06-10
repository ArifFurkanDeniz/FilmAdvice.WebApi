using FilmAdvice.Domain.Api;
using FluentValidation;
using FilmAdvice.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Validation
{
    public class AddCommentApiRequestValidator : AbstractValidator<AddCommentApiRequest>
    {
        public AddCommentApiRequestValidator()
        {
            RuleFor(m => m.Text)
              .NotEmpty().WithMessage(ValidationMessage.Required);

            RuleFor(m => m.Score)
            .Must(x => x > 0 && x < 11).WithMessage(ValidationMessage.MinLength(1)).WithMessage(ValidationMessage.MaxLength(10));
        }
    }
}
