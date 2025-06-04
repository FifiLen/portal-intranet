using System.Collections.Generic;

namespace FashionStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int? Discount { get; set; }
        public bool IsNew { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Sizes { get; set; }
        public bool Featured { get; set; }
    }
}
