using Ambev.DeveloperEvaluation.Application.Sales.Events;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MassTransit;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

internal class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    readonly IBus _bus;

    public UpdateSaleHandler(IMapper mapper, ISaleRepository saleRepository, IBus bus)
    {
        _saleRepository = saleRepository;
        _bus = bus;
    }

    public async Task<bool> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.Id) ?? throw new SaleNotFoundException(command.Id);
        
        sale.Update(command.Number, command.CustomerId, command.Branch);

        var result = await _saleRepository.UpdateAsync(sale, cancellationToken);

        await _bus.Publish(new EventSalesMessage(EventSale.SaleModified, command.Id, DateTime.UtcNow), cancellationToken);

        return result;
    }
}
