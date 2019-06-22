using Application.DTO;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Customers
{
   public interface IAddCustomerCommand : ICommand<CustomerDTO>
    {
    }
}
