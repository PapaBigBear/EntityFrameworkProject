using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDDto.Common;
using CMDDto.Models;
using DataAccessLayer.Interfaces;
using DataValidation;
using DataValidation.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queries.Persistence;
using ServiceLayer.Mappers;
using ServiceLayer.Services;

namespace CompanyMasterDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        [HttpPost("AddCustomer1")]
        public IActionResult AddCustomer1([FromBody] CustomerDTO customer)
        {
            try
            {
                var customerService = new CustomerBusiness(unitOfWork);
                var addedCustomer = customerService.AddCustomer1(customer);

                return Ok(new RequestResult() {
                    IsSucceeded = true,
                    Result = addedCustomer,
                    Message = "Customer successfully added"
                });
            }
            catch(InvalidObjectException exception)
            {
                return BadRequest(new RequestResult() {
                    IsSucceeded = false,
                    Result = exception.InvalidObject,
                    Message = $"Could not add '{exception.ObjectName}'.",
                    ErrorMessages = exception.ErrorMessages
                });
            }
            catch(Exception exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = customer,
                    Message = exception.Message
                });
            }
        }

        [HttpPost("AddCustomer2")]
        public IActionResult AddCustomer2([FromBody] CustomerDTO customerDto)
        {
            var customer = CustomerMapper.DtoToDomain(customerDto);
            var errorMessages = new List<string>();
            
            if(CustomerValidator.Validate(customer, ref errorMessages))
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = customerDto,
                    Message = $"Could not add customer.",
                    ErrorMessages = errorMessages
                });
            }

            try
            {
                var customerService = new CustomerBusiness(unitOfWork);
                var addedCustomer = customerService.AddCustomer2(customer);

                return Ok(new RequestResult()
                {
                    IsSucceeded = true,
                    Result = addedCustomer,
                    Message = "Customer successfully added"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = customer,
                    Message = exception.Message
                });
            }
        }
    }
}