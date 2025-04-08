namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequest
{
    public Guid Id { get; set; }

    public static implicit operator GetSaleRequest(Guid id) => new() { Id = id };
}
