using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
