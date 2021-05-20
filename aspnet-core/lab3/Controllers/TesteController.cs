using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
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
            try
            {
                if (count % 2 == 0)
                {
                    return Ok();
                }
                else
                {
                    throw new TesteException("teste");
                }
            }
            catch (TesteException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
