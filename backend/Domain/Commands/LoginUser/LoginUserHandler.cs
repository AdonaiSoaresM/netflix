using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using prmToolkit.NotificationPattern;
using System.ComponentModel;

namespace Domain.Commands.LoginUser
{
    public class LoginUserHandler : Notifiable, IRequestHandler<LoginUserRequest, CommandResponse>
    {
        private readonly IJWTService _jWTService;
        private readonly IRepositoryUser _repositoryUser;

        public LoginUserHandler(IRepositoryUser repositoryUser, IJWTService jWTService)
        {
            _jWTService = jWTService;
            _repositoryUser = repositoryUser;
        }

        public Task<CommandResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = _repositoryUser.FindByEmail(request.Email);

            if (user == null)
            {
                AddNotification("User", "Login failed, please try again.");
                return Task.FromResult(new CommandResponse(this));
            }

            var passwordHasher = new PasswordHasher<User>();
            var ResultCheckPassword = passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (ResultCheckPassword == 0)
            {
                AddNotification("User", "Login failed, please try again.");
                return Task.FromResult(new CommandResponse(this));
            }

            var token = _jWTService.GenerateToken(user);

            var response = new LoginUserResponse(token, user.Name);
            var commandResponse = new CommandResponse(response, this);

            return Task.FromResult(commandResponse);
        }
    }
}