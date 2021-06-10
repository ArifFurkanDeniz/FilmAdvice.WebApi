using System;
using FilmAdvice.Domain.Common;
using FilmAdvice.Entities;

namespace FilmAdvice.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly FilmAdviceDBContext _dbContext;

        public UnitOfWork(FilmAdviceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResultModel Commit()
        {
            var resultModel = new ResultModel();

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                resultModel.Status = false;
                if (ex.InnerException != null) resultModel.Message = ex.Message + ex.InnerException.Message;
                else resultModel.Message = ex.Message;
            }

            return resultModel;
        }

        public FilmAdviceDBContext GetDbContext()
        {
            return _dbContext;
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
