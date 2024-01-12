namespace RabbitMQ.AspNetCore.Publisher.Dtos;

public record CreateUserDto
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
