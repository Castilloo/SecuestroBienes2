using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Secuestro.Models;

namespace secuestro1.Controllers;

[ApiController]
[Route("api/secuestro")]
public class SecuestroController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<SecuestroController> _logger;

    public SecuestroController(ILogger<SecuestroController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "/dbconexion")]
    public async Task<ActionResult<string>> Get([FromServices] SecuestroDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        return "Ok";
    }

    // [HttpGet(Name = "ObtenerSecuestros")]
    // public async Task<ActionResult<>>
}
