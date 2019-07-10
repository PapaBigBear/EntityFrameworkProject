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
    public class OrderItemsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult AddOrderItem([FromRoute] OrderItemDTO orderItem)
        {
            try
            {
                var orderService = new OrderItemBusiness(unitOfWork);
                var addedOrder = orderService.AddOrderItem(orderItem);

                return Ok(new RequestResult()
                {
                    IsSucceeded = true,
                    Result = addedOrder,
                    Message = "OrderItem successfully added"
                });
            }
            catch (InvalidObjectException exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = exception.InvalidObject,
                    Message = $"{exception.ObjectName} : {exception.ErrorMessages.ToArray().ToString()}",
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new RequestResult()
                {
                    IsSucceeded = false,
                    Result = orderItem,
                    Message = exception.Message
                });
            }
        }
    }
}