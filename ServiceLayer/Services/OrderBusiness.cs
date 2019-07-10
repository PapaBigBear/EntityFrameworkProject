using System;
using CMDDto.Models;
using DataValidation;
using ServiceLayer.Mappers;
using DataValidation.Validators;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class OrderBusiness : BaseBusiness
    {
        public OrderBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public OrderDTO AddOrder(OrderDTO orderDto)
        {
            var order = OrderMapper.DtoToDomain(orderDto);
            var errorMessages = new List<string>();

            if (!OrderValidator.Validate(order, unitOfWork, ref errorMessages))
            {
                throw new InvalidObjectException("Order", orderDto, errorMessages);
            }

            try
            {
                var customer = unitOfWork.CustomerRepository.GetById(order.CustomerId);

                order.CustomerName = customer.CustomerName;
                order.CustomerNumber = customer.CustomerNumber;

                unitOfWork.OrderRepository.Add(order);
                unitOfWork.Commit();

                return OrderMapper.DomainToDto(order);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception occured adding customer: ", exception);
            }
        }

        public OrderDTO CompleteOrder(Guid orderId)
        {
            try
            {
                var order = unitOfWork.OrderRepository.GetById(orderId);

                if (order == null)
                {
                    throw new Exception($"No order with given id({orderId})");
                }

                var orderItems = unitOfWork.OrderItemRepository.GetOrderItemsByOrderId(orderId);
                var totalPrice = 0.0M;
                var totalItems = 0.0M;

                foreach(var orderItem in orderItems)
                {
                    totalPrice += orderItem.ItemPrice * orderItem.Quantity;
                    totalItems += orderItem.Quantity;
                }

                order.IsCompleted = true;
                order.TotalPrice = totalPrice;
                order.TotalItems = totalItems;

                unitOfWork.OrderRepository.Update(order);
                unitOfWork.Commit();

                return OrderMapper.DomainToDto(order);
            }
            catch (Exception exception)
            {
                throw new Exception("An error occured completing order: ", exception);
            }
        }
    }
}