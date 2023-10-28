using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unit;
        public CategoryController(IUnitOfWork db)
        {
            unit = db;
        }

        public IActionResult Index()
        {
            var list = unit.Category.GetAll().ToList();
            return View(list);
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
                //db.Categories.Update(category);
                //db.SaveChanges();
                unit.Category.Add(category);
                unit.Save();
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
                //db.Categories.Update(category);
                //db.SaveChanges();
                unit.Category.Update(category);
                unit.Save();

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
            var cat = unit.Category.Get(c => c.Id.Equals(id));//db.Categories.Find(id);
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
            var cat = unit.Category.Get(c => c.Id.Equals(id));//db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)//wtf happened?
        {
            var cat = unit.Category.Get(c => c.Id.Equals(id));
            if (cat == null)
            {
                return NotFound();
            }
            //db.Categories.Remove(cat);
            //db.SaveChanges();
            unit.Category.Remove(cat);
            unit.Save();

            TempData["success"] = "Category Delete Complete";

            return RedirectToAction("Index");
        }


    }
}
