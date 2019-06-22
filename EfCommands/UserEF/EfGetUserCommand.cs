using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.UserEF
{
    public class EfGetUserCommand : IGetUserCommand
    {
        private readonly ProjContext context;

        public EfGetUserCommand(ProjContext context)
        {
            this.context = context;
        }

        public CustomerDTO Execute(int request)
        {
            var customer = context.Customer.Find(request);

            if (customer == null)
                throw new EntityNotFoundException();

            return new CustomerDTO
            {
                Id = customer.Id,
                LastName = customer.LastName,
                FirstName= customer.FirstName

            };
        }
    }
}
