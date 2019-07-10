using CMDDto.Models;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Mappers
{
    public class CustomerMapper
    {
        public static Customer DtoToDomain(CustomerDTO customer)
        {
            if(customer != null)
            {
                var newCustomer = new Customer()
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerNumber = customer.CustomerNumber
                };

                return newCustomer;
            }

            return null;
        }

        public static CustomerDTO DomainToDto(Customer customer)
        {
            if (customer != null)
            {
                var newCustomer = new CustomerDTO()
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerNumber = customer.CustomerNumber
                };

                return newCustomer;
            }

            return null;
        }
    }
}
