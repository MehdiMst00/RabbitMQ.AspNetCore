using RabbitMQ.AspNetCore.Subscribers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRabbitMQ(configuration);

var app = builder.Build();

app.Run();
