using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FilmAdvice.Repository.Extensions;
using FilmAdvice.Repository.UnitOfWork;
using FilmAdvice.Entities.Model;

namespace FilmAdvice.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        #region Ctor

        private readonly DbSet<T> _dbSet;


        public Repository(IUnitOfWork unitOfWork)
        {
            _dbSet = unitOfWork.GetDbContext().Set<T>();
        }

        #endregion

        public IQueryable<T> Find(Expression<Func<T, bool>> filter = null, Func<IIncludable<T>, IIncludable> includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (includes != null)
                query = query.IncludeMultiple(includes);


            return query;
        }

        public T GetById(int id, Func<IIncludable<T>, IIncludable> includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null)
                query = query.IncludeMultiple(includes);

            return query.FirstOrDefault(e => e.Id == id);
        }

        public void Save(T entity)
        {
            if (entity.Id==0)
            {
                entity.CreatedDate = DateTime.Now;

                if (entity.StatusId==0)
                {
                    entity.StatusId = 1;           
                }
                _dbSet.Add(entity);
            }
            else
            {
                entity.ModifiedDate = DateTime.Now;

                _dbSet.Update(entity);
            }
        
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;

            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
           
            _dbSet.Remove(entity);
         
        }

        public void Delete(T entity)
        {
            // entity.StatusId = 2;
            // entity.ModifiedDate = DateTime.Now;
            // _dbSet.Update(entity);
            _dbSet.Remove(entity);

        }

    }
}
