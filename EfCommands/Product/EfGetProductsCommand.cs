using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetProductCommand : IGetProductsCommand
    {
        private readonly ProjContext _context;

        public EfGetProductCommand(ProjContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDTO> Execute(ProductSearch request)
        {
            var query = _context.Product.AsQueryable();

            return query.Select(p => new ProductDTO {
                ProductName=p.ProductName,
                SupplierId = p.SupplierId,
                UnitPrice = Convert.ToInt32(p.UnitPrice),
                Package = p.Package,
                IsDiscontinued = p.IsDiscontinued
            });


              
        }

      
    }
}
