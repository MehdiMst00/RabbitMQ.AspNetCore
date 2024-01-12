using Microsoft.AspNetCore.Mvc;
using RabbitMQ.AspNetCore.Publisher.Dtos;

namespace RabbitMQ.AspNetCore.Publisher.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
    {
        // TODO: publish event

        return Ok();
    }
}
