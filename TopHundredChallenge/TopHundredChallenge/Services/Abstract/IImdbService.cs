using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Models;

namespace TopHundredChallenge.Services.Abstract
{
    public interface IImdbService
    {
        Task<Movies> GetTopHundredMoviesAsync();
    }
}
