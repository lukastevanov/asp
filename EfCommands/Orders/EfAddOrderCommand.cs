using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using Application.Interface.Orders;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Orders
{
    public class EfAddOrderCommand : IAddOrderCommand
    {

        private readonly ProjContext _context;

        public EfAddOrderCommand(ProjContext context)
        {
            _context = context;
        }

        public void Execute(OrderDTO request)
        {

            if (_context.Order.Any(p => p.OrderNumber == request.OrderNumber))
            {
                throw new EntityAlreadyExistsException();
            }

            _context.Order.Add(new Order
            {
                OrderDate = request.OrderDate,
                OrderNumber = request.OrderNumber,
                CustomerId = request.CustomerId,
                TotalAmount = request.TotalAmount
            });
            _context.SaveChanges();
        }

       
    }
}
