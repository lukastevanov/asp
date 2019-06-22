using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Interface;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddProductCommand _addProduct;
      private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductCommand _getProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IDeleteProductCommand _deleteProduct;

        public ProductController(IGetProductsCommand getProducts,ProjContext context, IAddProductCommand addProduct, IGetProductCommand getProduct, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct)
        {
            this.context = context;
            _addProduct = addProduct;
             _getProducts = getProducts;
            _getProduct = getProduct;
            _editProduct = editProduct;
            _deleteProduct = deleteProduct;
        }


        // GET api/categories
        [HttpGet]
   public IActionResult Get([FromQuery]ProductSearch query)
        => Ok(_getProducts.Execute(query));

    // GET api/categories/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var productDTO = _getProduct.Execute(id);
            return Ok(productDTO);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody] ProductDTO dto)
    {
        var produkt = new Product
        {
            ProductName = dto.ProductName
        };

        context.Product.Add(produkt);

        try
        {
                context.SaveChanges();

            return Created("/api/products/" + produkt.Id, new ProductDTO
            {
                Id = produkt.Id,
                ProductName = produkt.ProductName
            });
        }
        catch
        {
            return StatusCode(500, "An error has occured.");
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductDTO dto)
    {
        var product = context.Product.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        if (product.IsDeleted)
        {
            return NotFound();
        }

        if (context.Product.Any(c => c.ProductName == dto.ProductName))
        {
            return Conflict("Produkt sa tim imenom vec postoji.");
        }

            product.ProductName = dto.ProductName;

        try
        {
                context.SaveChanges();
            return NoContent();
        }
        catch (Exception)
        {

            return StatusCode(500, "An error has occured.");
        }
    }

    // DELETE api/categories/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = context.Product.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        if (product.IsDeleted)
            return Conflict("Produkt je vec obrisan.");

            product.IsDeleted = true;


        try
        {
                context.SaveChanges();
            return NoContent();
        }
        catch (Exception)
        {

            return StatusCode(500);
        }
    }
}
}