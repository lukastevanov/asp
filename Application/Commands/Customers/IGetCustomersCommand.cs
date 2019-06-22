using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Customers
{
    public interface IGetCustomersCommand : ICommand<CustomerSearch, IEnumerable<CustomerDTO>>
    {

    }
}
