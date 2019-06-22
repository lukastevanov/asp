using Application.DTO;
using Application.Interface;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetProductsCommand : ICommand<ProductSearch, IEnumerable<ProductDTO>>
    {
     
    }
}
