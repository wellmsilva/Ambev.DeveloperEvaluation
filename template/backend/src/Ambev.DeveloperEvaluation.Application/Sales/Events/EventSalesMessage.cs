using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.Events;

public record EventSalesMessage(EventSale Event, Guid Id, DateTime Date)
{}
