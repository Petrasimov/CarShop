using DatabaseService.Models;

namespace CarStore.Data.ViewModels
{
    public class CartPageViewModel
    {
        public Cart Cart { get; set; }
        public decimal Sum => Cart.CartItems.Sum(c=>c.Price);
    }
}
