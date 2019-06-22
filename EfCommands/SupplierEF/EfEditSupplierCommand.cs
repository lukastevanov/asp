using Application.Commands.Supplier;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.SupplierEF
{
    public class EfEditSupplierCommand : IEditSupplierCommand
    {
        private readonly ProjContext _context;

        public EfEditSupplierCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(SupplierDTO request)
        {
            var supplier = _context.Supplier.Find(request.Id);
            if (supplier == null)
            {
                throw new EntityNotFoundException();
            }
            if (supplier.Id != request.Id)
            {
                if (_context.Supplier.Any(p => p.Id == request.Id))
                {
                    throw new EntityAlreadyExistsException();
                }
                supplier.Id = request.Id;

                _context.SaveChanges();
            }
        }
    }
}
      
    
