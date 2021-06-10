
namespace FilmAdvice.Domain.Api
{
    public class BaseLoginApiRequest
    {
        public string Email { get; set; }
        
    }
    public class LoginApiRequest : BaseLoginApiRequest
         {
             public string Password { get; set; }
         }
    

}
