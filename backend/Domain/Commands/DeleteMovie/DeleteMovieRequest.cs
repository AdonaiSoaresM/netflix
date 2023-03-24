using Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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