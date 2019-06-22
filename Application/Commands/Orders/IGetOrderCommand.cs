using Application.DTO;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Orders
{
    public interface IGetOrderCommand : ICommand<int, OrderDTO>
    {
    }
}
