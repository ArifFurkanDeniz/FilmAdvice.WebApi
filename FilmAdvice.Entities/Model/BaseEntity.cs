using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FilmAdvice.Entities.Model
{
    public class BaseEntity : IEntity
    {
        //[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int StatusId { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
