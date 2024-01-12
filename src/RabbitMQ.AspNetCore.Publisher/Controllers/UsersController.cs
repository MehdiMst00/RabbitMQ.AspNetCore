using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.AspNetCore.Etos;
using RabbitMQ.AspNetCore.Publisher.Dtos;
using System.Text.Json;

namespace RabbitMQ.AspNetCore.Publisher.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public UsersController(ILogger<UsersController> logger,
        IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
    {
        // it's better use automapper :)
        var eto = new CreateUserEto() { Email = dto.Email, Username = dto.Username, Password = dto.Password };

        // publish event
        await _publishEndpoint.Publish<CreateUserEto>(eto);

        _logger.LogInformation("[CreateUserAsync] - User successfully published. Event: {eto}", JsonSerializer.Serialize(eto));

        return Ok(eto);
    }
}