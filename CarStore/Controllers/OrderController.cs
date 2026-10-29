using DatabaseService;
using DatabaseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class OrderController : Controller
    {
        ApplicationContext db;
        Cart cart;
        public OrderController(ApplicationContext _db, Cart _cart)
        {
            db = _db;
            cart = _cart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.CartItems = cart.GetGartItems;
            if (cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("Ошибка добавления товаров", "Товары не найдены");
            }
            if (ModelState.IsValid)
            {
                CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        private void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var item in cart.CartItems)
            {
                db.OrderDetails.Add(new OrderDetail
                {
                    CarId = item.Car.CarId,
                    OrderId = order.OrderId,
                    Price = item.Car.Price
                });
                db.SaveChanges();
            }
        }

        public ViewResult Complete()
        {
            return View();
        }
    }
}
