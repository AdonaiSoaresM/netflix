using Domain.DTO;
using MediatR;

namespace Domain.Commands.DeleteMovie
{
    public class DeleteMovieRequest : IRequest<CommandResponse>
    {
        public Guid Id { get; set; }

        public DeleteMovieRequest(Guid id)
        {
            Id = id;
        }
    }
}