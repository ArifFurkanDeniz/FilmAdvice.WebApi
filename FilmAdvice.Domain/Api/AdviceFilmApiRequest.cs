using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Api
{
    public class AdviceFilmApiRequest
    {
        public string Email { get; set; }
        public int FilmId { get; set; }
    }
}
