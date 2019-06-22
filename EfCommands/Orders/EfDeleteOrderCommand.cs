using Application.Commands.Orders;
using Application.Commands.User;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Orders
{
  public  class EfDeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly ProjContext _context;

        public EfDeleteOrderCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var order = _context.Order.Find(request);

            if (order == null)
                throw new EntityNotFoundException();

            _context.Order.Remove(order);

            _context.SaveChanges();

        }
    }
}
