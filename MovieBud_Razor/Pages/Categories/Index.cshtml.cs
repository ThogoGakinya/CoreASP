using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using MovieBud_Razor.Data;
using MovieBud_Razor.Model;

namespace MovieBud_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataConnector _db;
        public List<Category> categories { get; set; }

        public IndexModel(DataConnector db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categories = _db.Categories.ToList();
        }
    }
}
