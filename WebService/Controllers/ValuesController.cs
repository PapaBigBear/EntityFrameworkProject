using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDDto;
using DataAccessLayer;
using DataValidation;
using Microsoft.AspNetCore.Mvc;
using Queries.Persistence;
using ServiceLayer.Services;

namespace CompanyMasterDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CMDContext context;

        public ValuesController(CMDContext context)
        {
            this.context = context;
        }


    }
}
