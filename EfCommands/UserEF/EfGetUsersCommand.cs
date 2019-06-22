using Application.Commands.Customers;
using Application.Commands.User;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserEF
{
    public class EfGetUsersCommand : IGetCustomersCommand
    {

        private ProjContext context;

        public EfGetUsersCommand(ProjContext context)
        {
            this.context = context;
        }

        public IEnumerable<CustomerDTO> Execute(CustomerSearch request)
        {
            var query = context.Customer.AsQueryable();

            return query.Select(p => new CustomerDTO
            {
                FirstName = request.FirstName,
                LastName = request.Lastname

            });



        }
    }
}
