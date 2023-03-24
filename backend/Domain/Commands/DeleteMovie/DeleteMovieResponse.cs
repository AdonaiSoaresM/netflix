using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.DeleteMovie
{
    public class DeleteMovieResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public DeleteMovieResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}