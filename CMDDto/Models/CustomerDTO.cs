using System;
using System.Collections.Generic;
using System.Text;

namespace CMDDto.Models
{
    public class CustomerDTO
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
