using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab2.Repositories;
using System;

namespace lab2.Controllers
{
    [Route("/")]
    [ApiController]
    public class TesteServicoController : ControllerBase
    {
        private static int count = 0;

        [HttpGet]
        public IActionResult Get([FromServices] ITesteServico testeServico)
        {
            count++;

            if (count % 2 == 0)
            {
                var message = testeServico.Teste();

                return Ok(message);
            }
            else
            {
                throw new Exception();
            }
          
            //     return StatusCode(StatusCodes.Status500InternalServerError);         
        }
    }
}
