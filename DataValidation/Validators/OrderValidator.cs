using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace DataValidation.Validators
{
    public class OrderValidator
    {
        public static bool Validate(Order order, IUnitOfWork unitOfWork, ref List<string> errorMessages)
        {
            if (errorMessages == null) errorMessages = new List<string>();

            if (order != null)
            {
                if (order.CustomerId == Guid.Empty)
                {
                    errorMessages.Add("CustomerId is an empty guid.");
                }
                else if(!unitOfWork.CustomerRepository.Exist(order.CustomerId))
                {
                    errorMessages.Add($"Customer with id({order.CustomerId}) does not exist.");
                }
            }
            else
            {
                errorMessages.Add("Customer cannot be null.");
            }

            return errorMessages.Count == 0;
        }
    }
}
