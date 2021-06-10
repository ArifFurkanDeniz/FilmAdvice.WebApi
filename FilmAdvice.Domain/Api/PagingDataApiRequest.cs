using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Api
{
    public class PagingDataApiRequest
    {
        public int Page { get; set; }
        public int Pagesize { get; set; }
    }
}
