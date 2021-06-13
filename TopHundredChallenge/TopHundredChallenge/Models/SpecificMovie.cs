using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopHundredChallenge.Models
{
    public class SpecificMovie
    {
        [PrimaryKey]
        public int MovieRank { get; set; }
    }
}
