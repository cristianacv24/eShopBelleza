using System;

namespace eShopBelleza.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; } 

        public double Price { get; set; }
      
        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime CreateDate { get; set; } 

        public int Stock { get; set; }

        public int CurrentCategoryId { get; set; }

        public Category Category { get; set; } = new Category();
    }
}
