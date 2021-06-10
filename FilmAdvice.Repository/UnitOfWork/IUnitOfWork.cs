using FilmAdvice.Domain.Common;
using FilmAdvice.Entities;

using System;

namespace FilmAdvice.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ResultModel Commit();

        FilmAdviceDBContext GetDbContext();
    }
}
