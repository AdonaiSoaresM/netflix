using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.AddUser
{
    public class AddUserResponse
    {
        public Guid Guid { get; set; }
        public string Message { get; set; }

        public AddUserResponse(Guid guid, string message)
        {
            Guid = guid;
            Message = message;
        }
    }
}