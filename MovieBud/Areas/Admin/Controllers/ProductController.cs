﻿using CoreASP.DataAccess.Repository;
using CoreASP.Models;
using CoreASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieBud.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> products = new List<Product>(_unitOfWork.Product.GetAll());

            return View(products);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            else 
            {
                Product product = _unitOfWork.Product.Get(p=>p.Id == id);
                return View(product); 
            }
        }
        [HttpPost]
        public IActionResult Edit(Product product) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create() 
        {
            ProductVM productVM = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM obj) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Insert(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Addess Successfully";
                return RedirectToAction("Index");
            }
            else 
            {
                return RedirectToAction("Create");
            }
        }

        public IActionResult Delete(int? id) 
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            else 
            {
                Product? product = _unitOfWork.Product.Get(u=>u.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
