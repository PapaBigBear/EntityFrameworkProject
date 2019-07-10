using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public DateTime ItemAddedToOrderTime { get; set; }
        public decimal ItemHeight { get; set; } // For log
        public decimal ItemWidth { get; set; } // For log
        public decimal ItemWeightInGrams { get; set; } // For log
        public decimal ItemPrice { get; set; } // For log
        public decimal Quantity { get; set; } // For log
        public string ItemUnit { get; set; } // For log
    }
}
