using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.LoginUser
{
    public class LoginUserResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }

        public LoginUserResponse(string token, string name)
        {
            Token = token;
            Name = name;
        }
    }
}