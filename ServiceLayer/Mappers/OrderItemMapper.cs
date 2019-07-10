using CMDDto.Models;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Mappers
{
    public class OrderItemMapper
    {
        public static OrderItem DtoToDomain(OrderItemDTO orderItemDto)
        {
            if(orderItemDto != null)
            {
                return new OrderItem()
                {
                    OrderItemId = orderItemDto.OrderItemId,
                    OrderId = orderItemDto.OrderId,
                    Order = OrderMapper.DtoToDomain(orderItemDto.Order),
                    ItemId = orderItemDto.ItemId,
                    Item = ItemMapper.DtoToDomain(orderItemDto.Item),
                    ItemAddedToOrderTime = orderItemDto.ItemAddedToOrderTime,
                    ItemHeight = orderItemDto.ItemHeight,
                    ItemWidth = orderItemDto.ItemWidth,
                    ItemWeightInGrams = orderItemDto.ItemWeightInGrams,
                    ItemUnit = orderItemDto.ItemUnit,
                    Quantity = orderItemDto.Quantity
                };
            }

            return null;
        }

        public static OrderItemDTO DomainToDto(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                return new OrderItemDTO()
                {
                    OrderItemId = orderItem.OrderItemId,
                    OrderId = orderItem.OrderId,
                    Order = OrderMapper.DomainToDto(orderItem.Order),
                    ItemId = orderItem.ItemId,
                    Item = ItemMapper.DomainToDto(orderItem.Item),
                    ItemAddedToOrderTime = orderItem.ItemAddedToOrderTime,
                    ItemHeight = orderItem.ItemHeight,
                    ItemWidth = orderItem.ItemWidth,
                    ItemWeightInGrams = orderItem.ItemWeightInGrams,
                    ItemUnit = orderItem.ItemUnit,
                    Quantity = orderItem.Quantity
                };
            }

            return null;
        }
    }
}
