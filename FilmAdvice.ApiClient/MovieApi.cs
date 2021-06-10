using FilmAdvice.ApiClient.Interfaces;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.ExternalApi;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FilmAdvice.ApiClient
{
    public class MovieApi : IMovieApi
    {
        HttpClient client;
        readonly string apiKey;
        readonly string language;
        const int filmCount = 100;
        private readonly IConfiguration _config;

        public MovieApi(IConfiguration config)
        {
            _config = config;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/");
            apiKey = _config.GetValue<string>("MovieApi:ApiKey");
            language = _config.GetValue<string>("MovieApi:Language");
        }
        public async Task<ResultModel<MovieListDto>> GetMoviePopular()
        {
            var data = new MovieListDto() { results = new List<Result>() };
            for (int i = 1; i <= filmCount / 20; i++)
            {
                try
                {
                    Log.Logger.Information(string.Format("Api Request:" + client.BaseAddress + "/3/movie/popular?api_key={0}&language={1}&page={2}", apiKey, language, i));

                    var result = await client.GetAsync(string.Format("/3/movie/popular?api_key={0}&language={1}&page={2}", apiKey, language, i));

                    if (!result.IsSuccessStatusCode)
                    {
                        Log.Logger.Error("Film not found");
                        return new ResultModel<MovieListDto>(false, result.StatusCode.ToString());
                    }

                    var contentStream = await result.Content.ReadAsStreamAsync();
                    var filmResult = await JsonSerializer.DeserializeAsync<MovieListDto>(contentStream);
                    data.results.AddRange(filmResult.results);
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message + ex.StackTrace);
                    return new ResultModel<MovieListDto>(false, ex.Message);
                }
            }
          
            return new ResultModel<MovieListDto>(data); 
        }
    }
}
