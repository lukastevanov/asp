using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserSearch, IEnumerable<UserDTO>>
    {

    }
}
