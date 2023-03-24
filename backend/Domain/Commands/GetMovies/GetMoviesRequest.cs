using Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.GetMovies
{
    public class GetMoviesRequest : IRequest<CommandResponse>
    {
    }
}