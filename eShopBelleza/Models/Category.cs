using System;
using System.Collections.Generic;
using System.Text;

namespace eShopBelleza.Models
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
