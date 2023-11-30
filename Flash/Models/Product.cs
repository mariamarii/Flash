using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CatId { get; set; }
        public string? Type { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
