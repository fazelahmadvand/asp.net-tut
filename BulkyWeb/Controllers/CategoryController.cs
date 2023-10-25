using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var objs = db.Categories.ToList();
            return View(objs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                TempData["success"] = "Category Create Complete";

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                TempData["success"] = "Category Edit Complete";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            //db.SaveChanges();

            return View(cat);
        }

        public IActionResult Delete(int? id)//wtf happened?
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
            
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)//wtf happened?
        {
            var cat = db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            db.Categories.Remove(cat);
            db.SaveChanges();
            TempData["success"] = "Category Delete Complete";

            return RedirectToAction("Index");
        }


    }
}
