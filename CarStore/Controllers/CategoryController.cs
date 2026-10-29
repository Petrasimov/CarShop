using CarStore.Data.ViewModels;
using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationContext db;
        public CategoryController(ApplicationContext _db) 
        {
            db = _db;
        }

        public IActionResult TableCategories()
        {
            ViewBag.Title = "Полный список категорий";
            return View(db.Categories);
        }

        public RedirectToActionResult DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            db.Remove(category);
            db.SaveChanges();

            return RedirectToAction("TableCategories");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.Title = "Добавление категории";
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddCategory(Category category)
        {
            if (category != null)
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("TableCategories");
        }

    }
}
