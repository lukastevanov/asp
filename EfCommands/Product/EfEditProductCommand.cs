using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditProductCommand : IEditProductCommand
    {
        private readonly ProjContext context;

        public EfEditProductCommand(ProjContext context)
        {
            this.context = context;
        }

        public void Execute(ProductDTO request)
        {
            var product = context.Product.Find(request.Id);
            if (product == null) {
                throw new EntityNotFoundException();
            }
            if (product.ProductName != request.ProductName) {
                if (context.Product.Any(p => p.ProductName == request.ProductName)) {
                    throw new EntityAlreadyExistsException();
                }
                product.ProductName = request.ProductName;

                context.SaveChanges();
            }
        }
    }
}
