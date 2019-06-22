using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Orders
{
    public interface IGetOrdersCommand : ICommand<OrderSearch, IEnumerable<OrderDTO>>
    {
     
    }
}
