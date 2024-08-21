using Domain.DTO;
using Domain.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;

namespace Domain.Commands.GetMovies
{
    public class GetMoviesHandler : Notifiable, IRequestHandler<GetMoviesRequest, CommandResponse>
    {
        private readonly IRepositoryMovie _repositoryMovie;

        public GetMoviesHandler(IRepositoryMovie repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;
        }

        public Task<CommandResponse> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies = _repositoryMovie.List();

            var response = movies.Select(movie =>
            {
                return new GetMoviesResponse(movie.Id, movie.Original_title, movie.Year, movie.Overview, movie.Vote_average);
            });

            var commandResponse = new CommandResponse(response, this);

            return Task.FromResult(commandResponse);
        }
    }
}