using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Rebus.Config;


namespace Ambev.DeveloperEvaluation.Common.RabbitMq;

public static class RabbitMqExtension
{
    public static void AddRabbitMq(this WebApplicationBuilder builder)
    {
  
        builder.Services.AddMassTransit(cfg =>
        {
            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username(builder.Configuration.GetValue("RabbitMQ:Username", string.Empty));
                    h.Password(builder.Configuration.GetValue("RabbitMQ:Password", string.Empty));
                });

                cfg.ReceiveEndpoint(builder.Configuration.GetValue("RabbitMQ:QueueName", string.Empty)!, ep =>
                {
                    ep.Durable = false;
                    ep.AutoDelete = false;
                    ep.Exclusive = true;
                });
            }));
        });
    }

}
