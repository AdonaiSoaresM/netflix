using Domain.DTO;
using MediatR;

namespace Domain.Commands.LoginUser
{
    public class LoginUserRequest : IRequest<CommandResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}