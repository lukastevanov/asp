using Application.Commands.Orders;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Orders
{
    public class EfEditOrderCommand : IEditOrderCommand
    {
        private readonly ProjContext _context;

        public EfEditOrderCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(OrderDTO request)
        {
            var order = _context.Order.Find(request.Id);
            if (order == null)
            {
                throw new EntityNotFoundException();
            }
            if (order.OrderNumber != request.OrderNumber)
            {
                if (_context.Order.Any(p => p.OrderNumber == request.OrderNumber))
                {
                    throw new EntityAlreadyExistsException();
                }
                order.OrderNumber = request.OrderNumber;

                _context.SaveChanges();
            }
        }
    }
}
      
    
