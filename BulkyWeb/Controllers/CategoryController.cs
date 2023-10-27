using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repository;
        public CategoryController(ICategoryRepository db)
        {
            repository = db;
        }

        public IActionResult Index()
        {
            //var objs = db.Categories.ToList();

            return View(repository.GetAll().ToList());
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
                repository.Add(category);
                repository.Save();
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
                repository.Update(category);
                repository.Save();

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
            var cat = repository.Get(c => c.Id.Equals(id));//db.Categories.Find(id);
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
            var cat = repository.Get(c => c.Id.Equals(id));//db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)//wtf happened?
        {
            var cat = repository.Get(c => c.Id.Equals(id));
            if (cat == null)
            {
                return NotFound();
            }
            //db.Categories.Remove(cat);
            //db.SaveChanges();
            repository.Remove(cat);
            repository.Save();

            TempData["success"] = "Category Delete Complete";

            return RedirectToAction("Index");
        }


    }
}
