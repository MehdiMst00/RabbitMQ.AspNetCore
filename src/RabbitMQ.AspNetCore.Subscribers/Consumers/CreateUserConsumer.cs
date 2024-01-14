using MassTransit;
using RabbitMQ.AspNetCore.Etos;
using System.Text.Json;

namespace RabbitMQ.AspNetCore.Subscribers.Consumers;

public class CreateUserConsumer : IConsumer<CreateUserEto>
{
    private readonly ILogger<CreateUserConsumer> _logger;

    public CreateUserConsumer(ILogger<CreateUserConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CreateUserEto> context)
    {
        _logger.LogInformation("[CreateUserAsync] - I receive the user !: Event: {eto}", JsonSerializer.Serialize(context.Message));

        return Task.CompletedTask;
    }
}
