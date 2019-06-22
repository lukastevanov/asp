using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetProducttCommand : IGetProductCommand
    {
        private readonly ProjContext context;

        public EfGetProducttCommand(ProjContext context)
        {
            this.context = context;
        }

        public ProductDTO Execute(int request)
        {
            var produkt = context.Product.Find(request);

            if (produkt == null)
                throw new EntityNotFoundException();

            return new ProductDTO
            {
                Id = produkt.Id,
                ProductName = produkt.ProductName
            };
        }
    }
}
