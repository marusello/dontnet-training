using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

[Route("api")]
[ApiController]
public class ConfiguracaoController : ControllerBase
{
    private readonly IOptions<ConnectionString> connection;

    public ConfiguracaoController(IOptions<ConnectionString> connection)
    {   
        this.connection = connection;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok(connection);
    }
}