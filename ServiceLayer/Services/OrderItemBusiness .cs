using System;
using CMDDto.Models;
using DataValidation;
using ServiceLayer.Mappers;
using DataValidation.Validators;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class OrderItemBusiness : BaseBusiness
    {
        public OrderItemBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public OrderItemDTO AddOrderItem(OrderItemDTO orderItemDto)
        {
            var orderItem = OrderItemMapper.DtoToDomain(orderItemDto);
            var errorMessages = new List<string>();

            if (!OrderItemValidator.Validate(orderItem, unitOfWork, ref errorMessages))
            {
                throw new InvalidObjectException("Order", orderItem, errorMessages);
            }

            try
            {
                var item = unitOfWork.ItemRepository.GetById(orderItemDto.ItemId);

                orderItem.ItemPrice = item.Price;
                orderItem.ItemHeight = item.Height;
                orderItem.ItemWidth = item.Width;
                orderItem.ItemUnit = item.Unit;
                orderItem.ItemWeightInGrams = item.WeightInGrams;

                unitOfWork.OrderItemRepository.Add(orderItem);
                unitOfWork.Commit();

                return OrderItemMapper.DomainToDto(orderItem);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception occured adding customer: ", exception);
            }
        }
    }
}