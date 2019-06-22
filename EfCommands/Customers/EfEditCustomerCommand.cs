using Application.Commands.Customers;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Customers
{
    public class EfEditUserCommand : IEditCustomerCommand
    {
        private readonly ProjContext context;

        public EfEditUserCommand(ProjContext context)
        {
            this.context = context;
        }

        public void Execute(CustomerDTO request)
        {
            var customers = context.Customer.Find(request.Id);
            if (customers == null)
            {
                throw new EntityNotFoundException();
            }
            if (customers.Id != request.Id)
            {
                if (context.Customer.Any(p => p.Id == request.Id))
                {
                    throw new EntityAlreadyExistsException();
                }
                customers.LastName = request.LastName;

                context.SaveChanges();
            }
        }
    }
}
      
    
