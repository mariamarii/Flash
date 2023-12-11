using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class Payment
    {
        public Payment()
        {
            OrderHeaders = new HashSet<OrderHeader>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CardNo { get; set; }
        public string? ExpiryDate { get; set; }
        public int? CvvNo { get; set; }
        public string? Address { get; set; }
        public string? PaymentMode { get; set; }

        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
