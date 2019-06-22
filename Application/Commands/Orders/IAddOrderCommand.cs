using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Orders
{
    public interface IAddOrderCommand : ICommand<OrderDTO>
    {
    }
}
