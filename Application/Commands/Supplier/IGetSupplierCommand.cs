using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Supplier
{
    public class IGetSupplierCommand : ICommand<int, SupplierDTO>
    {
        public SupplierDTO Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
