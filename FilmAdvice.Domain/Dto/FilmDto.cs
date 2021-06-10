using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public string FilmInfo { get; set; }
        public string ReleaseDate { get; set; }
        public List<FilmCommentDto> FilmComments { get; set; }
        public int AvaragePoint { get; set; }
    }
}
