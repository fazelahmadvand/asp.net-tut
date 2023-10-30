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
            var list = unit.Product.GetAll("Category").ToList();
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

                    if (!string.IsNullOrEmpty(pro.Product.ImageUrl))
                    {
                        var oldImg = Path.Combine(rootPath, pro.Product.ImageUrl[1..]);

                        if (System.IO.File.Exists(oldImg))
                            System.IO.File.Delete(oldImg);

                    }

                    using var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create);
                    file.CopyTo(fileStream);
                    pro.Product.ImageUrl = @"\" + pPath + @"\" + fileName;


                }

                if (pro.Product.Id == 0)
                {
                    unit.Product.Add(pro.Product);

                }
                else
                {
                    unit.Product.Update(pro.Product);

                }

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


        [HttpGet]
        public IActionResult GetAll()
        {
            var list = unit.Product.GetAll("Category").ToList();

            return Json(new { data = list });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var pro = unit.Product.Get(p => p.Id == id);
            if (pro == null)
            {
                return Json(new { success = false, message = "Error" });
            }


            if (!string.IsNullOrEmpty(pro.ImageUrl))
            {
                var oldImg = Path.Combine(webEnvironment.WebRootPath, pro.ImageUrl[1..]);

                if (System.IO.File.Exists(oldImg))
                    System.IO.File.Delete(oldImg);

            }
            unit.Product.Remove(pro);
            unit.Save();
            return Json(new { success = true, message = "Success" });
        }

    }
}
