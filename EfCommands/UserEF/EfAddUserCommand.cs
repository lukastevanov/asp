using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEF
{
    public class EfAddUserCommand : IAddUserCommand
    {

        private readonly ProjContext _context;

       

        public void Execute(UserDTO request)
        {

            if (_context.Users.Any(p => p.Username == request.Username))
            {
                throw new EntityAlreadyExistsException();
            }

            _context.Users.Add(new Users
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            });
            _context.SaveChanges();
        }

       
    }
}
