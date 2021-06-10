using FilmAdvice.Domain.Dto;

namespace FilmAdvice.Domain.Common
{
    public class TokenApiResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expires { get; set; }

        public UserDto UserData { get; set; }
    }
}
