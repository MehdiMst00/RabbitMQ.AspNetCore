using RabbitMQ.AspNetCore.Common;

namespace RabbitMQ.AspNetCore.Etos;

/// <summary>
/// ETO: Event Transfer Object
/// </summary>
public class CreateUserEto : IntegrationBaseEvent
{
    public CreateUserEto() { }

    public CreateUserEto(Guid eventId,
        DateTime creationTime)
        : base(eventId, creationTime) { }

    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
