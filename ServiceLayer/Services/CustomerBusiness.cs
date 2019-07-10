using DataAccessLayer.Interfaces;
using DomainLayer.Models;
using CMDDto.Models;
using ServiceLayer.Mappers;
using DataValidation.Validators;
using System.Collections.Generic;
using DataValidation;
using System;

namespace ServiceLayer.Services
{
    public class CustomerBusiness : BaseBusiness
    {
        public CustomerBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public CustomerDTO AddCustomer1(CustomerDTO customerDto)
        {
            var customer = CustomerMapper.DtoToDomain(customerDto);
            var errorMessages = new List<string>();

            if (!CustomerValidator.Validate(customer, ref errorMessages))
            {
                throw new InvalidObjectException("Customer", customerDto, errorMessages);
            }
            else
            {
                try
                {
                    unitOfWork.CustomerRepository.Add(customer);
                    unitOfWork.Commit();

                    return CustomerMapper.DomainToDto(customer);
                }
                catch (Exception exception)
                {
                    throw new Exception("An exception occured adding customer: ", exception);
                }
            }
        }

        public CustomerDTO AddCustomer2(Customer customer)
        {
            unitOfWork.CustomerRepository.Add(customer);
            unitOfWork.Commit();

            return CustomerMapper.DomainToDto(customer);
        }
    }
}