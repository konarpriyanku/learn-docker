using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace mywebapi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController: Controller
    {
        // GET api/values
        [HttpGet]
        public dynamic Get()
        {   return new
            {
                Guid = Guid.NewGuid().ToString(),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer =  Dns.GetHostName(),
                Machine =  Environment.MachineName
            };
        }

    }
}
