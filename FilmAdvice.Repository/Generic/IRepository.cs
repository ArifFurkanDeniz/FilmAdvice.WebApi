using System;
using System.Linq;
using System.Linq.Expressions;
using FilmAdvice.Entities.Model;

namespace FilmAdvice.Repository.Generic
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> Find(Expression<Func<T, bool>> filter = null, Func<IIncludable<T>, IIncludable> includes = null);

        T GetById(int id, Func<IIncludable<T>, IIncludable> includes = null);

        void Save(T entity);

        void Update(T entity);

        void Delete(int id);

        void Delete(T entity);
    }
}
