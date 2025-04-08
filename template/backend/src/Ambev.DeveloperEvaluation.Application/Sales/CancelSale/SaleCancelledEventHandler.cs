using Rebus.Handlers;
using Rebus.Messages;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class SaleCancelledEvent : Message
{
    public SaleCancelledEvent(Dictionary<string, string> headers, object body) : base(headers, body)
    {
    }
}

public class SaleCancelledEventHandler : IHandleMessages<SaleCancelledEvent>
{
    public Task Handle(SaleCancelledEvent message)
    {
        throw new NotImplementedException();
    }
}
