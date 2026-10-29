using CarStore.Data.Mocks;
using CarStore.Data.ViewModels;
using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class HomeController: Controller
    {
        ApplicationContext db;
        private int pageSize = 8;
        public HomeController(ApplicationContext _db)
        {
            db = _db;
        }

        public IActionResult Index(int category=1, int page = 1)
        {
            
            ViewBag.Title = "Главная страница";
            return View(
                new HomePageViewModel
                {
                    Cars = db.Cars.Where(cat=>cat.CategoryId==category).Skip((page-1)*pageSize).Take(pageSize).OrderBy(c=>c.CarId),
                    PagingInfo = new PagingInfo
                    {
                        TotalItems = db.Cars.Where(cat=>cat.CategoryId==category).Count(),
                        ItemPerPage = pageSize,
                        CurrentPage = page,
                        CurrentCategory = category
                    },
                    CurrentCategory = category
                }
            );
        }

        public IActionResult Info()
        {
            ViewBag.Title = "Страница Контакты";
            return View();
        }
    }
}
