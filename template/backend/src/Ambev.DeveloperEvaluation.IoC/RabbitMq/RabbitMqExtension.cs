using Microsoft.AspNetCore.Builder;

using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Ambev.DeveloperEvaluation.IoC.RabbitMq;

public static class RabbitMqExtension
{

    public static void AddRabbitMq(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(builder.Configuration.GetConnectionString("RabbitConnection"));

                cfg.UseDelayedMessageScheduler();
                cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter(builder.Configuration.GetValue("RabbitMQ:QueueName", ""), false));
                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });

    }

}
