using System.Collections.Generic;

namespace FashionStore.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
