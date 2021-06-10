using System;
namespace FilmAdvice.Domain.Dto
{
    public class UserDto
    {
        public UserDto()
        {
        }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
    }
}
