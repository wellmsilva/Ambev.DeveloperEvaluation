﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public record CancelSaleCommand(Guid Id) : IRequest<bool>
{
    public static implicit operator CancelSaleCommand(Guid id) => new(id);
}
