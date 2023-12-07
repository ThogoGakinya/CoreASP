using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBud_Razor.Data;
using MovieBud_Razor.Model;

namespace MovieBud_Razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly DataConnector _db;
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(DataConnector db)
        {
            _db = db;   
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0 )
            {
                Category = _db.Categories.Find(id);
            }
            
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToPage("Index");
            }

            return Page();
            
        }
    }
}
