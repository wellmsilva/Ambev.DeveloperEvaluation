using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MassTransit;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

internal sealed class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    readonly IBus _bus;

    public DeleteSaleHandler(ISaleRepository saleRepository, IBus bus)
    {
        _saleRepository = saleRepository;
        _bus = bus;
    }

    public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id) ?? throw new SaleNotFoundException(request.Id);

        var result = await _saleRepository.DeleteAsync(sale, cancellationToken);

        await _bus.Publish(new EventSalesMessage(EventSale.SaleDeleted, request.Id, DateTime.UtcNow), cancellationToken);

        return result;
    }
}
