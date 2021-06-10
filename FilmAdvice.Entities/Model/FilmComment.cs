
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Entities.Model
{
    public class FilmComment : BaseEntity
    {
        public string Text { get; set; }
        public int Score { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public WebUser User { get; set; }
        public int UserId { get; set; }
    }
}
