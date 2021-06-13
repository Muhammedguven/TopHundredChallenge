using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Models;
using TopHundredChallenge.Services.Abstract;

namespace TopHundredChallenge.Services.Concrete
{
    public class ImdbService:IImdbService
    {
        string URL = "https://raw.githubusercontent.com/naim-lasker/imdb-top-100-movies/master/data/movies.json";
        HttpClient client;

        public ImdbService()
        {
            client = new HttpClient();
        }
        public async Task<Movies> GetTopHundredMoviesAsync()
        {
            var result = await client.GetStringAsync(URL);
            var movies = JsonConvert.DeserializeObject<Movies>(result);
            return movies;
        }

    }
}
