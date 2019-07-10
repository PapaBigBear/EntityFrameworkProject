using System;
using System.Collections.Generic;
using System.Text;

namespace CMDDto.Models
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }

        public string ShippingAddress { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
    }
}
