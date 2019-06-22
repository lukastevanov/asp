using Application.Commands.User;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.UserEF
{
  public  class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ProjContext _context;

        public EfDeleteUserCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var users = _context.Users.Find(request);

            if (users == null)
                throw new EntityNotFoundException();

            _context.Users.Remove(users);

            _context.SaveChanges();

        }
    }
}
