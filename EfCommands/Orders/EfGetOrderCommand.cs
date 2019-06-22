using Application.Commands.Orders;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Orders
{
    public class EfGetOrderCommand : IGetOrderCommand
    {
        private readonly ProjContext context;

        public EfGetOrderCommand(ProjContext context)
        {
            this.context = context;
        }

        public OrderDTO Execute(int request)
        {
            var order = context.Order.Find(request);

            if (order == null)
                throw new EntityNotFoundException();

            return new OrderDTO
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate= order.OrderDate

            };
        }
    }
}
