using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
