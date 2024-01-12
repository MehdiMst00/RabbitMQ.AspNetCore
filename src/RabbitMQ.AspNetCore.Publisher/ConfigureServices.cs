using MassTransit;

namespace RabbitMQ.AspNetCore.Publisher;

public static class ConfigureServices
{
    public static IServiceCollection AddRabbitMQ(this IServiceCollection services,
        IConfiguration configuration)
    {
        var eventBus = configuration.GetRequiredSection("EventBus");

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(eventBus["Host"],
                    eventBus["VirtualHost"],
                    c =>
                    {
                        c.Username(eventBus["Username"]);
                        c.Password(eventBus["Password"]);
                    });

                cfg.ConfigureEndpoints(ctx);
            });
        });

        return services;
    }
}