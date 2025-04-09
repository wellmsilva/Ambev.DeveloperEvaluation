using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public record DeleteSaleCommand(Guid Id) : IRequest<bool>
{
    public static implicit operator DeleteSaleCommand(Guid id) => new(id);
}

