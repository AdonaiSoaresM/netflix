using Domain.Contracts;

namespace Domain.Entities
{
    public class Movie : EntityBase
    {
        public string Original_title { get; private set; }
        public int Year { get; private set; }
        public string Overview { get; private set; }
        public int Vote_average { get; private set; }

        public Movie(string original_title, int year, string overview, int vote_average)
        {
            Original_title = original_title;
            Year = year;
            Overview = overview;
            Vote_average = vote_average;

            this.AddMovieContract();
        }
    }
}