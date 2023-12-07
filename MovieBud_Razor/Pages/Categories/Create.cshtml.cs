using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBud_Razor.Data;
using MovieBud_Razor.Model;

namespace MovieBud_Razor.Pages.Categories
{
   
    public class CreateModel : PageModel
    {
        private readonly DataConnector _db;
        [BindProperty]
        public Category Category { get; set; }  
        public CreateModel(DataConnector db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnPost() 
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
