using Application.DTO;
using Application.Exceptions;
using Application.Interface;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddProductCommand :IAddProductCommand
    {

        private readonly ProjContext _context;

        public EfAddProductCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(ProductDTO request) {

            if (_context.Product.Any(p => p.ProductName == request.ProductName)) {
                throw new EntityAlreadyExistsException();
            }

            _context.Product.Add(new Product {
                ProductName=request.ProductName,
                SupplierId = request.SupplierId,
                UnitPrice = request.UnitPrice,
                Package = request.Package,
                IsDiscontinued = request.IsDiscontinued
            });
            _context.SaveChanges();
        }

      
    }
}
