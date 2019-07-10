using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }

        public bool IncludeFreeBasket { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDelivered { get; set; }

        public string ShippingAddress { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal TotalItems { get; set; }
    }
}
