using System.Collections.Generic;
using System.Security.Claims;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;

namespace FilmAdvice.Core.Security
{
    public interface ITokenService
    {
        TokenApiResponse GenerateToken(UserDto userDto);

        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
