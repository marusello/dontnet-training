
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

[Route("api")]
[ApiController]
public class ConfiguracaoController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly IOptions<ConnectionString> connection;

    public ConfiguracaoController(IConfiguration configuration, 
          IOptions<ConnectionString> connection)
    {
        this.configuration = configuration;
        this.connection = connection;
    }

    [HttpGet]
    public ActionResult<string> DatabaseNameGet()
    {
        //return configuration["ConfiguracaoDemo"];
        return Ok(connection);
    }
}