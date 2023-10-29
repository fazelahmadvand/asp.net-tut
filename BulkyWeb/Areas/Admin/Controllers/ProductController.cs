using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork unit;
        private readonly IWebHostEnvironment webEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webEnvironment)
        {
            unit = db;
            this.webEnvironment = webEnvironment;
        }


        public IActionResult Index()
        {
            var list = unit.Product.GetAll().ToList();
            return View(list);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categoryList = unit.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            var vm = new ProductVM()
            {
                CategoryList = categoryList,
                Product = id == null || id == 0 ? new() : unit.Product.Get(u => u.Id == id),
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM pro, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pPath = @"images\product";
                    string rootPath = webEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
                    string productPath = Path.Combine(rootPath, pPath);

                    using var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create);
                    file.CopyTo(fileStream);
                    pro.Product.ImageUrl = pPath + fileName;
                }



                unit.Product.Add(pro.Product);
                unit.Save();
                TempData["success"] = "Create Completely Done";

                return RedirectToAction("Index");
            }
            else
            {
                pro.CategoryList = unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(pro);
            }
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
