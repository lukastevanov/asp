using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Customers;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddCustomerCommand addCustomer;
        private readonly IGetCustomerCommand getCustomer;
        private readonly IEditCustomerCommand editCustomer;
        private readonly IDeleteCustomerCommand deleteCustomer;
        private readonly IGetCustomersCommand getCustomers;

        public CustomerController(ProjContext context, IAddCustomerCommand addCustomer, IGetCustomerCommand getCustomer, IEditCustomerCommand editCustomer, IDeleteCustomerCommand deleteCustomer, IGetCustomersCommand getCustomers)
        {
            this.context = context;
            this.addCustomer = addCustomer;
            this.getCustomer = getCustomer;
            this.editCustomer = editCustomer;
            this.deleteCustomer = deleteCustomer;
            this.getCustomers = getCustomers;
        }





        // GET api/categories
        [HttpGet]
        public IActionResult Get([FromQuery]CustomerSearch query)
        => Ok(getCustomers.Execute(query));

        // GET api/categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDTO = getCustomer.Execute(id);
                return Ok(userDTO);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDTO dto)
        {
            var customer = new Customer
            {
                LastName = dto.LastName
            };

            context.Customer.Add(customer);

            try
            {
                context.SaveChanges();

                return Created("/api/users/" + customer.Id, new CustomerDTO
                {
                    Id = customer.Id,
                    LastName = customer.LastName,
                    FirstName = customer.FirstName
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDTO dto)
        {
            var customer = context.Customer.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

          ///  if (customer.IsDeleted)
          ///  {
          ///      return NotFound();
         ///   }

            if (context.Customer.Any(c => c.Id == dto.Id))
            {
                return Conflict("Takav customer vec postoji.");
            }

            customer.Id = dto.Id;

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
            var user = context.Customer.Find(id);

            if (user == null)
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