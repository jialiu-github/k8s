using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apiForProbe.Controllers
{
    [Route("api/[controller]")]
    public class ProbeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            SingleInstanceCounter.Inc();
            if(SingleInstanceCounter.Counter() > 10)
            {
                return BadRequest();
            }
            return Ok($"I am working! The counter is {SingleInstanceCounter.Counter()}");
        }
    }
}
