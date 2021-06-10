using FilmAdvice.Business.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmAdvice.Batch.Jobs
{
    [DisallowConcurrentExecution]
    public class FilmPullJob : IJob
    {
        IFilmService filmService;
        public FilmPullJob(IFilmService _filmService)
        {
            filmService = _filmService;
        }

        public  Task Execute(IJobExecutionContext context)
        {
            filmService.FilmPull().GetAwaiter().GetResult();
            return  Task.CompletedTask;
        }
    }
}
