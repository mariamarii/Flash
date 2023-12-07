using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class User:IdentityUser<int>
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
