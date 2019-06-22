using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public class IGetUserCommand : ICommand<int, UserDTO>
    {
        public UserDTO Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
