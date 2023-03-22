using System;
using System.Collections.Generic;

namespace EKart.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string QuantityAvailable { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
