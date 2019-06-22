using Application.Commands.User;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Customers
{
  public  class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ProjContext context;
        public void Execute(int request)
        {
            var customer = context.Customer.Find(request);

            if (customer == null)
                throw new EntityNotFoundException();

            context.Customer.Remove(customer);

            context.SaveChanges();

        }
    }
}
