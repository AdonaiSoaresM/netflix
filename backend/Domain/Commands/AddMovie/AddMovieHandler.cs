using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using prmToolkit.NotificationPattern;

namespace Domain.Commands.AddMovie
{
    public class AddMovieHandler : Notifiable, IRequestHandler<AddMovieRequest, CommandResponse>
    {
        private readonly IRepositoryMovie _repositoryMovie;

        public AddMovieHandler(IRepositoryMovie repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;
        }

        public Task<CommandResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = new Movie(request.Original_title, request.Year, request.Overview, request.Vote_average);

            AddNotifications(movie);

            if (IsInvalid())
            {
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryMovie.Create(movie);
            _repositoryMovie.Commit();

            var response = new AddMovieResponse(movie.Id, "The movie has been successfully added");
            var commandResponse = new CommandResponse(response, this);

            return Task.FromResult(commandResponse);
        }
    }
}