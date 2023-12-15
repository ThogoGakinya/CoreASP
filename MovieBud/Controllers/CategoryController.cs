using Microsoft.AspNetCore.Mvc;
using CoreASP.DataAccess.Data;
using CoreASP.Models;
using CoreASP.DataAccess.Repository;

namespace MovieBud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CategoryController(IUnitOfWork cunitofwork)
        {
            _unitofwork = cunitofwork;
        }
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>(_unitofwork.Category.GetAll());

            return View(categories);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("DisplayOrder", "Display Order can not be same as Name");
            }
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Insert(obj);
                _unitofwork.Save();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            Category? category = _unitofwork.Category.Get(u=>u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Update(obj);
                _unitofwork.Save(); 
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitofwork.Category.Get(u=> u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category? obj = _unitofwork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitofwork.Category.Remove(obj);
                _unitofwork.Save();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
