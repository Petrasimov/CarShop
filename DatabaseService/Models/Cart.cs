using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Models
{
    public class Cart
    {
        ApplicationContext db;
        public Cart(ApplicationContext _db)
        {
            db= _db;
        }

        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public string CartId {  get; set; }
        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider service)
        {
            //начинаем работу с сессиями
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ApplicationContext>();

            //создадим идентификатор для корзины
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart(Car car)
        {
            if(car != null)
            {
                db.CartItems.Add(new CartItem { Car = car, Price = car.Price, CartId = CartId});
                db.SaveChanges();
            }
        }
        public List<CartItem> GetGartItems => db.CartItems
            .Where(el=>el.CartId == CartId)
            .Include(el=>el.Car)
            .ToList();
    }
}
