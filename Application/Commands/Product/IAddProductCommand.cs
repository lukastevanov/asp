using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IAddProductCommand : ICommand<ProductDTO>
    {
    }
}
