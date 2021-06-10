using System;
using FilmAdvice.Entities.Model;
using FilmAdvice.Business.Interfaces;
using FilmAdvice.Domain.Common;
using FilmAdvice.Repository.Generic;
using FilmAdvice.Repository.UnitOfWork;

namespace LuxuryResume.Business
{
    public abstract class BaseService<T>   where T : IEntity 
    {
        public ResultModel Result;

        public readonly IRepository<T> _repository;
        public readonly IUnitOfWork _unitOfWork;

        protected BaseService(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            Result = new ResultModel { Status = true };
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual T GetById(int id,  Func<IIncludable<T>, IIncludable> includes)
        {
            return _repository.GetById(id, includes);
        }

        public virtual ResultModel Save(T entity, bool commit = true)
        {
            try
            {
                if (entity.Id > 0)
                {
                    _repository.Update(entity);
                }
                else
                {
                    _repository.Save(entity);
                }
                if (commit)
                {
                    Result = _unitOfWork.Commit();
                    if (Result.Status)
                        Result.Id = entity.Id;
                }
            }
            catch (Exception ex)
            {
              //  Logger.Log(ex);
                Result.Status = false;
                Result.Message = ex.Message;
            }

            return Result;
        }
        
    }

}