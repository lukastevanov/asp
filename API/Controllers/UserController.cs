using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddUserCommand addUser;
        private readonly IGetUserCommand getUser;
        private readonly IEditUserCommand editUser;
        private readonly IDeleteUserCommand deleteUser;
        private readonly IGetUsersCommand getUsers;

        public UserController(IGetUsersCommand users,ProjContext context, IAddUserCommand addUser, IGetUserCommand getUser, IEditUserCommand editUser, IDeleteUserCommand deleteUser)
        {
            this.context = context;
            this.addUser = addUser;
            this.getUser = getUser;
            this.editUser = editUser;
            this.deleteUser = deleteUser;
            getUsers = getUsers;
        }




        // GET api/categories
        [HttpGet]
      public IActionResult Get([FromQuery]UserSearch query)
        => Ok(getUsers.Execute(query));

    // GET api/categories/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var userDTO = getUser.Execute(id);
            return Ok(userDTO);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody] UserDTO dto)
    {
        var user = new Users
        {
            Username = dto.Username
        };

        context.Users.Add(user);

        try
        {
            context.SaveChanges();

            return Created("/api/users/" + user.Userid, new UserDTO
            {
                Userid = user.Userid,
                Username = user.Username,
                Email=user.Email
            });
        }
        catch
        {
            return StatusCode(500, "An error has occured.");
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserDTO dto)
    {
        var user = context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        if (user.IsDeleted)
        {
            return NotFound();
        }

        if (context.Users.Any(c => c.Username == dto.Username))
        {
            return Conflict("Username sa tim imenom vec postoji.");
        }

            user.Username = dto.Username;

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
        var user = context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        if (user.IsDeleted)
            return Conflict("Produkt je vec obrisan.");

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