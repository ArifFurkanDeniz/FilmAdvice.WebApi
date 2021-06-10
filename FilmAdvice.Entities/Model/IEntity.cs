using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FilmAdvice.Entities.Model
{
    public interface IEntity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        int StatusId { get; set; }

    }
}
