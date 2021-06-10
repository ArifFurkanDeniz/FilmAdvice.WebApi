using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Api
{
    public class AddCommentApiRequest
    {
        public int FilmId { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
    }
}
