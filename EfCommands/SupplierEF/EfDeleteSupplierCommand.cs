using Application.Commands.Supplier;
using Application.Commands.User;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.SupplierEF
{
  public  class EfDeleteSupplierCommand : IDeleteSupplierCommand
    {
        private readonly ProjContext _context;

        public EfDeleteSupplierCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var supplier = _context.Supplier.Find(request);

            if (supplier == null)
                throw new EntityNotFoundException();

            _context.Supplier.Remove(supplier);

            _context.SaveChanges();

        }
    }
}
