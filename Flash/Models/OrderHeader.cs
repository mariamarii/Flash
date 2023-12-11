using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class OrderHeader
    {
        public OrderHeader()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public decimal? OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? SessionId { get; set; }
        public int PaymentIntentId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual Payment PaymentIntent { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
