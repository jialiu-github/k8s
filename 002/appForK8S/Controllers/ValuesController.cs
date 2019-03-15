using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace appForK8S.Controllers
{
    [Route("api/[controller]")]
    public class NameController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "liu Jia";
        }

    }
}
