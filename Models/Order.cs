using System;
using System.Collections.Generic;

namespace EKart.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string FullName { get; set; } = null!;
        public long Contact { get; set; }
        public string? Address { get; set; }
    }
}
