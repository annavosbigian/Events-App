using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

//chekces hosing environment

namespace RSVPTake3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IHostEnvironment _env;

        public TestController(IHostEnvironment env )
        {
            this._env = env;
        }
        public Object Execute()
        {
            return new { this._env.EnvironmentName };
        }
    }
}