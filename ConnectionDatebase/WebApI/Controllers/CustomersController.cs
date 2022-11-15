using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI.BAL;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBAL _customerBAL;
        public CustomersController(ICustomerBAL customerBAL)
        {
            _customerBAL = customerBAL;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var GetResult = _customerBAL.Get();
                if(GetResult != null)
                {
                    var result = GetResult.FirstOrDefault();
                    return Ok("Successful");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
