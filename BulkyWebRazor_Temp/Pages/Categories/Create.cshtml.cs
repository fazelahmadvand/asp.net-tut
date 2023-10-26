using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private ApplicationDbContext db;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            this.db = db;
        }



        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            db.Categories.Add(Category);
            db.SaveChanges();
            TempData["success"] = "Success";
            return RedirectToPage("Index");
        }



    }
}
