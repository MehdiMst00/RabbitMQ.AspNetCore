using MassTransit;

namespace RabbitMQ.AspNetCore.Publisher;

public static class ConfigureServices
{
    public static IServiceCollection AddRabbitMQ(this IServiceCollection services,
        IConfiguration configuration)
    {
        var eventBus = configuration.GetRequiredSection("EventBus");
        string hostAddress = eventBus.GetValue<string>("Host") ??
            throw new ArgumentNullException("EventBus:Host");

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri(hostAddress));
                cfg.ConfigureEndpoints(ctx);
            });
        });

        return services;
    }
}