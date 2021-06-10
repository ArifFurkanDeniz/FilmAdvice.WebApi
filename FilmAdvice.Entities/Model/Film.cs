using FilmAdvice.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FilmAdvice.Entities.Model
{
    public class Film : BaseEntity
    {
        [MaxLength(500)]
        public string FilmName { get; set; }
        public string FilmInfo { get; set; }

        public int FilmApiId { get; set; }

        [MaxLength(10)]
        public string ReleaseDate { get; set; }
        public ICollection<FilmComment> FilmComments { get; set; }
    }
}
