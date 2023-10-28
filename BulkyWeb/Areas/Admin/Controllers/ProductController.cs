using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork unit;
        public ProductController(IUnitOfWork db)
        {
            unit = db;
        }


        public IActionResult Index()
        {
            var list = unit.Product.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                unit.Product.Add(pro);
                unit.Save();
                TempData["success"] = "Create Completely Done";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pro = unit.Product.Get(p => p.Id == id);
            if (pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }


        [HttpPost]
        public IActionResult Edit(Product pro)
        {
            if (ModelState.IsValid)
            {
                unit.Product.Update(pro);
                TempData["success"] = "Edit Completely Done";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var pro = unit.Product.Get(p => p.Id == id);
            if (pro == null)
                return BadRequest();
            return View(pro);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null)
                return View();

            var pro = unit.Product.Get(p => p.Id == id);
            if (pro == null)
                return View();
            unit.Product.Remove(pro);
            unit.Save();
            return RedirectToAction("Index");
        }





    }
}
