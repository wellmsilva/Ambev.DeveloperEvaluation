using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale.Notifications;

public record SaleCreatedNotification(Guid Id) : INotification { }

public class SaleCreatedNotificationHandler : INotificationHandler<SaleCreatedNotification>
{
    //private readonly IRabbitMQService _rabbitMQService;

    public Task Handle(SaleCreatedNotification notification, CancellationToken cancellationToken)
    {
        //var message = new EventSalesMessageModel(EventSale.SaleCreated, notification.SaleId, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc));
        //_rabbitMQService.SendMessage(message);

        return Task.CompletedTask;
    }
}
