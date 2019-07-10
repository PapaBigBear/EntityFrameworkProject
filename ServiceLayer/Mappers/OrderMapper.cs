using CMDDto.Models;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Mappers
{
    public class OrderMapper
    {
        public static Order DtoToDomain(OrderDTO orderDto)
        {
            if(orderDto != null)
            {
                return new Order()
                {
                    OrderId = orderDto.OrderId,
                    CustomerId = orderDto.CustomerId,
                    EstimatedDeliveryTime = orderDto.EstimatedDeliveryTime,
                    ShippingAddress = orderDto.ShippingAddress,
                    Customer = CustomerMapper.DtoToDomain(orderDto.Customer)
                };
            }

            return null;
        }

        public static OrderDTO DomainToDto(Order order)
        {
            if (order != null)
            {
                return new OrderDTO()
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    EstimatedDeliveryTime = order.EstimatedDeliveryTime,
                    ShippingAddress = order.ShippingAddress,
                    Customer = CustomerMapper.DomainToDto(order.Customer)
                };
            }

            return null;
        }
    }
}
