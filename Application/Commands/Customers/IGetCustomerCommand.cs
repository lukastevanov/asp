using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Customers
{
    public class IGetCustomerCommand : ICommand<int, CustomerDTO>
    {
        public CustomerDTO Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
