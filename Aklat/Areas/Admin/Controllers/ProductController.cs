﻿using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IProductReposatory productRepoo;

        public ICategoryReposatory CategoryReposatory;

        public ProductController(IProductReposatory productRepoo, ICategoryReposatory categoryReposatory)
        {
            this.productRepoo = productRepoo;
            this.CategoryReposatory = categoryReposatory;
        }
        /// <summary>
        /// add new test  
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(productRepoo.GetAll());

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["cat"] = CategoryReposatory.GetAll();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewData["cat"] = CategoryReposatory.GetAll();

            if (ModelState.IsValid)
            {
                productRepoo.Create(product);
                productRepoo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["cat"] = CategoryReposatory.GetAll();


            return View(productRepoo.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            ViewData["cat"] = CategoryReposatory.GetAll();

            if (ModelState.IsValid)
            {
                productRepoo.Update(id, product);
                productRepoo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }
        public ActionResult Delete(int id)
        {
            productRepoo.Delete(id);
            productRepoo.Save();
            return RedirectToAction("Index");

        }


    }

}