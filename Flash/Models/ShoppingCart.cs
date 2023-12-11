using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string UserId { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
