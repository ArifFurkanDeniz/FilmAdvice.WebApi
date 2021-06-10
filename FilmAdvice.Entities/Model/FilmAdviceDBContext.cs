using System;
using FilmAdvice.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace FilmAdvice.Entities
{
    public class FilmAdviceDBContext : DbContext
    {
      
            
        public FilmAdviceDBContext(DbContextOptions<FilmAdviceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WebUser> WebUsers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmComment> FilmComments { get; set; }



    }
}
