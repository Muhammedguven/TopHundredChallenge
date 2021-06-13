using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Models;
using TopHundredChallenge.Services.Abstract;

namespace TopHundredChallenge.Services.Manager
{
    public class ImdbManager
    {
        private IImdbService _service;

        public ImdbManager(IImdbService service)
        {
            _service = service;
        }

        public Task<Movies> GetTopHundredMoviesAsync()
        {
            return _service.GetTopHundredMoviesAsync();
        }
    }
}
