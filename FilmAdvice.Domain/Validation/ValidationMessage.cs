
namespace FilmAdvice.Domain.Validation
{
    public class ValidationMessage
    {
        public const string Required = "This field is required";
        public const string RequiredEmail = "Email address is not correct";
        public const string RequiredDate = "Date format error";
        public const string RequiredPhone = "Phone format error";

        public static string MaxLength(int length)
        {
            return $"This must be maximum {length} char";
        }

        public static string MinLength(int length)
        {
            return $"This must be minimum {length} char";
        }

        public static string GreaterThan(int value)
        {
            return $"Value must be bigger than {value} ";
        }

        public static string GreaterThan(string value)
        {
            return $"Value must be bigger than {value}";
        }
    }
}
