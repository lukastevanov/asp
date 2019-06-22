
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
    public class EfAddCustomerCommand : IAddCustomerCommand
    {

        private readonly ProjContext _context;

        public EfAddCustomerCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(CustomerDTO request)
        {

            if (_context.Customer.Any(p => p.Id == request.Id))
            {
                throw new EntityAlreadyExistsException();
            }
            
            _context.Customer.Add(new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                City = request.City,
                Country=request.Phone
            });
            _context.SaveChanges();
        }

       
    }
}
