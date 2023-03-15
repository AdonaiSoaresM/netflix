﻿using Domain.DTO;
using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.LoginUser
{
    public class LoginUserHandler : Notifiable, IRequestHandler<LoginUserRequest, CommandResponse>
    {
        public Task<CommandResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}