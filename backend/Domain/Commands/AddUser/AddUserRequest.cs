using Domain.DTO;
using MediatR;

namespace Domain.Commands.AddUser
{
    public class AddUserRequest : IRequest<CommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}