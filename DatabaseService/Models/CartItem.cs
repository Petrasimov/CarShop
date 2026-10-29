using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Car Car { get; set; }
        public decimal Price { get; set; }
        public string CartId { get; set; }
    }
}
