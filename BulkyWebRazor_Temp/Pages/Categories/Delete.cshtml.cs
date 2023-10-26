using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            var del = db.Categories.Find(Category.Id);
            if (del == null)
                return NotFound();
            db.Categories.Remove(del);
            db.SaveChanges();
            TempData["success"] = "Delete";

            return RedirectToPage("Index");
        }
    }
}
