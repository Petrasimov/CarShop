using CarStore.Data.Mocks;
using CarStore.Data.ViewModels;
using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Controllers
{
    public class CarController : Controller
    {
        ApplicationContext db;
        IWebHostEnvironment env;
        public CarController(ApplicationContext _db, IWebHostEnvironment _env)
        { 
            db = _db;
            env = _env;
        }
        public IActionResult SingleCar(int carId)
        {
            return View(db.Cars.Find(carId));
        }

        public RedirectToActionResult AddCarsToDb()
        {
            MockCars cars = new MockCars();

            foreach (Car car in cars.Cars)
            {
                db.Add(car);
                db.SaveChanges();
            }
            return RedirectToAction("TableCars");
        }

        public IActionResult TableCars()
        {
            ViewBag.Title = "Полный список автомобилей";
            return View(db.Cars);
        }

        public RedirectToActionResult DeleteCar(int carId)
        {
            var car = db.Cars.Find(carId);
            db.Remove(car);
            db.SaveChanges();

            return RedirectToAction("TableCars");
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            ViewBag.Title = "Добавление товара";
            return View(new AddCarViewModel
            {
                Car = new Car(),
                Categories = db.Categories.ToList()
            });
        }

        [HttpPost]
        public RedirectToActionResult AddCar(Car car, IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                string path = $"{"/img/cars/"}{Path.GetFileName(uploadedFile.FileName)}";
                car.Img = path;

                using (var fs = new FileStream($"{env.WebRootPath}{path}", FileMode.Create))
                {
                    uploadedFile.CopyTo(fs);
                }
            }
            if(car != null)
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
            return RedirectToAction("TableCars");
        }
        [HttpGet]
        public IActionResult EditCar(int carId)
        {
            ViewBag.Title = "Редактирование товара";
            Car car = db.Cars.Find(carId);
            return View(new AddCarViewModel
            {
                Car = car ?? new Car(),
                Categories = db.Categories.ToList()
            });
        }

        [HttpPost]
        public RedirectToActionResult EditCar(Car car, IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                string path = $"{"/img/cars/"}{Path.GetFileName(uploadedFile.FileName)}";
                car.Img = path;

                using (var fs = new FileStream($"{env.WebRootPath}{path}", FileMode.Create))
                {
                    uploadedFile.CopyTo(fs);
                }
            }
            if(car != null)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("TableCars");
        }
    }
}
