using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly ProjContext context;
        public void Execute(int request)
        {
            var product = context.Product.Find(request);

            if (product == null)
                throw new EntityNotFoundException();

            context.Product.Remove(product);

            context.SaveChanges();

        }
    }
}
