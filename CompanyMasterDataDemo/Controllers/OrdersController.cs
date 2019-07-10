using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDDto.Common;
using CMDDto.Models;
using DataAccessLayer.Interfaces;
using DataValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace CompanyMasterDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            try
            {
                var orderService = new OrderBusiness(unitOfWork);
                var addedOrder = orderService.AddOrder(order);

                return Ok(new RequestResult()
                {
                    IsSucceeded = true,
                    Result = addedOrder,
                    Message = "Order successfully added"
                });
            }
            catch (InvalidObjectException exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = exception.InvalidObject,
                    Message = $"Could not add '{exception.ObjectName}'.",
                    ErrorMessages = exception.ErrorMessages
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = order,
                    Message = exception.Message
                });
            }
        }
    }
}