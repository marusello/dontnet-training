using System;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    [Route("api/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private static int count = 0;

        [HttpGet]
        public IActionResult Get()
        {
            count++;

            if (count % 2 == 0)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
