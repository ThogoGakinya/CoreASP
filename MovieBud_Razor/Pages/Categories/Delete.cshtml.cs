using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBud_Razor.Data;
using MovieBud_Razor.Model;

namespace MovieBud_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly DataConnector _db;
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(DataConnector db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }

        }
        public IActionResult OnPost(int id)
        {
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
