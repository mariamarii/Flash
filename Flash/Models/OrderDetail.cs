using System;
using System.Collections.Generic;

namespace Flash.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public virtual OrderHeader OrderHeader { get; set; } = null!;
        public virtual Product OrderHeaderNavigation { get; set; } = null!;
    }
}
