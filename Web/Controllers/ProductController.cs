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
using Web.Models;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProjContext context;
        private readonly IAddProductCommand _addProduct;
       /// private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductCommand _getProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IDeleteProductCommand _deleteProduct;

        public ProductController(ProjContext context, IAddProductCommand addProduct, IGetProductCommand getProduct, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct)
        {
            this.context = context;
            _addProduct = addProduct;
           /// _getProducts = getProducts;
            _getProduct = getProduct;
            _editProduct = editProduct;
            _deleteProduct = deleteProduct;
        }




        // GET: Product
        public ActionResult Index(ProductSearch search)
        {
            
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getProduct.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }


        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDTO dto)
        {

            if (!ModelState.IsValid) {
                return View(dto);
            }
            try
            {
                // TODO: Add insert logic here
                _addProduct.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Produkt vec postoji.";
            }
            catch (Exception) {
                TempData["error"] = "Doslo je do greske.";

            }
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _getProduct.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[FromBody] ProductDTO dto)
        {
            if (!ModelState.IsValid) {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                _editProduct.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException) {
                TempData["error"] = "Produkt sa tim imenom postoji";
                return View(dto);
            }
        }

        // GET: Product/Delete/5
    

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var product = context.Product.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsDeleted)
                return Conflict("That product is already deleted.");

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

        public IActionResult Product() {
            var vm = new ProductViewModel();
            var products = new List<ProductDTO>();
            vm.Products = products;
            return View(products);
        }

    }
     
    }
