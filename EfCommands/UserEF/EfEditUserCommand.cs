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
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly ProjContext _context;

        public EfEditUserCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(UserDTO request)
        {
            var users = _context.Users.Find(request.Userid);
            if (users == null)
            {
                throw new EntityNotFoundException();
            }
            if (users.Username != request.Username)
            {
                if (_context.Users.Any(p => p.Username == request.Username))
                {
                    throw new EntityAlreadyExistsException();
                }
                users.Username = request.Username;

                _context.SaveChanges();
            }
        }
    }
}
      
    
