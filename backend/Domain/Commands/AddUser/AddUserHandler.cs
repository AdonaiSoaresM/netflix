using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using prmToolkit.NotificationPattern;

namespace Domain.Commands.AddUser
{
    public class AddUserHandler : Notifiable, IRequestHandler<AddUserRequest, CommandResponse>
    {
        private readonly IRepositoryUser _repositoryUser;

        public AddUserHandler(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        Task<CommandResponse> IRequestHandler<AddUserRequest, CommandResponse>.Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email, request.Name, request.Password);
            AddNotifications(user);
            if (IsInvalid())
            {
                return Task.FromResult(new CommandResponse(this));
            }

            _repositoryUser.Create(user);
            _repositoryUser.Commit();

            var response = new AddUserResponse(user.Id, "The user has been successfully added");
            var commandResponse = new CommandResponse(response, this);

            return Task.FromResult(commandResponse);
        }
    }
}