using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FilmAdvice.Domain.Api;

namespace FilmAdvice.Domain.Error
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState) : base(Response<ValidationError>.ValidError(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
