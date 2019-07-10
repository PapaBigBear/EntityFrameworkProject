using DomainLayer.Models;
using System.Collections.Generic;

namespace DataValidation.Validators
{
    public class CustomerValidator
    {
        public static bool Validate(Customer customer, ref List<string> errorMessages)
        {
            if (errorMessages == null) errorMessages = new List<string>();

            if(customer != null)
            {
                if (string.IsNullOrWhiteSpace(customer.CustomerName))
                {
                    errorMessages.Add("CustomerName is invalid(null or whitespace).");
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
