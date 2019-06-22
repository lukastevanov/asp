using Application.Commands.Supplier;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.SupplierEF
{
    public class EfGetSupplierCommand : IGetSupplierCommand
    {
        private readonly ProjContext context;

        public EfGetSupplierCommand(ProjContext context)
        {
            this.context = context;
        }

        public SupplierDTO Execute(int request)
        {
            var supplier = context.Supplier.Find(request);

            if (supplier == null)
                throw new EntityNotFoundException();

            return new SupplierDTO
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName,
                ContactTitle= supplier.ContactTitle

            };
        }
    }
}
