using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.GetMovies
{
    public class GetMoviesResponse
    {
        public Guid Id { get; set; }
        public string Original_title { get; set; }
        public int Year { get; set; }
        public string Overview { get; set; }
        public int Vote_average { get; set; }

        public GetMoviesResponse(Guid id, string original_title, int year, string overview, int vote_average)
        {
            Id = id;
            Original_title = original_title;
            Year = year;
            Overview = overview;
            Vote_average = vote_average;
        }
    }
}