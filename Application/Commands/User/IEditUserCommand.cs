using Application.DTO;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IEditUserCommand : ICommand<UserDTO>
    {
    }
}
