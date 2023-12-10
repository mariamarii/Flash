using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? MenuUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
