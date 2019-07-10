using System;
using System.Collections.Generic;
using System.Text;

namespace CMDDto.Models
{
    public class OrderItemDTO
    {
        public Guid OrderItemId { get; set; }

        public Guid OrderId { get; set; }
        public OrderDTO Order { get; set; }

        public Guid ItemId { get; set; }
        public ItemDTO Item { get; set; }

        public DateTime ItemAddedToOrderTime { get; set; }
        public decimal ItemHeight { get; set; } // For log
        public decimal ItemWidth { get; set; } // For log
        public decimal ItemWeightInGrams { get; set; } // For log
        public decimal ItemPrice { get; set; } // For log
        public decimal Quantity { get; set; } // For log
        public string ItemUnit { get; set; } // For log
    }
}
