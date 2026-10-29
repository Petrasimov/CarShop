using CarStore.Data.ViewModels;
using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class CartController : Controller
    {
        ApplicationContext db;
        Cart cart;
        public CartController(ApplicationContext _db, Cart _cart)
        {
            db = _db;
            cart = _cart;
        }
        public IActionResult CartIndex()
        {
            cart.CartItems = cart.GetGartItems;
            return View(new CartPageViewModel { Cart = cart});
        }

        public RedirectToActionResult AddToCart(int carId)
        {
            Car car = db.Cars.Find(carId);
            if(car != null)
            {
                cart.AddToCart(car);
            }
            return RedirectToAction("CartIndex");
        }
    }
}
