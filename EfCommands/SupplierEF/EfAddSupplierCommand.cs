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
    public class EfAddSupplierCommand : IAddSupplierCommand
    {

        private readonly ProjContext _context;

        public EfAddSupplierCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(SupplierDTO request)
        {

            if (_context.Supplier.Any(p => p.Id == request.Id))
            {
                throw new EntityAlreadyExistsException();
            }

            _context.Supplier.Add(new Supplier
            {
                Id = request.Id,
                CompanyName = request.CompanyName,
                City = request.City
            });
            _context.SaveChanges();
        }

       
    }
}
