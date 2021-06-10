using System;
using FilmAdvice.Domain.Common;
using FilmAdvice.Repository.Generic;

namespace FilmAdvice.Business.Interfaces
{
    public interface IBaseService<T>
    {
        ResultModel Save(T entity, bool commit = true);
        T GetById(int id);
        T GetById(int id, Func<IIncludable<T>, IIncludable> includes);
    }
}