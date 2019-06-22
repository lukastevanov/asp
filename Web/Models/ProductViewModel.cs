using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }

    }
}
