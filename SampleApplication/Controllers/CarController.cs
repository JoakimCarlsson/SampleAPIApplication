using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Services.Products;

namespace SampleApplication.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet("GetTwo")]
        [ApiVersion("2.0")]
        public async Task<ActionResult> GetTwo()
        {
            return Ok("2.0");
        }

        [HttpGet("GetOne")]
        [ApiVersion("1.0")]
        public async Task<ActionResult> GetOne()
        {
            return Ok("1.0");
        }
    }
}
