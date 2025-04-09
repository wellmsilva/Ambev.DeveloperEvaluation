using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MassTransit;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

internal sealed class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    readonly IBus _bus;

    public CancelSaleHandler(ISaleRepository saleRepository, IBus bus)
    {
        _saleRepository = saleRepository;
        _bus = bus;
    }

    public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id);
        if (sale is null)
        {
            throw new SaleNotFoundException(request.Id);
        }

        sale.Cancel();
        var result = await _saleRepository.UpdateAsync(sale);
        if (!result)
        {
            return default;
        }

        await _bus.Publish(new EventSalesMessage(EventSale.SaleCancelled, request.Id, DateTime.UtcNow), cancellationToken);

        return result;
    }
}
