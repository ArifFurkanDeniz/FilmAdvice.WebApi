using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.ExternalApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmAdvice.ApiClient.Interfaces
{
    public interface IMovieApi
    {
        /// <summary>
        /// Get movies from external api
        /// </summary>
        /// <returns></returns>
        Task<ResultModel<MovieListDto>> GetMoviePopular();
    }
}
