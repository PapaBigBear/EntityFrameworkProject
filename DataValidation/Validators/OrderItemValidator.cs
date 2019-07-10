using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace DataValidation.Validators
{
    public class OrderItemValidator
    {
        public static bool Validate(OrderItem orderItem, IUnitOfWork unitOfWork, ref List<string> errorMessages)
        {
            if (errorMessages == null) errorMessages = new List<string>();
            
            if(orderItem != null)
            {
                if(orderItem.ItemId == Guid.Empty)
                {
                    errorMessages.Add("Item id is an empty guid.");
                }
                else if (!unitOfWork.ItemRepository.Exist(orderItem.ItemId))
                {
                    errorMessages.Add($"Item with given id({orderItem.ItemId}) does not exist.");
                }
            }
            else
            {
                errorMessages.Add("OrderItem is null/invalid.");
            }

            return errorMessages.Count == 0;
        }
    }
}
