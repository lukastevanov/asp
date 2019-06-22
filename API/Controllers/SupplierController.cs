using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Supplier;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddSupplierCommand addSupplier;
        private readonly IGetSupplierCommand getSupplier;
        private readonly IEditSupplierCommand editSupplier;
        private readonly IDeleteSupplierCommand deleteSupplier;
        private readonly IGetSuppliersCommand getSuppliers;

        public SupplierController(ProjContext context, IAddSupplierCommand addSupplier, IGetSupplierCommand getSupplier, IEditSupplierCommand editSupplier, IDeleteSupplierCommand deleteSupplier, IGetSuppliersCommand getSuppliers)
        {
            this.context = context;
            this.addSupplier = addSupplier;
            this.getSupplier = getSupplier;
            this.editSupplier = editSupplier;
            this.deleteSupplier = deleteSupplier;
            this.getSuppliers = getSuppliers;
        }

        // GET: Order
        public IActionResult Get([FromQuery]SupplierSearch query)
           => Ok(getSuppliers.Execute(query));

        // GET: Order/Details/5
        public IActionResult Get(int id)
        {
            try
            {
                var supplierDTO = getSupplier.Execute(id);
                return Ok(supplierDTO);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] SupplierDTO dto)
        {
            var supplier = new Supplier
            {
                CompanyName = dto.CompanyName
            };

            context.Supplier.Add(supplier);

            try
            {
                context.SaveChanges();

                return Created("/api/users/" + supplier.Id, new SupplierDTO
                {
                    Id = supplier.Id,
                    CompanyName = supplier.CompanyName,
                    ContactName = supplier.ContactName
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierDTO dto)
        {
            var supplier = context.Supplier.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }

            ///  if (customer.IsDeleted)
            ///  {
            ///      return NotFound();
            ///   }

            if (context.Supplier.Any(c => c.Id == dto.Id))
            {
                return Conflict("Takav customer vec postoji.");
            }

            supplier.Id = dto.Id;

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
            var supplier = context.Supplier.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }

            ///  if (user.IsDeleted)
            ///      return Conflict("Customer je obrisan.");

            ///user.IsDeleted = true;


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