namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

public class DeleteSaleRequest
{
    public Guid Id { get; set; }

    public static implicit operator DeleteSaleRequest(Guid id) => new() { Id = id };
}
