using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Name must be 3 characters")]
        public string ProductName { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public string Package { get; set; }
        [Required]
        public bool IsDiscontinued
        {
            get; set;
        }
    }
}
