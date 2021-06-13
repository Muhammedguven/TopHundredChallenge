using System;
using System.Collections.Generic;
using System.Text;

namespace TopHundredChallenge.Models
{

    public class MovieList
    {
        public string ranking { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string trailerPoster { get; set; }
        public string trailerLink { get; set; }
        public string imdbRating { get; set; }
        public string Production { get; set; }
        public string Response { get; set; }
    }

    public class Movies
    {
        public List<MovieList> movie_list { get; set; }
    }


}
