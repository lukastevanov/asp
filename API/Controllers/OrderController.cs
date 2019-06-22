using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Orders;
using Application.DTO;
using Application.Exceptions;
using Application.Interface.Orders;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddOrderCommand addOrder;
        private readonly IGetOrderCommand getOrder;
        private readonly IEditOrderCommand editOrder;
        private readonly IDeleteOrderCommand deleteOrder;
        private readonly IGetOrdersCommand getOrders;

        

        // GET: Order
        public IActionResult Get([FromQuery]OrderSearch query)
           => Ok(getOrders.Execute(query));

        // GET: Order/Details/5
        public IActionResult Get(int id)
        {
            try
            {
                var orderDTO = getOrder.Execute(id);
                return Ok(orderDTO);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDTO dto)
        {
            var order = new Order
            {
                OrderNumber = dto.OrderNumber
            };

            context.Order.Add(order);

            try
            {
                context.SaveChanges();

                return Created("/api/users/" + order.Id, new OrderDTO
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OrderNumber = order.OrderNumber
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDTO dto)
        {
            var order = context.Order.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            ///  if (customer.IsDeleted)
            ///  {
            ///      return NotFound();
            ///   }

            if (context.Order.Any(c => c.Id == dto.Id))
            {
                return Conflict("Order je vec unet.");
            }

            order.Id = dto.Id;

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
            var order = context.Order.Find(id);

            if (order == null)
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