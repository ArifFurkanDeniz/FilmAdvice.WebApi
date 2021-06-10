using FilmAdvice.Entities.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FilmAdvice.Entities.Model
{
    public class WebUser : BaseEntity
    {
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        public ICollection<FilmComment> FilmComments { get; set; }

        //https://api.themoviedb.org/3/movie/popular?api_key=c94564e4f1b6647e1572b0ec67156ab9&language=tr-TR&page=1
    }
}
