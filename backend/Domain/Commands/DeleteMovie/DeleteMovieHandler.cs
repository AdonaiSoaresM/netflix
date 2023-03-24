using Domain.DTO;
using Domain.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.DeleteMovie
{
    public class DeleteMovieHandler : Notifiable, IRequestHandler<DeleteMovieRequest, CommandResponse>
    {
        private readonly IRepositoryMovie _repositoryMovie;

        public DeleteMovieHandler(IRepositoryMovie repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;
        }

        public Task<CommandResponse> Handle(DeleteMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = _repositoryMovie.Find(request.Id);

            _repositoryMovie.Delete(movie);
            _repositoryMovie.Commit();

            var response = new DeleteMovieResponse(request.Id, "Movie sucefully deleted.");
            var commandResponse = new CommandResponse(response, this);

            return Task.FromResult(commandResponse);
        }
    }
}