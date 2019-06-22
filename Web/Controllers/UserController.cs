using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddUserCommand addUser;
        private readonly IGetUserCommand getUser;
        private readonly IEditUserCommand editUser;
        private readonly IDeleteUserCommand deleteUser;

        public UserController(ProjContext context, IAddUserCommand addUser, IGetUserCommand getUser, IEditUserCommand editUser, IDeleteUserCommand deleteUser)
        {
            this.context = context;
            this.addUser = addUser;
            this.getUser = getUser;
            this.editUser = editUser;
            this.deleteUser = deleteUser;
        }

        /// private readonly IGetProductsCommand getUsers;

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = getUser.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }
           
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add insert logic here
                addUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Korisnik vec postoji.";
            }
            catch (Exception)
            {
                TempData["error"] = "Doslo je do greske.";

            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = getUser.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromBody] UserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                editUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Korisnik sa tim imenom postoji";
                return View(dto);
            }
        }

        // GET: User/Delete/5
       
        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var user = context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.isDeleted)
                return Conflict("Korisnik je vec obrisan.");

            ////user.IsDeleted = true;


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

        public IActionResult Product()
        {
            var vm = new ProductViewModel();
            var products = new List<ProductDTO>();
            vm.Products = products;
            return View(products);
        }


    }
}