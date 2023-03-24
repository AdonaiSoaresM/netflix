using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Domain.Commands.AddMovie
{
    public class AddMovieRequest : IRequest<CommandResponse>
    {
        public string Original_title { get; set; }
        public int Year { get; set; }
        public string Overview { get; set; }
        public int Vote_average { get; set; }
        public IFormFileCollection Files { get; set; }

        public AddMovieRequest(string original_title, int year, string overview, int vote_average, IFormFileCollection files)
        {
            Original_title = original_title;
            Year = year;
            Overview = overview;
            Vote_average = vote_average;
            Files = files;
        }

        public AddMovieRequest(IFormCollection formColletion)
        {
            Original_title = formColletion["original_title"].FirstOrDefault();
            Year = Convert.ToInt32(formColletion["year"].FirstOrDefault());
            Overview = formColletion["overview"].FirstOrDefault();
            Vote_average = Convert.ToInt32(formColletion["vote_average"].FirstOrDefault());
            Files = formColletion.Files;
        }
    }
}