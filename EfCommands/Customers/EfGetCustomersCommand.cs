using Application.Commands.User;
using Application.DTO;
using Application.Interface;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.User
{
    public class EfGetUsersCommand : IGetUsersCommand
    {
        private readonly ProjContext _context;

        public EfGetUsersCommand(ProjContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDTO> Execute(UserSearch request)
        {
            var query = _context.Users.AsQueryable();

            return query.Select(p => new UserDTO
            {
                Username = request.Username,
                Email = request.Email

            });



        }

        IEnumerable<UserDTO> ICommand<UserSearch, IEnumerable<UserDTO>>.Execute(UserSearch request)
        {
            throw new NotImplementedException();
        }
    }
}
