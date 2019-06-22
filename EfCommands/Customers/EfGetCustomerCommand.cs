using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.User
{
    public class EfGetUserCommand : IGetUserCommand
    {
        private readonly ProjContext context;

        public EfGetUserCommand(ProjContext context)
        {
            this.context = context;
        }

        public UserDTO Execute(int request)
        {
            var users = context.Users.Find(request);

            if (users == null)
                throw new EntityNotFoundException();

            return new UserDTO
            {
                Userid = users.Userid,
                Username = users.Username,
                Email= users.Email

            };
        }
    }
}
