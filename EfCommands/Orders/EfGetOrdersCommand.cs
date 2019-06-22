using Application.Commands.Customers;
using Application.Commands.Orders;
using Application.Commands.User;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Orders
{
    public class EfGetOrdersCommand : IGetOrderCommand
    {

        private readonly ProjContext context;

        public EfGetOrdersCommand(ProjContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDTO> Execute(OrderSearch request)
        {
            var query = context.Order.AsQueryable();

            return query.Select(p => new OrderDTO
            {
                Id = request.Id,
                OrderNumber = request.OrderNumber

            });



        }

        public OrderDTO Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
