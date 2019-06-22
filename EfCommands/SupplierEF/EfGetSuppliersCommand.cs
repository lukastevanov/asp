using Application.Commands.Customers;
using Application.Commands.Supplier;
using Application.Commands.User;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SupplierEF
{
    public class EfGetSuppliersCommand : IGetSuppliersCommand
    {

        private ProjContext context;

        public EfGetSuppliersCommand(ProjContext context)
        {
            this.context = context;
        }

        public IEnumerable<SupplierDTO> Execute(SupplierSearch request)
        {
            var query = context.Supplier.AsQueryable();

            return query.Select(p => new SupplierDTO
            {
                CompanyName = request.CompanyName,
                ContactName = request.ContactName

            });



        }
    }
}
